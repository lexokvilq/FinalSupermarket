namespace supermarketProject1
{
    partial class saveGameScreen
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
            this.labelNameSaveFile = new System.Windows.Forms.Label();
            this.textBoxSaveFileName = new System.Windows.Forms.TextBox();
            this.labelInvalidFileName = new System.Windows.Forms.Label();
            this.buttonSaveQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelNameSaveFile
            // 
            this.labelNameSaveFile.AutoSize = true;
            this.labelNameSaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNameSaveFile.Location = new System.Drawing.Point(8, 8);
            this.labelNameSaveFile.Name = "labelNameSaveFile";
            this.labelNameSaveFile.Size = new System.Drawing.Size(120, 20);
            this.labelNameSaveFile.TabIndex = 0;
            this.labelNameSaveFile.Text = "Name Save File";
            // 
            // textBoxSaveFileName
            // 
            this.textBoxSaveFileName.Location = new System.Drawing.Point(8, 38);
            this.textBoxSaveFileName.Name = "textBoxSaveFileName";
            this.textBoxSaveFileName.Size = new System.Drawing.Size(200, 20);
            this.textBoxSaveFileName.TabIndex = 1;
            this.textBoxSaveFileName.TextChanged += new System.EventHandler(this.textBoxSaveFileName_TextChanged);
            // 
            // labelInvalidFileName
            // 
            this.labelInvalidFileName.AutoSize = true;
            this.labelInvalidFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidFileName.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidFileName.Location = new System.Drawing.Point(238, 38);
            this.labelInvalidFileName.Name = "labelInvalidFileName";
            this.labelInvalidFileName.Size = new System.Drawing.Size(133, 20);
            this.labelInvalidFileName.TabIndex = 2;
            this.labelInvalidFileName.Text = "Invalid File Name!";
            // 
            // buttonSaveQuit
            // 
            this.buttonSaveQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSaveQuit.Location = new System.Drawing.Point(8, 68);
            this.buttonSaveQuit.Name = "buttonSaveQuit";
            this.buttonSaveQuit.Size = new System.Drawing.Size(222, 45);
            this.buttonSaveQuit.TabIndex = 3;
            this.buttonSaveQuit.Text = "Press To Save And Quit";
            this.buttonSaveQuit.UseVisualStyleBackColor = true;
            this.buttonSaveQuit.Click += new System.EventHandler(this.buttonSaveQuit_Click);
            // 
            // saveGameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 137);
            this.Controls.Add(this.buttonSaveQuit);
            this.Controls.Add(this.labelInvalidFileName);
            this.Controls.Add(this.textBoxSaveFileName);
            this.Controls.Add(this.labelNameSaveFile);
            this.Name = "saveGameScreen";
            this.Text = "Save Game Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNameSaveFile;
        private System.Windows.Forms.TextBox textBoxSaveFileName;
        private System.Windows.Forms.Label labelInvalidFileName;
        private System.Windows.Forms.Button buttonSaveQuit;
    }
}