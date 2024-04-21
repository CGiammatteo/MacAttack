using System.Windows.Forms;
using MetroFramework.Controls;

namespace MacAttack.Macros
{
    public class Macro
    {
        public MetroButton bindButton { get; set; }
        public MetroButton removeButton { get; set; }
        public MetroTextBox textBox { get; set; }

        public Keys Keybind = Keys.None;
        public int XValue = 0;
        public int YValue = 0;
        public int Speed = 0;
        public string MacroName = "";
        public string FileLocation = "";

        public int MacroId { get; set; }
    }
}