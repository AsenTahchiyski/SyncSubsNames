namespace SyncSubsNames
{
    partial class Form1
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
            this.SelectFolder = new System.Windows.Forms.Button();
            this.OutputText = new System.Windows.Forms.TextBox();
            this.ProcessInnerFolders = new System.Windows.Forms.CheckBox();
            this.Rename = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectFolder
            // 
            this.SelectFolder.Location = new System.Drawing.Point(12, 12);
            this.SelectFolder.Name = "SelectFolder";
            this.SelectFolder.Size = new System.Drawing.Size(97, 23);
            this.SelectFolder.TabIndex = 0;
            this.SelectFolder.Text = "Select Folder";
            this.SelectFolder.UseVisualStyleBackColor = true;
            this.SelectFolder.Click += new System.EventHandler(this.SelectFolder_Click);
            // 
            // OutputText
            // 
            this.OutputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputText.Location = new System.Drawing.Point(12, 41);
            this.OutputText.Multiline = true;
            this.OutputText.Name = "OutputText";
            this.OutputText.ReadOnly = true;
            this.OutputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputText.Size = new System.Drawing.Size(507, 345);
            this.OutputText.TabIndex = 1;
            this.OutputText.TextChanged += new System.EventHandler(this.OutputText_TextChanged);
            // 
            // ProcessInnerFolders
            // 
            this.ProcessInnerFolders.AutoSize = true;
            this.ProcessInnerFolders.Location = new System.Drawing.Point(126, 18);
            this.ProcessInnerFolders.Name = "ProcessInnerFolders";
            this.ProcessInnerFolders.Size = new System.Drawing.Size(124, 17);
            this.ProcessInnerFolders.TabIndex = 2;
            this.ProcessInnerFolders.Text = "Process inner folders";
            this.ProcessInnerFolders.UseVisualStyleBackColor = true;
            // 
            // Rename
            // 
            this.Rename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Rename.Location = new System.Drawing.Point(444, 12);
            this.Rename.Name = "Rename";
            this.Rename.Size = new System.Drawing.Size(75, 23);
            this.Rename.TabIndex = 3;
            this.Rename.Text = "Rename";
            this.Rename.UseVisualStyleBackColor = true;
            this.Rename.Click += new System.EventHandler(this.Rename_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 398);
            this.Controls.Add(this.Rename);
            this.Controls.Add(this.ProcessInnerFolders);
            this.Controls.Add(this.OutputText);
            this.Controls.Add(this.SelectFolder);
            this.Name = "Form1";
            this.Text = "Sync Subtitles Names";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SelectFolder;
        private System.Windows.Forms.TextBox OutputText;
        private System.Windows.Forms.CheckBox ProcessInnerFolders;
        private System.Windows.Forms.Button Rename;
    }
}

