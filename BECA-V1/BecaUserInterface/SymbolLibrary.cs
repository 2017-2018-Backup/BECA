using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using System.Drawing.Imaging;
using Autodesk.AutoCAD.Geometry;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace BecaUserInterface
{
    public partial class SymbolLibrary : Form
    {
        private string _typeofSign = string.Empty;
        AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
        BasicCivilCustomization basicCivilCustom = new BasicCivilCustomization();
        string dirPath = string.Empty;
        // string settingsFilePath = string.Empty;
        string signsDrawingPath = string.Empty;
        string xmlPath = string.Empty;

        string path = "";
        string SVOption = "";
        string imagePath = "";//15-04-2018
                              // string BaseImagePath = "";
        public SymbolLibrary(string region, string typeofSign = "", string xmlName = "")
        {
            InitializeComponent();
            DateTime dtmNow = DateTime.Now;

            //if (dtmNow.Day <= 31 && dtmNow.Year <= 2017 && dtmNow.Month <= 06)
            {

                _typeofSign = typeofSign;
                acsc = new AutoCompleteStringCollection();
                txtSearch.AutoCompleteCustomSource = acsc;
                txtSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                dirPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                dirPath = dirPath.Substring(0, dirPath.LastIndexOf("\\"));
                //settingsFilePath = Path.Combine(dirPath, "Settings.ini");
                //if (System.IO.File.Exists(settingsFilePath))
                //{
                //    try
                //    {
                //        IniFile iniFile = new IniFile(settingsFilePath);
                //        BaseImagePath = iniFile.IniReadValue("setting", "ImagePath");
                //    }
                //    catch { }
                //}
                //IniFile iniFile = new IniFile(settingsFilePath);
                //signsDrawingPath =iniFile.IniReadValue("New Zealand", "Signs");

                if (String.IsNullOrWhiteSpace(_typeofSign))
                {
                    MessageBox.Show("Type not found");
                    return;
                }

                try
                {
                    //Code to read path from lisp 
                    // signsDrawingPath = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.GetLispSymbol("B:SYM").ToString();

                    //Autodesk.AutoCAD.Internal.Utils.GetLastCommandLines(10, true);

                    Editor ed = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument.Editor;
                    PromptResult pr = ed.GetString("Path:");

                    if (pr.Status == PromptStatus.OK)
                    {
                        path = pr.StringResult;
                    }

                    try
                    {
                        PromptResult PRSVOPtion = ed.GetString("SV");
                        if (PRSVOPtion.Status == PromptStatus.OK)
                        {
                            SVOption = PRSVOPtion.StringResult;
                        }


                        //PromptResult PRImagePath = ed.GetString("ImagePath");
                        //if (PRImagePath.Status == PromptStatus.OK)
                        //{
                        //    imagePath = PRImagePath.StringResult;
                        //    //if (BaseImagePath.Length > 0)//Add Base path if exists
                        //    //    imagePath = System.IO.Path.Combine(BaseImagePath, imagePath);
                        //}
                    }
                    catch { }

                    //17-05-2018
                    //if (SVOption.Equals("SV-ON", StringComparison.InvariantCultureIgnoreCase))
                    //{
                    //    chkScale.Checked = true;
                    //}
                    //else
                    //{
                    //    chkScale.Checked = false;
                    //}
                    if (!string.IsNullOrEmpty(path))
                    {

                        //Added on 24-10-2017 to remove multiple commands, if the last folder is signs then it is signs if not it is road markings
                        //string dirName = Path.GetFileName(path.TrimEnd(Path.DirectorySeparatorChar));
                        //if (dirName.Equals("Signs"))
                        //    _typeofSign = "Signs";
                        //else
                        //    _typeofSign = "RoadMarkings";

                        if (region.Equals("NZ", StringComparison.InvariantCultureIgnoreCase) || region.Equals("New Zealand", StringComparison.InvariantCultureIgnoreCase))
                        {
                            region = "New Zealand";
                            xmlName = "B-Civil.xml";
                        }
                        else if (region.Equals("Aus", StringComparison.InvariantCultureIgnoreCase) || region.Equals("Australia", StringComparison.InvariantCultureIgnoreCase))
                        {
                            region = "Australia";
                            xmlName = "B-Civil_AU.xml";
                        }
                        else if (region.Equals("SG", StringComparison.InvariantCultureIgnoreCase) || region.Equals("Singapore", StringComparison.InvariantCultureIgnoreCase))
                        {
                            region = "Singapore";
                            xmlName = "B-Civil_SG.xml";
                        }

                        //foreach (string strDir in path.Split('/'))
                        //{
                        //    if (strDir.Equals("NZ", StringComparison.InvariantCultureIgnoreCase))
                        //    {
                        //        region = "New Zealand";
                        //        xmlName = "B-Civil.xml";
                        //        break;
                        //    }
                        //    else if (strDir.Equals("Aus", StringComparison.InvariantCultureIgnoreCase) || strDir.Equals("Australia", StringComparison.InvariantCultureIgnoreCase))
                        //    {
                        //        region = "Australia";
                        //        xmlName = "B-Civil_AU.xml";
                        //        break;
                        //    }
                        //    else if (strDir.Equals("SG", StringComparison.InvariantCultureIgnoreCase) || strDir.Equals("Singapore", StringComparison.InvariantCultureIgnoreCase))
                        //    {
                        //        region = "Singapore";
                        //        xmlName = "B-Civil_SG.xml";
                        //        break;
                        //    }
                        //}

                        signsDrawingPath = path;
                    }


                    if (string.IsNullOrEmpty(signsDrawingPath))
                    {
                        MessageBox.Show("Invalid drawing path");
                        Environment.Exit(-1);
                    }
                    else if (!System.IO.Directory.Exists(signsDrawingPath))
                    {
                        MessageBox.Show(signsDrawingPath + " - Path does not exist");
                        Environment.Exit(-1);
                    }
                    else if (string.IsNullOrEmpty(region))
                    {
                        MessageBox.Show("Region not recognizable in the folder path");
                        Environment.Exit(-1);
                    }
                    //15-04-2018
                    //if (string.IsNullOrEmpty(imagePath))
                    //    MessageBox.Show("Image path not found");
                    //else if (!System.IO.Directory.Exists(imagePath))
                    //    MessageBox.Show("Invalid Image path");

                    //30-05-2018
                    //Read the below from CUIX
                    //xmlPath = Path.Combine(dirPath, xmlName);// "NZSigns.xml");
                    //if (!System.IO.File.Exists(xmlPath))
                    //    MessageBox.Show(xmlName + " - XML file not found");
                }
                catch (Exception ex)
                {
                    signsDrawingPath = "";
                    MessageBox.Show("Invalid drawing path - " + ex.ToString());
                }

                txtRegion.Text = region;
                lblSigns.Text = _typeofSign;
            }
        }

        List<string> dwgfileList = new List<string>();
        private void SymbolLibrary_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(signsDrawingPath))
            {
                if (System.IO.Directory.Exists(signsDrawingPath))
                {
                    try
                    {
                        Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                        Database db = doc.Database;
                        // doc.SendStringToExecute("(" + SVOption + ") ", false, false, false);//17-05-2018
                    }
                    catch { }
                    dwgfileList = new List<string>();
                    dwgfileList = getAllDrawingFromFolder(signsDrawingPath);
                    LoadSigns();
                }
            }
        }

        private List<String> getAllDrawingFromFolder(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    if (System.IO.Path.GetExtension(f).EndsWith("dwg", StringComparison.InvariantCultureIgnoreCase))
                        files.Add(System.IO.Path.GetFileName(f));
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(getAllDrawingFromFolder(d));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        private void LoadSigns()
        {
            //30-05-2018
            //if (File.Exists(xmlPath))
            //{
            //    basicCivilCustom = Extension.Create(xmlPath);//Path.Combine(dirPath, "NZSigns.xml")
            //}
            //else
            //    basicCivilCustom = null;

            List<CivilCustomization> _civil = new List<CivilCustomization>();

            foreach (string str in Directory.GetFiles(signsDrawingPath, "*.xml", SearchOption.AllDirectories))
            {
                try
                {
                    basicCivilCustom = new BasicCivilCustomization();
                    basicCivilCustom = Extension.Create(str);
                    _civil.AddRange(basicCivilCustom.CivilCustomization);
                }
                catch { }
            }
            basicCivilCustom = new BasicCivilCustomization();
            basicCivilCustom.CivilCustomization = _civil;

            loadDWGFilesToList();

            if (!cmboDescription.Items.Contains("--Select--"))
                cmboDescription.Items.Insert(0, "--Select--");
            cmboDescription.SelectedIndex = 0;
            //16-04-2018
            //lstDescription.SelectedIndexChanged -= lstDescription_SelectedIndexChanged;
            //lstDescription.SelectedIndex = -1;
            //lstDescription.SelectedIndexChanged += lstDescription_SelectedIndexChanged;
        }

        private void loadDWGFilesToList()
        {
            foreach (string strDwg in dwgfileList)
            {
                string dwgName = System.IO.Path.GetFileName(strDwg);
                lstSigns.Items.Add(dwgName.Replace(".dwg", ""));
                acsc.Add(dwgName.Replace(".dwg", ""));
                try
                {
                    if (basicCivilCustom != null)
                    {
                        List<CivilCustomization> result = basicCivilCustom.CivilCustomization.Where(x => x.Type.Equals(_typeofSign, StringComparison.InvariantCultureIgnoreCase) && x.Region.Equals(txtRegion.Text, StringComparison.InvariantCultureIgnoreCase) && x.DrawingName.Equals(dwgName, StringComparison.InvariantCultureIgnoreCase)).ToList();

                        if (result.Count > 0)
                        {
                            CivilCustomization x = result.FirstOrDefault();
                            // lstSigns.Items.Add(x.DrawingName.Replace(".dwg", ""));
                            //acsc.Add(x.DrawingName.Replace(".dwg", ""));
                            if (cmboDescription.Items.Count == 0)
                            {
                                cmboDescription.Items.Add(x.Description);
                                lstDescription.Items.Add(x.Description);
                            }
                            else
                            {
                                var cmboItem = cmboDescription.Items.OfType<object>().ToList().Where(y => y.ToString().Equals(x.Description, StringComparison.InvariantCultureIgnoreCase)).Select(y => y).FirstOrDefault();
                                if (cmboItem == null)
                                {
                                    cmboDescription.Items.Add(x.Description);
                                    lstDescription.Items.Add(x.Description);
                                }
                            }
                        }
                    }
                }
                catch { }
            }
            if (lstSigns.Items.Count <= 1)
                lblMatches.Text = lstSigns.Items.Count + " match found";
            else
                lblMatches.Text = lstSigns.Items.Count + " matches found";

            if (lstDescription.Items.Count <= 1)
                lblDescriptionMatches.Text = lstDescription.Items.Count + " match found";
            else
                lblDescriptionMatches.Text = lstDescription.Items.Count + " matches found";


            //16-04-2018 // lstSigns.SelectedIndex = lstSigns.Items.Count > 0 ? 0 : -1;
        }

        //private void LoadSigns()
        //{
        //    if (File.Exists(xmlPath))
        //    {
        //        basicCivilCustom = Extension.Create(xmlPath);//Path.Combine(dirPath, "NZSigns.xml")
        //        if (basicCivilCustom != null)
        //        {
        //            basicCivilCustom.CivilCustomization.ForEach(x =>
        //            {
        //                if (x.Type == _typeofSign && x.Region.Equals(txtRegion.Text))
        //                {
        //                    if (dwgfileList.Contains(x.DrawingName)) //Check whether the drawing available in folder
        //                    {
        //                        lstSigns.Items.Add(x.DrawingName.Replace(".dwg", ""));
        //                        acsc.Add(x.DrawingName.Replace(".dwg", ""));
        //                        if (cmboDescription.Items.Count == 0)
        //                        {
        //                            cmboDescription.Items.Add(x.Description);
        //                            lstDescription.Items.Add(x.Description);
        //                        }
        //                        else
        //                        {
        //                            var cmboItem = cmboDescription.Items.OfType<object>().ToList().Where(y => y.ToString().Equals(x.Description)).Select(y => y).FirstOrDefault();
        //                            if (cmboItem == null)
        //                            {
        //                                cmboDescription.Items.Add(x.Description);
        //                                lstDescription.Items.Add(x.Description);
        //                            }
        //                        }
        //                    }
        //                }
        //            });
        //            lblMatches.Text = lstSigns.Items.Count + " matches found";
        //            lblDescriptionMatches.Text = lstDescription.Items.Count + " matches found";
        //            lstSigns.SelectedIndex = lstSigns.Items.Count > 0 ? 0 : -1;
        //            if (!cmboDescription.Items.Contains("--Select--"))
        //                cmboDescription.Items.Insert(0, "--Select--");
        //            cmboDescription.SelectedIndex = 0;
        //            lstDescription.SelectedIndexChanged -= lstDescription_SelectedIndexChanged;
        //            lstDescription.SelectedIndex = -1;
        //            lstDescription.SelectedIndexChanged += lstDescription_SelectedIndexChanged;
        //        }
        //    }
        //}

        bool executeEvent = true;
        private void lstSigns_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!executeEvent) return;
            //03-May-2018
            if (lstDescription.SelectedItems.Count <= 0)
            {
                //select relevant description
                lstDescription.SelectedIndexChanged -= lstDescription_SelectedIndexChanged;
                try
                {
                    var selectedItem = lstSigns.Items[lstSigns.SelectedIndex];
                    var lst = basicCivilCustom.CivilCustomization.Where(x => x.DrawingName.Replace(".dwg", "").Equals(selectedItem)).Select(x => x.Description).ToList();
                    if (lst == null || lst.Count == 0)
                    {

                    }
                    else
                    {
                        executeEvent = false;
                        lstDescription.SelectedItem = lst[0];
                        lstDescription_SelectedIndexChanged(null, null);
                        lstSigns.SelectedItem = selectedItem;
                    }
                }
                catch { }
                lstDescription.SelectedIndexChanged += lstDescription_SelectedIndexChanged;
                executeEvent = true;
            }
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            using (Transaction acTrans = db.TransactionManager.StartTransaction())
            {

                BlockTable bt = (BlockTable)db.BlockTableId.GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);

                //15-04-2018
                // if (!Directory.Exists(imagePath))// @"C:\Temp\BasicCivil\"))
                //{
                //   Directory.CreateDirectory(imagePath);//@"C:\Temp\BasicCivil\");
                // }
                //if (!File.Exists(System.IO.Path.Combine(imagePath, lstSigns.SelectedItem + ".jpg")))//@"C:\Temp\BasicCivil\" + lstSigns.SelectedItem + ".jpg"))
                //{
                //    CreatePreviewImage(Path.Combine(signsDrawingPath, lstSigns.SelectedItem + ".dwg"));
                //}

                try
                {

                    loadFile(Path.Combine(signsDrawingPath, lstSigns.SelectedItem + ".dwg"));

                    //picBxPreview.Image = System.Drawing.Image.FromFile(System.IO.Path.Combine(imagePath, lstSigns.SelectedItem + ".jpg"));// @"C:\Temp\BasicCivil\" + lstSigns.SelectedItem + ".jpg");
                    //picBxPreview.SizeMode = PictureBoxSizeMode.AutoSize;
                    // = ImageLayout.Center;
                }
                catch
                {

                }

                acTrans.Commit();
            }
        }
        //15-04-2018
        //private void CreatePreviewImage(string dwgPath)
        //{
        //    try
        //    {
        //        Document activeDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
        //        Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.Open(dwgPath);
        //        using (doc.LockDocument())
        //        {
        //            using (Bitmap bmapImage = doc.CapturePreviewImage((uint)236, (uint)277))
        //            {
        //                bmapImage.Save(System.IO.Path.Combine(imagePath, lstSigns.SelectedItem + ".jpg"), ImageFormat.Jpeg);// @"C:\Temp\BasicCivil\" + lstSigns.SelectedItem + ".jpg", ImageFormat.Jpeg);
        //            }
        //        }
        //        Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument = activeDoc;
        //        doc.CloseAndDiscard();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        private void btnCacnel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private ObjectId CheckBlockwithDrawingNameExists(string path)
        {
            ObjectId returnObjectId = default(ObjectId);
            Database sourceDb = new Database(false, true);
            sourceDb.ReadDwgFile(path, FileShare.Read, true, "");
            Autodesk.AutoCAD.DatabaseServices.TransactionManager transMan = sourceDb.TransactionManager;
            using (Transaction trans = transMan.StartTransaction())
            {
                BlockTable bt = (BlockTable)trans.GetObject(sourceDb.BlockTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead, false);
                foreach (ObjectId btrId in bt)
                {
                    BlockTableRecord btr = (BlockTableRecord)trans.GetObject(btrId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead, false);
                    if (btr.Name.Equals(lstSigns.SelectedItem))
                    {
                        returnObjectId = btrId;
                        trans.Commit();
                        break;
                    }
                }
            }
            return returnObjectId;
        }

        public void InsertDwg(string fname)
        {
            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            Database db = doc.Database;
            Editor ed = doc.Editor;

            // doc.GetLispSymbol("SF");
            doc.GetLispSymbol("B:SYM-CIVIL");

            bool loop = true;

            // string fname = "C:\\Users\\Jeff\\Documents\\Drawing1.dwg";
            while (loop)
            {
                ObjectId ObjId = default(ObjectId);
                using (doc.LockDocument())
                {
                    using (Transaction trx = db.TransactionManager.StartTransaction())
                    {
                        BlockTable bt = (BlockTable)db.BlockTableId.GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead);
                        //BlockTableRecord btrMs = (BlockTableRecord)bt[BlockTableRecord.ModelSpace].GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite);

                        BlockTableRecord btrMs = trx.GetObject(db.CurrentSpaceId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) as BlockTableRecord;


                        using (Database dbInsert = new Database(false, true))
                        {
                            dbInsert.ReadDwgFile(fname, System.IO.FileShare.Read, true, "");
                            ObjId = CheckBlockwithDrawingNameExists(fname);
                            if (ObjId.IsNull)
                                ObjId = db.Insert(Path.GetFileNameWithoutExtension(fname), dbInsert, true);
                        }
                        PromptPointOptions ppo = new PromptPointOptions(Constants.vbCrLf + "Insertion Point");
                        PromptPointResult ppr = default(PromptPointResult);
                        ppr = ed.GetPoint(ppo);
                        if (ppr.Status != PromptStatus.OK)
                        {
                            ed.WriteMessage(Constants.vbCrLf + "You decided to QUIT!");
                            trx.Abort();
                            loop = false;
                            return;
                        }
                        Point3d insertPt = ppr.Value;
                        BlockReference bref = new BlockReference(insertPt, ObjId);
                        //bref.TransformBy(Matrix3d.Scaling(10, insertPt));
                        btrMs.AppendEntity(bref);
                        trx.AddNewlyCreatedDBObject(bref, true);
                        trx.Commit();
                    }
                }

                //loop = false;
            }
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (lstSigns.SelectedItem == null)
                return;

            //17-05-2018
            //try
            // {
            //Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //if (chkScale.Checked == true)
            //    doc.SendStringToExecute("(SV-ON) ", false, false, false);
            //else
            //    doc.SendStringToExecute("(SV-OFF) ", false, false, false);
            //}
            //catch { }

            if (File.Exists(Path.Combine(signsDrawingPath, lstSigns.SelectedItem + ".dwg")))
                InsertDwg(Path.Combine(signsDrawingPath, lstSigns.SelectedItem + ".dwg"));
            else
                MessageBox.Show("File not found");

            Close();
            return;
            #region commented
            //DocumentCollection dm = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager;
            //Database db = dm.MdiActiveDocument.Database;
            //Database sourceDb = new Database(false, true);
            //using (dm.MdiActiveDocument.LockDocument())
            //{
            //    sourceDb.ReadDwgFile(Path.Combine(signsDrawingPath, lstSigns.SelectedItem + ".dwg"), FileShare.Read, true, "");
            //    ObjectIdCollection objectIdColl = new ObjectIdCollection();
            //    Autodesk.AutoCAD.DatabaseServices.TransactionManager transMan = sourceDb.TransactionManager;
            //    using (Transaction trans = transMan.StartTransaction())
            //    {
            //        BlockTable bt = (BlockTable)trans.GetObject(sourceDb.BlockTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead, false);
            //        foreach (ObjectId btrId in bt)
            //        {
            //            BlockTableRecord btr = (BlockTableRecord)trans.GetObject(btrId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead, false);
            //            if (btr.Name.Equals(lstSigns.SelectedItem))
            //            {
            //                objectIdColl.Add(btrId);
            //                btr.Dispose();
            //                break;
            //            }
            //        }
            //    }

            //    IdMapping idMap = new IdMapping();
            //    sourceDb.WblockCloneObjects(objectIdColl, db.BlockTableId, idMap, DuplicateRecordCloning.Replace, false);
            //    sourceDb.Dispose();
            //    if (objectIdColl.Count == 0)
            //        return;
            //    using (Transaction trans = db.TransactionManager.StartTransaction())
            //    {
            //        BlockTable bt = (BlockTable)trans.GetObject(db.BlockTableId, Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead, false);
            //        BlockTableRecord btr = bt[lstSigns.SelectedItem.ToString()].GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForRead) as BlockTableRecord;
            //        BlockTableRecord ms = bt[BlockTableRecord.ModelSpace].GetObject(Autodesk.AutoCAD.DatabaseServices.OpenMode.ForWrite) as BlockTableRecord;
            //        if (btr != null)
            //        {
            //            PlaceBlock pb = new PlaceBlock();
            //            Point3d point;
            //            Hide();
            //            PromptResult prompRes = pb.DragMe(btr.Id, out point);
            //            if (prompRes.Status == PromptStatus.OK)
            //            {
            //                using (BlockReference bref = new BlockReference(point, btr.ObjectId))
            //                {
            //                    ms.AppendEntity(bref);
            //                    trans.AddNewlyCreatedDBObject(bref, true);
            //                }
            //            }
            //            Show();
            //        }
            //        trans.Commit();
            //    }
            //}
            #endregion  
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
                return;

            try
            {
                if (txtSearch.Text.Equals("*", StringComparison.InvariantCultureIgnoreCase))//added on 22-10-2017
                {
                    lstSigns.Items.Clear();
                    lstDescription.Items.Clear();
                    loadDWGFilesToList();//Added on 22-Oct-2017
                    return;
                }
                else if (txtSearch.Text.Contains("*"))
                {
                    //var lstDrawings = basicCivilCustom.CivilCustomization.Where(x => Operators.LikeString(x.DrawingName, txtSearch.Text, CompareMethod.Text)).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();
                    //if (lstDrawings == null || lstDrawings.Count == 0)
                    //{
                    //    lstDrawings = basicCivilCustom.CivilCustomization.Where(x => Operators.LikeString(x.Description, txtSearch.Text, CompareMethod.Text)).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();
                    //} //20-09-2018, Description should include filter search
                    var lstDrawings = basicCivilCustom.CivilCustomization.Where(x => Operators.LikeString(x.DrawingName, txtSearch.Text, CompareMethod.Text)).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();


                    var lstDescs = basicCivilCustom.CivilCustomization.Where(x => Operators.LikeString(x.Description, txtSearch.Text, CompareMethod.Text)).Select(x => x.Description).ToList();

                    AddDrawingsFromSearch(lstDrawings, lstDescs);
                    return;
                }
                //// var lst = basicCivilCustom.CivilCustomization.Where(x => x.DrawingName.Replace(".dwg", "").ToUpper().StartsWith(txtSearch.Text.ToUpper())).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();
                //var lst = basicCivilCustom.CivilCustomization.Where(x => x.DrawingName.Replace(".dwg", "").ToUpper().Contains(txtSearch.Text.ToUpper())).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();

                //if (lst == null || lst.Count == 0)
                //{
                //    lst = basicCivilCustom.CivilCustomization.Where(x => x.Description.ToUpper().Contains(txtSearch.Text.ToUpper())).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();
                //}//20-09-2018, Description should include filter search
                var lst = basicCivilCustom.CivilCustomization.Where(x => x.DrawingName.Replace(".dwg", "").ToUpper().Contains(txtSearch.Text.ToUpper())).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();

                var lstDesc = basicCivilCustom.CivilCustomization.Where(x => x.Description.ToUpper().Contains(txtSearch.Text.ToUpper())).Select(x => x.DrawingName).ToList();

                AddDrawingsFromSearch(lst, lstDesc);
            }
            catch { }
        }

        private void AddDrawingsFromSearch(List<string> lst, List<string> desc)
        {
            if (lst == null || lst.Count == 0)
            {
                lstSigns.Items.Clear();
                lblMatches.Text = "0 match found";
                //picBxPreview.Image = null;
                //ACADViewer.Visible = false;
                pBoxViewer.Visible = false;
               // return;
            }
            else
            {
                lstSigns.Items.Clear();
                lst.ForEach(x =>
                {
                    lstSigns.Items.Add(x);
                });
                if (lstSigns.Items.Count > 1)
                    lblMatches.Text = lstSigns.Items.Count + " matches found";
                else
                    lblMatches.Text = lstSigns.Items.Count + " match found";
                pBoxViewer.Visible = true;
                //ACADViewer.Visible = true;
                //Commented on 08-04-2018 to avoid default selection
                //lstSigns.SelectedIndex = lstSigns.Items.Count > 0 ? 0 : -1;
            }

            if (desc == null || desc.Count == 0)
            {
                lstDescription.Items.Clear();
                lblDescriptionMatches.Text = "0 match found";
            }
            else
            {
                lstDescription.Items.Clear();
                desc.ForEach(x =>
                {
                    lstDescription.Items.Add(x);
                });
                if (lstDescription.Items.Count > 1)
                    lblDescriptionMatches.Text = lstDescription.Items.Count + " matches found";
                else
                    lblDescriptionMatches.Text = lstDescription.Items.Count + " match found";
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                lstSigns.Items.Clear();
                LoadSigns();
            }
        }

        private void cmboDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboDescription.SelectedIndex == 0)
            {
                btnRefresh_Click(null, null);//Added on 22-Oct-2017
                return;
            }
            var selectedItem = cmboDescription.Items[cmboDescription.SelectedIndex];
            var lst = basicCivilCustom.CivilCustomization.Where(x => x.Description.Equals(selectedItem)).Select(x => x.DrawingName.Replace(".dwg", "")).ToList();
            if (lst == null || lst.Count == 0)
                return;
            lstSigns.Items.Clear();
            lst.ForEach(x =>
            {
                lstSigns.Items.Add(x);
            });

            //03-May-2018
            if (lstSigns.Items.Count <= 1)
                lblMatches.Text = lstSigns.Items.Count + " match found";
            else
                lblMatches.Text = lstSigns.Items.Count + " matches found";

            //03-May-2018
            if (lstSigns.Items.Count == 1)
            {
                lstSigns.SelectedIndexChanged -= lstSigns_SelectedIndexChanged;
                lstSigns.SelectedItem = lstSigns.Items[0];
                lstSigns.SelectedIndexChanged += lstSigns_SelectedIndexChanged;
                lstSigns_SelectedIndexChanged(null, null);
            }

            if (lstDescription.Items.Contains(selectedItem))
            {
                lstDescription.SelectedIndexChanged -= lstDescription_SelectedIndexChanged;
                lstDescription.SelectedItem = selectedItem;
                lstDescription.SelectedIndexChanged += lstDescription_SelectedIndexChanged;
            }

            //16-04-2018 lstSigns.SelectedIndex = lstSigns.Items.Count > 0 ? 0 : -1;
        }

        private void lstDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDescription.SelectedItem != null)
                cmboDescription.SelectedItem = lstDescription.SelectedItem;
        }

        public void loadFile(string filePath)
        {
            pBoxViewer.Visible = false; //ACADViewer.Visible = false;
            if (File.Exists(filePath))
            {
                pBoxViewer.Visible = true;//  ACADViewer.Visible = true;
                using (Database dwgDb = new Database(false, true))
                {
                    dwgDb.ReadDwgFile(filePath, FileOpenMode.OpenForReadAndReadShare, false, "");
                    //ACADViewer.PutSourcePath(filePath);
                    Bitmap b;

                    if (dwgDb.ThumbnailBitmap != null)
                    {
                        pBoxViewer.Visible = true;
                        b = dwgDb.ThumbnailBitmap;
                        pBoxViewer.Image = b;
                        // set the image viewer to b

                    }
                    else
                        pBoxViewer.Visible = false;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.TextChanged -= txtSearch_TextChanged;
            txtSearch.Clear();
            lstSigns.Items.Clear();
            LoadSigns();
            txtSearch.TextChanged += txtSearch_TextChanged;

            lstDescription.ClearSelected();
            pBoxViewer.Visible = false;//  ACADViewer.Visible = false;
        }

        private void chkScale_Click(object sender, EventArgs e)
        {
            // picBxPreview.SizeMode = chkScale.Checked ? PictureBoxSizeMode.StretchImage : PictureBoxSizeMode.CenterImage;
        }

        private void chkScale_CheckedChanged(object sender, EventArgs e)
        {
            //17-05-2018
            //Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
            //Database db = doc.Database;
            //try
            //{
            //    if (chkScale.Checked == true)
            //    {
            //        doc.SendStringToExecute("(SV-ON) ", false, false, false);
            //    }
            //    else
            //    {
            //        doc.SendStringToExecute("(SV-OFF) ", false, false, false);
            //    }
            //}
            //catch { }
        }
    }

    [Serializable]
    public class CivilCustomization
    {
        public CivilCustomization()
        {

        }
        //30-05-2018
        //[XmlElement]
        //public int ID { get; set; }

        [XmlElement]
        public string Type { get; set; }

        [XmlElement]
        public string DrawingName { get; set; }

        [XmlElement]
        public string Region { get; set; }

        [XmlElement]
        public string Description { get; set; }
    }

    [Serializable]
    public class BasicCivilCustomization
    {
        public BasicCivilCustomization()
        {

        }

        [XmlElement]
        public List<CivilCustomization> CivilCustomization { get; set; }
    }

    public static class Extension
    {
        public static string ToXMLString(this BasicCivilCustomization obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BasicCivilCustomization));
            StringBuilder sb = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(sb, new XmlWriterSettings() { Indent = true }))
            {
                xmlSerializer.Serialize(xmlWriter, obj);
            }
            return sb.ToString();
        }

        public static BasicCivilCustomization Create(string path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(BasicCivilCustomization));
            TextReader reader = new StreamReader(path);
            object obj = deserializer.Deserialize(reader);
            reader.Close();
            return (BasicCivilCustomization)obj;
        }
    }

    public class CreateXML
    {
        //    Excel.Application xlApp;
        //    Excel.Workbook xlWorkBook;
        //    Excel.Worksheet xlWorkSheet;
        //    Excel.Range range;

        //    xlApp = new Excel.Application();

        //            xlWorkBook = xlApp.Workbooks.Open(@"E:\Chockalingam\CIVIL\CIVIL\NZ\Signs\NZTA Signs.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

        //            Excel.Worksheet xlTotWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

        //    BasicCivilCustomization civil = new BasicCivilCustomization();
        //    civil.CivilCustomization = new List<CivilCustomization>();
        //            for (int i = 2; i< 83; i++)
        //            {
        //                CivilCustomization objBasicCivil = new CivilCustomization();
        //    var signName = (xlTotWorkSheet.Cells[i, 1] as Excel.Range).Value;
        //    objBasicCivil.DrawingName = signName + ".dwg";
        //                objBasicCivil.ID = i - 1;
        //                objBasicCivil.Region = "Newzeland";
        //                objBasicCivil.Type = "Signs";
        //                civil.CivilCustomization.Add(objBasicCivil);
        //            }

        //var serialize = civil.ToXMLString();
        //            if (!string.IsNullOrWhiteSpace(serialize))
        //            {
        //                File.WriteAllText(@"C: \Users\Nithish\Desktop\NZSigns.xml", serialize);
        //            }
    }
}
