namespace FileFinder.View
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtFolder = new DevExpress.XtraEditors.TextEdit();
            this.BtnPickFolder = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.BtnFind = new DevExpress.XtraEditors.SimpleButton();
            this.TxtResult = new DevExpress.XtraEditors.MemoEdit();
            this.TxtFilename = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TxtFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtResult.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(30, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Folder";
            // 
            // TxtFolder
            // 
            this.TxtFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtFolder.Location = new System.Drawing.Point(97, 12);
            this.TxtFolder.Name = "TxtFolder";
            this.TxtFolder.Size = new System.Drawing.Size(737, 20);
            this.TxtFolder.TabIndex = 1;
            // 
            // BtnPickFolder
            // 
            this.BtnPickFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPickFolder.Location = new System.Drawing.Point(840, 10);
            this.BtnPickFolder.Name = "BtnPickFolder";
            this.BtnPickFolder.Size = new System.Drawing.Size(17, 23);
            this.BtnPickFolder.TabIndex = 2;
            this.BtnPickFolder.Text = "...";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 41);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(78, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "FilenamePattern";
            // 
            // BtnFind
            // 
            this.BtnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnFind.Location = new System.Drawing.Point(794, 64);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(63, 45);
            this.BtnFind.TabIndex = 5;
            this.BtnFind.Text = "Find";
            // 
            // TxtResult
            // 
            this.TxtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtResult.Location = new System.Drawing.Point(13, 115);
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.Size = new System.Drawing.Size(844, 335);
            this.TxtResult.TabIndex = 6;
            // 
            // TxtFilename
            // 
            this.TxtFilename.Location = new System.Drawing.Point(97, 38);
            this.TxtFilename.Name = "TxtFilename";
            this.TxtFilename.Size = new System.Drawing.Size(737, 20);
            this.TxtFilename.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 462);
            this.Controls.Add(this.TxtFilename);
            this.Controls.Add(this.TxtResult);
            this.Controls.Add(this.BtnFind);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.BtnPickFolder);
            this.Controls.Add(this.TxtFolder);
            this.Controls.Add(this.labelControl1);
            this.Name = "MainForm";
            this.Text = "FileFinder";
            ((System.ComponentModel.ISupportInitialize)(this.TxtFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtResult.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtFolder;
        private DevExpress.XtraEditors.SimpleButton BtnPickFolder;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton BtnFind;
        private DevExpress.XtraEditors.MemoEdit TxtResult;
        private System.Windows.Forms.TextBox TxtFilename;
    }
}

