namespace supermarketProject1
{
    partial class IntroductionScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntroductionScreen));
            this.labelIntroduction = new System.Windows.Forms.Label();
            this.buttonLoadGame = new System.Windows.Forms.Button();
            this.labelEnterLoadGame = new System.Windows.Forms.Label();
            this.textBoxLoadGame = new System.Windows.Forms.TextBox();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.labelInvalidSaveFile = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelIntroduction
            // 
            this.labelIntroduction.AutoSize = true;
            this.labelIntroduction.Location = new System.Drawing.Point(8, 6);
            this.labelIntroduction.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIntroduction.Name = "labelIntroduction";
            this.labelIntroduction.Size = new System.Drawing.Size(237, 78);
            this.labelIntroduction.TabIndex = 0;
            this.labelIntroduction.Text = resources.GetString("labelIntroduction.Text");
            // 
            // buttonLoadGame
            // 
            this.buttonLoadGame.Location = new System.Drawing.Point(10, 124);
            this.buttonLoadGame.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLoadGame.Name = "buttonLoadGame";
            this.buttonLoadGame.Size = new System.Drawing.Size(76, 32);
            this.buttonLoadGame.TabIndex = 2;
            this.buttonLoadGame.Text = "Load Game";
            this.buttonLoadGame.UseVisualStyleBackColor = true;
            this.buttonLoadGame.Click += new System.EventHandler(this.buttonLoadGame_Click);
            // 
            // labelEnterLoadGame
            // 
            this.labelEnterLoadGame.AutoSize = true;
            this.labelEnterLoadGame.Location = new System.Drawing.Point(8, 190);
            this.labelEnterLoadGame.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEnterLoadGame.Name = "labelEnterLoadGame";
            this.labelEnterLoadGame.Size = new System.Drawing.Size(157, 13);
            this.labelEnterLoadGame.TabIndex = 2;
            this.labelEnterLoadGame.Text = "Enter load game save file below";
            // 
            // textBoxLoadGame
            // 
            this.textBoxLoadGame.Location = new System.Drawing.Point(10, 214);
            this.textBoxLoadGame.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLoadGame.Name = "textBoxLoadGame";
            this.textBoxLoadGame.Size = new System.Drawing.Size(235, 20);
            this.textBoxLoadGame.TabIndex = 1;
            this.textBoxLoadGame.TextChanged += new System.EventHandler(this.textBoxLoadGame_TextChanged);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(272, 39);
            this.buttonNewGame.Margin = new System.Windows.Forms.Padding(2);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(89, 36);
            this.buttonNewGame.TabIndex = 0;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // labelInvalidSaveFile
            // 
            this.labelInvalidSaveFile.AutoSize = true;
            this.labelInvalidSaveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidSaveFile.ForeColor = System.Drawing.Color.Red;
            this.labelInvalidSaveFile.Location = new System.Drawing.Point(268, 214);
            this.labelInvalidSaveFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInvalidSaveFile.Name = "labelInvalidSaveFile";
            this.labelInvalidSaveFile.Size = new System.Drawing.Size(127, 20);
            this.labelInvalidSaveFile.TabIndex = 5;
            this.labelInvalidSaveFile.Text = "Invalid Save File!";
            this.labelInvalidSaveFile.Click += new System.EventHandler(this.labelInvalidSaveFile_Click);
            // 
            // IntroductionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 256);
            this.Controls.Add(this.labelInvalidSaveFile);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.textBoxLoadGame);
            this.Controls.Add(this.labelEnterLoadGame);
            this.Controls.Add(this.buttonLoadGame);
            this.Controls.Add(this.labelIntroduction);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "IntroductionScreen";
            this.Text = "Introduction";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIntroduction;
        private System.Windows.Forms.Button buttonLoadGame;
        private System.Windows.Forms.Label labelEnterLoadGame;
        private System.Windows.Forms.TextBox textBoxLoadGame;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Label labelInvalidSaveFile;
    }
}

