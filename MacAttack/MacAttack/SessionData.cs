using MacAttack.Macros;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MacAttack
{
    public class SessionData
    {
        public static List<Macro> LoadedMacros = new List<Macro>();
        public static bool IsBuilding = false;

        public static int BuilderX = 0;
        public static int BuilderY = 0;
        public static int BuilderSpeed = 0;
        public static string BuilderName = "";
        //public static string LabelText = "None";

        public static Macro LoadedMacro = null;

        public static event Action<string> LabelTextChanged;

        private static void OnLabelTextChanged(string newText)
        {
            LabelTextChanged?.Invoke(newText);
        }

        // Call this method when you want to change the label text
        public static void UpdateLabelText(string newText)
        {
            OnLabelTextChanged(newText);
        }
    }
}
