using Autodesk.AutoCAD.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;

namespace BecaUserInterface
{
    public class Class1 : IExtensionApplication
    {
        public void Initialize()
        {
            if (Autodesk.AutoCAD.ApplicationServices.Application.Version.Major >= 23)//only till 2018
            {
                Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                Database db = doc.Database;
                Editor ed = doc.Editor;
                ed.WriteMessage("\nCADSymUserInterface.dll is incompatible with this version of AutoCAD.");
                throw new NotImplementedException();
            }
        }
        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}
