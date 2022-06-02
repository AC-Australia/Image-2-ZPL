using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace TestZPL
{
    static class Program
    {
        private static Bitmap imageToConvert;
        private static string test;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            if (args == null || args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TestZPL());
            } else
            {
                string[] files = Directory.GetFiles($@"{args[0]}", $"*.{args[1]}");
                foreach (var file in files)
                {
                    imageToConvert = (Bitmap)Bitmap.FromFile(file);
                    test = Image2ZPL.Convert.BitmapToZPLII(imageToConvert, 20, 20);
                    File.WriteAllText(args[0] + @"\test.zpl", test);
                }
            }
            
        
        }
    }
}
