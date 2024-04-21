using System;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using MacAttack.ConfigFiles;
using MacAttack.Macros;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace MacAttack
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            JsonFunctions.LoadSessionData(this);

            XValueTextBox.KeyPress += XValueKeyPress_Handler;
            YValueTextBox.KeyPress += YValueKeyPress_Handler;
            SpeedTextBox.KeyPress += SpeedKeyPress_Handler;
            NameTextBox.KeyPress += NameKeyPress_Handler;

            Thread reoilThread = new Thread(Controller.RecoilWorker) { IsBackground = true };
            Thread listenerThread = new Thread(Binds.ListenForPress) { IsBackground = true };

            reoilThread.Start();
            listenerThread.Start();

            SessionData.LabelTextChanged += UpdateLabelSafe;
            SessionData.UpdateLabelText($"Loaded Macro: None");
        }

        private void UpdateLabelSafe(string text)
        {
            // Check if invoke is required due to cross-thread operation
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateLabelSafe), text);
            }
            else
            {
                // Update the label text safely on the UI thread
                loadedMacroLabel.Text = text;
            }
        }

        //MACROS CODE BELOW:

        private void CloseProgramButton_Click(object sender, EventArgs e)
        {
            //save loaded stuff here
            JsonFunctions.SaveSessionDetails();
            Environment.Exit(0);
        }

        private void MinimizeProgramButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void loadMacroButton_Click(object sender, EventArgs e)
        {
            Macro grabbedMacro = JsonFunctions.LoadMacro(false);

            if(grabbedMacro != null)
            {
                MetroTextBox tBox = new MetroTextBox();
                MetroButton keybindButton = new MetroButton();
                MetroButton removeButton = new MetroButton();

                tBox.Height = 20;
                tBox.Width = (int)(loadedMacrosPanel.ClientSize.Width * 0.3);
                tBox.Style = MetroColorStyle.Blue;
                tBox.Theme = MetroThemeStyle.Dark;
                tBox.Enabled = false;
                tBox.Text = grabbedMacro.MacroName;

                keybindButton.Text = $"Bind: {grabbedMacro.Keybind.ToString()}";
                keybindButton.Height = 20;
                keybindButton.Width = (int)(loadedMacrosPanel.ClientSize.Width * 0.35);
                keybindButton.Style = MetroColorStyle.Blue;
                keybindButton.Theme = MetroThemeStyle.Dark;

                removeButton.Text = "X";
                removeButton.Height = 20;
                removeButton.Width = (int)(loadedMacrosPanel.ClientSize.Width * 0.08);
                removeButton.Style = MetroColorStyle.Blue;
                removeButton.Theme = MetroThemeStyle.Dark;

                grabbedMacro.textBox = tBox;
                grabbedMacro.bindButton = keybindButton;
                grabbedMacro.removeButton = removeButton;

                //create id here:
                tBox.Name = $"TextBox_{grabbedMacro.MacroName}";
                keybindButton.Name = $"BindButton_{grabbedMacro.MacroName}";
                removeButton.Name = $"RemoveButton_{grabbedMacro.MacroName}";

                removeButton.Click += RemoveButton_Click;
                keybindButton.Click += KeybindButton_Click;

                loadedMacrosPanel.Controls.Add(tBox);
                loadedMacrosPanel.Controls.Add(keybindButton);
                loadedMacrosPanel.Controls.Add(removeButton);

                SessionData.LoadedMacros.Add(grabbedMacro);
            }
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            MetroButton clickedButton = (MetroButton)sender;

            Macro macroToRemove = GetMacroFromButton(clickedButton);

            if (macroToRemove != null)
            {
                loadedMacrosPanel.Controls.Remove(macroToRemove.textBox);
                loadedMacrosPanel.Controls.Remove(macroToRemove.bindButton);
                loadedMacrosPanel.Controls.Remove(macroToRemove.removeButton);
                SessionData.LoadedMacros.Remove(macroToRemove);
                SessionData.LoadedMacro = null;
            }
        }

        private void KeybindButton_Click(object sender, EventArgs e)
        {
            MetroButton clickedButton = (MetroButton)sender;

            Macro keybindToChange = GetMacroFromButton(clickedButton);

            if (keybindToChange != null)
            {
                Keys grabbedKey = Binds.GetKey();

                if (grabbedKey != Keys.None)
                {
                    keybindToChange.Keybind = grabbedKey;
                    clickedButton.Text = $"Bind: {grabbedKey}";
                }
                else
                {
                    clickedButton.Text = $"Bind: None";
                }
            }
        }

        private Macro GetMacroFromButton(MetroButton button)
        {
            string name = Convert.ToString(button.Name);
            string[] parts = name.Split('_');
            if (parts.Length > 1)
            {
                string foundName = parts[1];
                foreach(Macro m in SessionData.LoadedMacros)
                {
                    if(m.MacroName == foundName)
                    {
                        return m;
                    }
                }
            }
            return null;
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = tabControl.SelectedIndex;

            switch(idx)
            {
                case 0:
                    //normal macro page
                    SessionData.IsBuilding = false;
                    break;
                case 1:
                    //builder page
                    SessionData.IsBuilding = true;
                    break;
            }
        }

        //BUILDER CODE BELOW:
        private bool IsTextBoxNumberic(MetroTextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
                return false;

            int parsedValue;
            bool isNumeric = int.TryParse(textBox.Text, out parsedValue);

            return isNumeric;
        }

        private void XValueKeyPress_Handler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void YValueKeyPress_Handler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void SpeedKeyPress_Handler(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
        }

        private void NameKeyPress_Handler(object sender, KeyPressEventArgs e)
        {
            SessionData.BuilderName = NameTextBox.Text;
        }

        private void saveConfigButton_Click(object sender, EventArgs e)
        {
            if (IsTextBoxNumberic(XValueTextBox) && IsTextBoxNumberic(YValueTextBox) && IsTextBoxNumberic(SpeedTextBox))
            {
                SessionData.BuilderX = Convert.ToInt32(XValueTextBox.Text);
                SessionData.BuilderY = Convert.ToInt32(YValueTextBox.Text);
                SessionData.BuilderSpeed = Convert.ToInt32(SpeedTextBox.Text);
                SessionData.BuilderName = NameTextBox.Text;

                JsonFunctions.SaveMacro();
            }
        }

        private void setBuilderData_Click(object sender, EventArgs e)
        {
            if(IsTextBoxNumberic(XValueTextBox) && IsTextBoxNumberic(YValueTextBox) && IsTextBoxNumberic(SpeedTextBox))
            {
                SessionData.BuilderX = Convert.ToInt32(XValueTextBox.Text);
                SessionData.BuilderY = Convert.ToInt32(YValueTextBox.Text);
                SessionData.BuilderSpeed = Convert.ToInt32(SpeedTextBox.Text);
                SessionData.BuilderName = NameTextBox.Text;
            }
        }

        public void CreateButtons(Macro grabbedMacro)
        {
            MetroTextBox tBox = new MetroTextBox();
            MetroButton keybindButton = new MetroButton();
            MetroButton removeButton = new MetroButton();

            tBox.Height = 20;
            tBox.Width = (int)(loadedMacrosPanel.ClientSize.Width * 0.3);
            tBox.Style = MetroColorStyle.Blue;
            tBox.Theme = MetroThemeStyle.Dark;
            tBox.Enabled = false;
            tBox.Text = grabbedMacro.MacroName;

            keybindButton.Text = $"Bind: {grabbedMacro.Keybind.ToString()}";
            keybindButton.Height = 20;
            keybindButton.Width = (int)(loadedMacrosPanel.ClientSize.Width * 0.35);
            keybindButton.Style = MetroColorStyle.Blue;
            keybindButton.Theme = MetroThemeStyle.Dark;

            removeButton.Text = "X";
            removeButton.Height = 20;
            removeButton.Width = (int)(loadedMacrosPanel.ClientSize.Width * 0.08);
            removeButton.Style = MetroColorStyle.Blue;
            removeButton.Theme = MetroThemeStyle.Dark;

            grabbedMacro.textBox = tBox;
            grabbedMacro.bindButton = keybindButton;
            grabbedMacro.removeButton = removeButton;

            //create id here:
            tBox.Name = $"TextBox_{grabbedMacro.MacroName}";
            keybindButton.Name = $"BindButton_{grabbedMacro.MacroName}";
            removeButton.Name = $"RemoveButton_{grabbedMacro.MacroName}";

            removeButton.Click += RemoveButton_Click;
            keybindButton.Click += KeybindButton_Click;

            loadedMacrosPanel.Controls.Add(tBox);
            loadedMacrosPanel.Controls.Add(keybindButton);
            loadedMacrosPanel.Controls.Add(removeButton);

            SessionData.LoadedMacros.Add(grabbedMacro);
        }

        public void SetToggledLabel(string name)
        {
            loadedMacroLabel.Text = $"Loaded Macro: {name}";
        }

        private void editConfigButton_Click(object sender, EventArgs e)
        {
            Macro loadedMacro = JsonFunctions.LoadMacro(true);
            if (loadedMacro != null)
            {
                XValueTextBox.Text = Convert.ToString(loadedMacro.XValue);
                YValueTextBox.Text = Convert.ToString(loadedMacro.YValue);
                SpeedTextBox.Text = Convert.ToString(loadedMacro.Speed);
                NameTextBox.Text = loadedMacro.MacroName;

                SessionData.BuilderX = loadedMacro.XValue;
                SessionData.BuilderY = loadedMacro.YValue;
                SessionData.BuilderSpeed = loadedMacro.Speed;
                SessionData.BuilderName = loadedMacro.MacroName;
            }
        }
    }
}