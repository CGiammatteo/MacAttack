using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace MacAttack.Macros
{
    internal class Controller
    {
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, uint dwData, UIntPtr dwExtraInfo);

        public static void RecoilWorker()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.LButton) < 0 && GetAsyncKeyState(Keys.RButton) < 0)
                {
                    while (GetAsyncKeyState(Keys.LButton) < 0)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            if(SessionData.IsBuilding == false && SessionData.LoadedMacro != null)
                            {
                                mouse_event(0x0001, SessionData.LoadedMacro.XValue, SessionData.LoadedMacro.YValue, 0, UIntPtr.Zero);
                                Thread.Sleep(SessionData.LoadedMacro.Speed);
                            }
                            else if(SessionData.IsBuilding == true)
                            {
                                mouse_event(0x0001, SessionData.BuilderX, SessionData.BuilderY, 0, UIntPtr.Zero);
                                Thread.Sleep(SessionData.BuilderSpeed);
                            }
                        }
                    }
                }
                Thread.Sleep(1);
            }
        }
    }
}