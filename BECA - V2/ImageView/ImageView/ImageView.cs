using Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageView
{
    public partial class ImageView : Form
    {
        public ImageView()
        {
            InitializeComponent();
            //groupBox1.Paint += groupBox1_Paint;
        }


        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
           // GroupBox box = sender as GroupBox;
            //DrawGroupBox(box, e.Graphics, Color.Black, Color.Black);
        }


        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPath.Text))
                CreatePreviewImage(TxtPath.Text);
            else
                MessageBox.Show("Select dwg path", "Image Creator");
        }

        private void CreatePreviewImage(string dwgPath)
        {
            if (System.IO.Directory.Exists(dwgPath))
            {
                List<string> filesList = DirSearch(dwgPath);
                try
                {
                    if (!Directory.Exists(TxtDefaultpath.Text))
                        System.IO.Directory.CreateDirectory(TxtDefaultpath.Text);
                }
                catch {
                    MessageBox.Show("Output folder not found");
                    return;
                }
                foreach (string dwgFile in filesList)
                {

                    if (Path.GetExtension(dwgFile).Equals(".dwg"))
                    {
                        try
                        {
                            Document activeDoc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument;
                            Document doc = Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.Open(dwgFile);
                            
                            using (doc.LockDocument())
                            {
                                using (Bitmap bmapImage = doc.CapturePreviewImage((uint)236, (uint)277))
                                {
                                    bmapImage.Save( System.IO.Path.Combine(TxtDefaultpath.Text , System.IO.Path.GetFileNameWithoutExtension(dwgFile) + ".jpg"), ImageFormat.Jpeg);
                                }
                            }
                            Autodesk.AutoCAD.ApplicationServices.Application.DocumentManager.MdiActiveDocument = activeDoc;
                            doc.CloseAndDiscard();
                        }
                        catch
                        {
                            MessageBox.Show("Image not created at " + TxtPath.Text, "Image Creator");
                            return;
                        }
                    }
                }

                MessageBox.Show("Completed", "Image Creator");
            }
            else
            {
                MessageBox.Show("Invalid path", "Image Creator");
            }
        }

        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        private void Btnfilesearch_Click(object sender, EventArgs e)
        {
            FbdPath.Description = "Select Folder";

            if (FbdPath.ShowDialog() == DialogResult.OK)
            {
                TxtPath.Text = FbdPath.SelectedPath;
            }

        }

        private void btnOutputFolderSearch_Click(object sender, EventArgs e)
        {
            FbdPath.Description = "Select Folder";

            if (FbdPath.ShowDialog() == DialogResult.OK)
            {
                TxtDefaultpath.Text = FbdPath.SelectedPath;
            }
        }
    }
}
