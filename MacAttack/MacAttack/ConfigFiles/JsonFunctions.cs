using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MacAttack.Macros;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MacAttack.ConfigFiles
{
    internal class JsonFunctions
    {
        public static Macro LoadMacro(bool isBuilder)
        {
            Macro loadedMacro = new Macro();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (!Directory.Exists(AppContext.BaseDirectory + @"\macros"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + @"\macros");
            }

            openFileDialog1.InitialDirectory = AppContext.BaseDirectory + @"\macros";
            openFileDialog1.Filter = "Json files (*.json)|*.json";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = openFileDialog1.FileName;

                    dynamic macFile = JsonConvert.DeserializeObject(File.ReadAllText(selectedFileName));

                    loadedMacro.XValue = Convert.ToInt32(macFile["X"]);
                    loadedMacro.YValue = Convert.ToInt32(macFile["Y"]);
                    loadedMacro.MacroName = Path.GetFileNameWithoutExtension(selectedFileName);
                    loadedMacro.Speed = Convert.ToInt32(macFile["Speed"]);
                    loadedMacro.Keybind = Keys.None;
                    loadedMacro.FileLocation = openFileDialog1.FileName;

                    if(isBuilder == false)
                    {
                        foreach (Macro m in SessionData.LoadedMacros)
                        {
                            if (m.MacroName == loadedMacro.MacroName)
                            {
                                MessageBox.Show("Cannot load an already loaded macro.");
                                return null;
                            }
                        }
                    }
                    return loadedMacro;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return null;
        }

        public static void SaveMacro()
        {
            if (!Directory.Exists(AppContext.BaseDirectory + @"\macros"))
            {
                Directory.CreateDirectory(AppContext.BaseDirectory + @"\macros");
            }

            if (File.Exists(AppContext.BaseDirectory + $@"\macros\{SessionData.BuilderName}.json"))
            {
                File.Delete(AppContext.BaseDirectory + $@"\macros\{SessionData.BuilderName}.json");
            }

            using (StreamWriter file = File.CreateText(AppContext.BaseDirectory + $@"\macros\{SessionData.BuilderName}.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                JObject macroData = new JObject(
                    new JProperty("X", SessionData.BuilderX),
                    new JProperty("Y", SessionData.BuilderY),
                    new JProperty("Speed", SessionData.BuilderSpeed));

                serializer.Serialize(file, macroData);

                MessageBox.Show($"Created {SessionData.BuilderName} config successfully!");
            }
        }
        public static void LoadSessionData(MainForm form)
        {
            if (File.Exists(AppContext.BaseDirectory + @"SessionDetails.json"))
            {
                dynamic sessionData = JsonConvert.DeserializeObject(File.ReadAllText(AppContext.BaseDirectory + @"SessionDetails.json"));

                foreach(JObject obj in sessionData)
                {
                    string path = Convert.ToString(obj["Location"]);
                    Keys keybind = (Keys)Enum.Parse(typeof(Keys), obj["Keybind"].ToString());

                    if (File.Exists(path))
                    {
                        Macro loadedMacro = new Macro();
                        dynamic macFile = JsonConvert.DeserializeObject(File.ReadAllText(path));

                        loadedMacro.XValue = Convert.ToInt32(macFile["X"]);
                        loadedMacro.YValue = Convert.ToInt32(macFile["Y"]);
                        loadedMacro.MacroName = Path.GetFileNameWithoutExtension(path);
                        loadedMacro.Speed = Convert.ToInt32(macFile["Speed"]);
                        loadedMacro.Keybind = keybind;
                        loadedMacro.FileLocation = path;

                        form.CreateButtons(loadedMacro);
                    }
                }
            }
        }

        public static void SaveSessionDetails()
        {
            if (File.Exists(AppContext.BaseDirectory + @"SessionDetails.json"))
                File.Delete(AppContext.BaseDirectory + @"SessionDetails.json");

            using (StreamWriter file = File.CreateText(AppContext.BaseDirectory + @"SessionDetails.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                JArray macroData = new JArray();

                foreach (Macro m in SessionData.LoadedMacros)
                {
                    macroData.Add(new JObject(
                        new JProperty("Location", m.FileLocation),
                        new JProperty("Keybind", m.Keybind.ToString())));
                }
                serializer.Serialize(file, macroData);
            }
        }
    }
}