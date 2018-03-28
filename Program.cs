using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Key_Logger___Not_bad_OK
{
    class Program
    {
        private static int counter = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    GlobalKeyboardHook gl = new GlobalKeyboardHook();
                    gl.KeyboardPressed += OnKeyPressed;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        private static void OnKeyPressed(object sender, GlobalKeyboardHookEventArgs e)
        {
            //Debug.WriteLine(e.KeyboardData.VirtualCode);

            if (e.KeyboardData.VirtualCode != GlobalKeyboardHook.VkSnapshot)
                return;

            // seems, not needed in the life.
            //if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.SysKeyDown &&
            //    e.KeyboardData.Flags == GlobalKeyboardHook.LlkhfAltdown)
            //{
            //    MessageBox.Show("Alt + Print Screen");
            //    e.Handled = true;
            //}
            //else

            if (e.KeyboardState == GlobalKeyboardHook.KeyboardState.KeyDown)
            {
                Console.WriteLine((counter++).ToString());
                Console.WriteLine("HardwareScanCode: " + e.KeyboardData.HardwareScanCode);
                Console.WriteLine("VirtualCode: " + e.KeyboardData.VirtualCode);
                Console.WriteLine("Flags: " + e.KeyboardData.Flags);
                Console.WriteLine("AdditionalInformation: " + e.KeyboardData.AdditionalInformation);
                e.Handled = true;
            }
        }
    }
}
