using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Xml.Linq;
using System.Collections.Generic;

namespace MacAttack.Macros
{
    internal class Binds
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        public static Keys GetKey()
        {
            bool found = false;
            Keys foundKey = Keys.None;

            while (found == false)
            {
                foreach (int i in Enum.GetValues(typeof(Keys)))
                {
                    if (GetAsyncKeyState(i) == -32767)
                    {
                        string keyName = Enum.GetName(typeof(Keys), i);
                        foundKey = (Keys)Enum.Parse(typeof(Keys), keyName, true);
                        found = true;

                        DialogResult dResult = MessageBox.Show($"Are you sure you would like to set your keybind to {foundKey}?", "Keybind", MessageBoxButtons.YesNo);

                        if (dResult == DialogResult.Yes)
                        {
                            return foundKey;
                        }
                        else
                        {
                            return Keys.None;
                        }
                    }
                }
            }
            return Keys.None;
        }

        public static void ListenForPress()
        {
            Dictionary<int, bool> keyStates = new Dictionary<int, bool>(); // Track the press state of each key

            while (true)
            {
                foreach (Macro m in SessionData.LoadedMacros)
                {
                    bool isKeyDown = (GetAsyncKeyState((int)m.Keybind) & 0x8000) != 0;
                    bool previouslyPressed = keyStates.TryGetValue((int)m.Keybind, out bool wasKeyDown) && wasKeyDown;

                    // Update the current state for next iteration
                    keyStates[(int)m.Keybind] = isKeyDown;

                    if (isKeyDown && !previouslyPressed && !SessionData.IsBuilding)
                    {
                        // Key is pressed now but wasn't before
                        if (SessionData.LoadedMacro == m)
                        {
                            SessionData.LoadedMacro = null;
                            SessionData.UpdateLabelText($"Loaded Macro: None");
                        }
                        else
                        {
                            SessionData.LoadedMacro = m;
                            SessionData.UpdateLabelText($"Loaded Macro: {m.MacroName}");
                        }

                        // Wait for the key to be released to reset the state
                        while ((GetAsyncKeyState((int)m.Keybind) & 0x8000) != 0)
                        {
                            Thread.Sleep(10); // Short sleep to reduce CPU usage and ensure the key release is detected
                        }
                        break; // Break the foreach loop to restart the polling cycle, ensuring fresh state evaluation
                    }
                }
                Thread.Sleep(1); // Reduce CPU usage by limiting polling rate
            }
        }


    }
}