namespace BecaUserInterface
{
    partial class SymbolLibrary
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstDescription = new System.Windows.Forms.ListBox();
            this.chkScale = new System.Windows.Forms.CheckBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblDescriptionMatches = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmboDescription = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMatches = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnCacnel = new System.Windows.Forms.Button();
            this.lstSigns = new System.Windows.Forms.ListBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.picBxLogo = new System.Windows.Forms.PictureBox();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.lblSigns = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pBoxViewer = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lstDescription);
            this.groupBox1.Controls.Add(this.chkScale);
            this.groupBox1.Controls.Add(this.lblDescriptionMatches);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmboDescription);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblMatches);
            this.groupBox1.Controls.Add(this.btnInsert);
            this.groupBox1.Controls.Add(this.btnCacnel);
            this.groupBox1.Controls.Add(this.lstSigns);
            this.groupBox1.Controls.Add(this.picBxLogo);
            this.groupBox1.Controls.Add(this.txtRegion);
            this.groupBox1.Controls.Add(this.lblSigns);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lstDescription
            // 
            this.lstDescription.FormattingEnabled = true;
            this.lstDescription.Location = new System.Drawing.Point(9, 104);
            this.lstDescription.Name = "lstDescription";
            this.lstDescription.Size = new System.Drawing.Size(486, 238);
            this.lstDescription.Sorted = true;
            this.lstDescription.TabIndex = 6;
            this.lstDescription.SelectedIndexChanged += new System.EventHandler(this.lstDescription_SelectedIndexChanged);
            // 
            // chkScale
            // 
            this.chkScale.AutoSize = true;
            this.chkScale.Checked = true;
            this.chkScale.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScale.Location = new System.Drawing.Point(310, 87);
            this.chkScale.Name = "chkScale";
            this.chkScale.Size = new System.Drawing.Size(70, 17);
            this.chkScale.TabIndex = 16;
            this.chkScale.Text = "SV Scale";
            this.chkScale.UseVisualStyleBackColor = true;
            this.chkScale.Visible = false;
            this.chkScale.CheckedChanged += new System.EventHandler(this.chkScale_CheckedChanged);
            this.chkScale.Click += new System.EventHandler(this.chkScale_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::BecaUserInterface.Properties.Resources.reload;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(714, 51);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(21, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblDescriptionMatches
            // 
            this.lblDescriptionMatches.AutoSize = true;
            this.lblDescriptionMatches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.lblDescriptionMatches.Location = new System.Drawing.Point(9, 355);
            this.lblDescriptionMatches.Name = "lblDescriptionMatches";
            this.lblDescriptionMatches.Size = new System.Drawing.Size(35, 13);
            this.lblDescriptionMatches.TabIndex = 15;
            this.lblDescriptionMatches.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.label6.Location = new System.Drawing.Point(6, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Description";
            // 
            // cmboDescription
            // 
            this.cmboDescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmboDescription.FormattingEnabled = true;
            this.cmboDescription.Location = new System.Drawing.Point(123, 52);
            this.cmboDescription.Name = "cmboDescription";
            this.cmboDescription.Size = new System.Drawing.Size(503, 21);
            this.cmboDescription.Sorted = true;
            this.cmboDescription.TabIndex = 1;
            this.cmboDescription.Visible = false;
            this.cmboDescription.SelectedIndexChanged += new System.EventHandler(this.cmboDescription_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Search by Description";
            this.label5.Visible = false;
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.lblMatches.Location = new System.Drawing.Point(498, 355);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(35, 13);
            this.lblMatches.TabIndex = 10;
            this.lblMatches.Text = "label5";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(580, 373);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 23);
            this.btnInsert.TabIndex = 7;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnCacnel
            // 
            this.btnCacnel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCacnel.Location = new System.Drawing.Point(665, 373);
            this.btnCacnel.Name = "btnCacnel";
            this.btnCacnel.Size = new System.Drawing.Size(75, 23);
            this.btnCacnel.TabIndex = 8;
            this.btnCacnel.Text = "Cancel";
            this.btnCacnel.UseVisualStyleBackColor = true;
            this.btnCacnel.Click += new System.EventHandler(this.btnCacnel_Click);
            // 
            // lstSigns
            // 
            this.lstSigns.FormattingEnabled = true;
            this.lstSigns.Location = new System.Drawing.Point(501, 104);
            this.lstSigns.Name = "lstSigns";
            this.lstSigns.Size = new System.Drawing.Size(241, 238);
            this.lstSigns.TabIndex = 5;
            this.lstSigns.SelectedIndexChanged += new System.EventHandler(this.lstSigns_SelectedIndexChanged);
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(631, 51);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(79, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(123, 53);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(503, 20);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // picBxLogo
            // 
            this.picBxLogo.BackgroundImage = global::BecaUserInterface.Properties.Resources.beca_logo;
            this.picBxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picBxLogo.Location = new System.Drawing.Point(640, 12);
            this.picBxLogo.Name = "picBxLogo";
            this.picBxLogo.Size = new System.Drawing.Size(100, 35);
            this.picBxLogo.TabIndex = 5;
            this.picBxLogo.TabStop = false;
            // 
            // txtRegion
            // 
            this.txtRegion.Enabled = false;
            this.txtRegion.Location = new System.Drawing.Point(123, 18);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.ReadOnly = true;
            this.txtRegion.Size = new System.Drawing.Size(156, 20);
            this.txtRegion.TabIndex = 0;
            // 
            // lblSigns
            // 
            this.lblSigns.AutoSize = true;
            this.lblSigns.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.lblSigns.Location = new System.Drawing.Point(498, 87);
            this.lblSigns.Name = "lblSigns";
            this.lblSigns.Size = new System.Drawing.Size(33, 13);
            this.lblSigns.TabIndex = 3;
            this.lblSigns.Text = "Signs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Search Manually";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Region";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(152)))), ((int)(((byte)(229)))));
            this.label4.Location = new System.Drawing.Point(755, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Preview";
            // 
            // pBoxViewer
            // 
            this.pBoxViewer.Location = new System.Drawing.Point(759, 37);
            this.pBoxViewer.Name = "pBoxViewer";
            this.pBoxViewer.Size = new System.Drawing.Size(344, 340);
            this.pBoxViewer.TabIndex = 8;
            this.pBoxViewer.TabStop = false;
            // 
            // SymbolLibrary
            // 
            this.AcceptButton = this.btnInsert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCacnel;
            this.ClientSize = new System.Drawing.Size(1114, 416);
            this.Controls.Add(this.pBoxViewer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SymbolLibrary";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Symbol Library";
            this.Load += new System.EventHandler(this.SymbolLibrary_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSigns;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.PictureBox picBxLogo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.ListBox lstSigns;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCacnel;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label lblMatches;
        private System.Windows.Forms.Label lblDescriptionMatches;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmboDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstDescription;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkScale;
        private System.Windows.Forms.PictureBox pBoxViewer;
    }
}