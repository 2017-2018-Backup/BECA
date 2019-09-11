using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageView
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ImageView());
        }
    }

    public class AcadCommands
    {
        [CommandMethod("CreateImage")]
        public void CreateImage()
        {
            ImageView imageview = new ImageView();
            imageview.Show();
        }
    }
}
