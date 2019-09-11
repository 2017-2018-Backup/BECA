namespace ImageView
{
    partial class ImageView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOutputFolderSearch = new System.Windows.Forms.Button();
            this.Btnfilesearch = new System.Windows.Forms.Button();
            this.BtnPreview = new System.Windows.Forms.Button();
            this.TxtDefaultpath = new System.Windows.Forms.TextBox();
            this.TxtPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FbdPath = new System.Windows.Forms.FolderBrowserDialog();
            this.picBxLogo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOutputFolderSearch
            // 
            this.btnOutputFolderSearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOutputFolderSearch.Location = new System.Drawing.Point(496, 92);
            this.btnOutputFolderSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOutputFolderSearch.Name = "btnOutputFolderSearch";
            this.btnOutputFolderSearch.Size = new System.Drawing.Size(37, 23);
            this.btnOutputFolderSearch.TabIndex = 3;
            this.btnOutputFolderSearch.Text = "...";
            this.btnOutputFolderSearch.UseVisualStyleBackColor = true;
            this.btnOutputFolderSearch.Click += new System.EventHandler(this.btnOutputFolderSearch_Click);
            // 
            // Btnfilesearch
            // 
            this.Btnfilesearch.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btnfilesearch.Location = new System.Drawing.Point(496, 61);
            this.Btnfilesearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Btnfilesearch.Name = "Btnfilesearch";
            this.Btnfilesearch.Size = new System.Drawing.Size(37, 23);
            this.Btnfilesearch.TabIndex = 2;
            this.Btnfilesearch.Text = "...";
            this.Btnfilesearch.UseVisualStyleBackColor = true;
            this.Btnfilesearch.Click += new System.EventHandler(this.Btnfilesearch_Click);
            // 
            // BtnPreview
            // 
            this.BtnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.BtnPreview.Location = new System.Drawing.Point(434, 127);
            this.BtnPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BtnPreview.Name = "BtnPreview";
            this.BtnPreview.Size = new System.Drawing.Size(99, 23);
            this.BtnPreview.TabIndex = 2;
            this.BtnPreview.Text = "Create Image";
            this.BtnPreview.UseVisualStyleBackColor = true;
            this.BtnPreview.Click += new System.EventHandler(this.button1_Click);
            // 
            // TxtDefaultpath
            // 
            this.TxtDefaultpath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TxtDefaultpath.Location = new System.Drawing.Point(71, 92);
            this.TxtDefaultpath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtDefaultpath.Name = "TxtDefaultpath";
            this.TxtDefaultpath.Size = new System.Drawing.Size(421, 20);
            this.TxtDefaultpath.TabIndex = 1;
            this.TxtDefaultpath.Text = "C:\\Temp\\BasicCivil\\";
            // 
            // TxtPath
            // 
            this.TxtPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.TxtPath.Location = new System.Drawing.Point(71, 63);
            this.TxtPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TxtPath.Name = "TxtPath";
            this.TxtPath.Size = new System.Drawing.Size(421, 20);
            this.TxtPath.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label3.Location = new System.Drawing.Point(8, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(8, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "DWG Path";
            // 
            // picBxLogo
            // 
            this.picBxLogo.BackgroundImage = global::ImageView.Properties.Resources.beca_logo;
            this.picBxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBxLogo.InitialImage = null;
            this.picBxLogo.Location = new System.Drawing.Point(432, 12);
            this.picBxLogo.Name = "picBxLogo";
            this.picBxLogo.Size = new System.Drawing.Size(100, 35);
            this.picBxLogo.TabIndex = 6;
            this.picBxLogo.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Create Image From Drawing";
            // 
            // ImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 160);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picBxLogo);
            this.Controls.Add(this.btnOutputFolderSearch);
            this.Controls.Add(this.Btnfilesearch);
            this.Controls.Add(this.BtnPreview);
            this.Controls.Add(this.TxtDefaultpath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtPath);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Creator";
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Btnfilesearch;
        private System.Windows.Forms.Button BtnPreview;
        private System.Windows.Forms.TextBox TxtDefaultpath;
        private System.Windows.Forms.TextBox TxtPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog FbdPath;
        private System.Windows.Forms.Button btnOutputFolderSearch;
        private System.Windows.Forms.PictureBox picBxLogo;
        private System.Windows.Forms.Label label2;
    }
}

