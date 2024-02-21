namespace supermarketProject1
{
    partial class NewGameScreen
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
            this.labelSelectAreaType = new System.Windows.Forms.Label();
            this.buttonSuburb = new System.Windows.Forms.Button();
            this.buttonRural = new System.Windows.Forms.Button();
            this.buttonUrban = new System.Windows.Forms.Button();
            this.labelHowManyPlaying = new System.Windows.Forms.Label();
            this.textBoxNumberOfPlayers = new System.Windows.Forms.TextBox();
            this.labelInvalidNumOfPlay = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.labelHowManyWeeksPlayingFor = new System.Windows.Forms.Label();
            this.textBoxNumberOfWeeks = new System.Windows.Forms.TextBox();
            this.labelInvalidNumOfWeeks = new System.Windows.Forms.Label();
            this.labelInvalidUserArea = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSelectAreaType
            // 
            this.labelSelectAreaType.AutoSize = true;
            this.labelSelectAreaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectAreaType.Location = new System.Drawing.Point(234, 6);
            this.labelSelectAreaType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelSelectAreaType.Name = "labelSelectAreaType";
            this.labelSelectAreaType.Size = new System.Drawing.Size(130, 20);
            this.labelSelectAreaType.TabIndex = 0;
            this.labelSelectAreaType.Text = "Select Area Type";
            this.labelSelectAreaType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelSelectAreaType.Click += new System.EventHandler(this.labelSelectAreaType_Click);
            // 
            // buttonSuburb
            // 
            this.buttonSuburb.Location = new System.Drawing.Point(273, 65);
            this.buttonSuburb.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSuburb.Name = "buttonSuburb";
            this.buttonSuburb.Size = new System.Drawing.Size(53, 39);
            this.buttonSuburb.TabIndex = 1;
            this.buttonSuburb.Text = "Suburb";
            this.buttonSuburb.UseVisualStyleBackColor = true;
            this.buttonSuburb.Click += new System.EventHandler(this.buttonSuburb_Click);
            // 
            // buttonRural
            // 
            this.buttonRural.Location = new System.Drawing.Point(353, 65);
            this.buttonRural.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRural.Name = "buttonRural";
            this.buttonRural.Size = new System.Drawing.Size(53, 39);
            this.buttonRural.TabIndex = 2;
            this.buttonRural.Text = "Rural";
            this.buttonRural.UseVisualStyleBackColor = true;
            this.buttonRural.Click += new System.EventHandler(this.buttonRural_Click);
            // 
            // buttonUrban
            // 
            this.buttonUrban.Location = new System.Drawing.Point(193, 65);
            this.buttonUrban.Margin = new System.Windows.Forms.Padding(2);
            this.buttonUrban.Name = "buttonUrban";
            this.buttonUrban.Size = new System.Drawing.Size(53, 39);
            this.buttonUrban.TabIndex = 0;
            this.buttonUrban.Text = "Urban";
            this.buttonUrban.UseVisualStyleBackColor = true;
            this.buttonUrban.Click += new System.EventHandler(this.buttonUrban_Click);
            // 
            // labelHowManyPlaying
            // 
            this.labelHowManyPlaying.AutoSize = true;
            this.labelHowManyPlaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHowManyPlaying.Location = new System.Drawing.Point(175, 130);
            this.labelHowManyPlaying.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelHowManyPlaying.Name = "labelHowManyPlaying";
            this.labelHowManyPlaying.Size = new System.Drawing.Size(242, 40);
            this.labelHowManyPlaying.TabIndex = 4;
            this.labelHowManyPlaying.Text = "How Many People Will Be Playing\r\nEnter Below\r\n";
            this.labelHowManyPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNumberOfPlayers
            // 
            this.textBoxNumberOfPlayers.Location = new System.Drawing.Point(273, 186);
            this.textBoxNumberOfPlayers.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumberOfPlayers.Name = "textBoxNumberOfPlayers";
            this.textBoxNumberOfPlayers.Size = new System.Drawing.Size(55, 20);
            this.textBoxNumberOfPlayers.TabIndex = 3;
            this.textBoxNumberOfPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxNumberOfPlayers.TextChanged += new System.EventHandler(this.textBoxNumberOfPlayers_TextChanged);
            // 
            // labelInvalidNumOfPlay
            // 
            this.labelInvalidNumOfPlay.AutoSize = true;
            this.labelInvalidNumOfPlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInvalidNumOfPlay.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelInvalidNumOfPlay.Location = new System.Drawing.Point(350, 184);
            this.labelInvalidNumOfPlay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelInvalidNumOfPlay.Name = "labelInvalidNumOfPlay";
            this.labelInvalidNumOfPlay.Size = new System.Drawing.Size(194, 40);
            this.labelInvalidNumOfPlay.TabIndex = 6;
            this.labelInvalidNumOfPlay.Text = "Invalid Number Of Players!\r\n(2-5)\r\n";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(238, 340);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(126, 62);
            this.buttonSubmit.TabIndex = 5;
            this.buttonSubmit.Text = "Press To Submit Changes";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // labelHowManyWeeksPlayingFor
            // 
            this.labelHowManyWeeksPlayingFor.AutoSize = true;
            this.labelHowManyWeeksPlayingFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHowManyWeeksPlayingFor.Location = new System.Drawing.Point(144, 229);
            this.labelHowManyWeeksPlayingFor.Name = "labelHowManyWeeksPlayingFor";
            this.labelHowManyWeeksPlayingFor.Size = new System.Drawing.Size(319, 40);
            this.labelHowManyWeeksPlayingFor.TabIndex = 8;
            this.labelHowManyWeeksPlayingFor.Text = "How Many Weeks Do You Want To Play For\r\nEnter Below\r\n";
            this.labelHowManyWeeksPlayingFor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxNumberOfWeeks
            // 
            this.textBoxNumberOfWeeks.Location = new System.Drawing.Point(273, 292);
            this.textBoxNumberOfWeeks.Name = "textBoxNumberOfWeeks";
            this.textBoxNumberOfWeeks.Size = new System.Drawing.Size(55, 20);
            this.textBoxNumberOfWeeks.TabIndex = 4;
            this.textBoxNumberOfWeeks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelInvalidNumOfWeeks
            // 
            this.labelInvalidNumOfWeeks.AutoSize = true;
            this.labelInvalidNumOfWeeks.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelInvalidNumOfWeeks.Location = new System.Drawing.Point(354, 292);
            this.labelInvalidNumOfWeeks.Name = "labelInvalidNumOfWeeks";
            this.labelInvalidNumOfWeeks.Size = new System.Drawing.Size(135, 26);
            this.labelInvalidNumOfWeeks.TabIndex = 10;
            this.labelInvalidNumOfWeeks.Text = "Invalid Number Of Weeks! \r\n(4-52) weeks";
            // 
            // labelInvalidUserArea
            // 
            this.labelInvalidUserArea.AutoSize = true;
            this.labelInvalidUserArea.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.labelInvalidUserArea.Location = new System.Drawing.Point(415, 37);
            this.labelInvalidUserArea.Name = "labelInvalidUserArea";
            this.labelInvalidUserArea.Size = new System.Drawing.Size(132, 13);
            this.labelInvalidUserArea.TabIndex = 11;
            this.labelInvalidUserArea.Text = "Need To Choose An Area!";
            // 
            // NewGameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 414);
            this.Controls.Add(this.labelInvalidUserArea);
            this.Controls.Add(this.labelInvalidNumOfWeeks);
            this.Controls.Add(this.textBoxNumberOfWeeks);
            this.Controls.Add(this.labelHowManyWeeksPlayingFor);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.labelInvalidNumOfPlay);
            this.Controls.Add(this.textBoxNumberOfPlayers);
            this.Controls.Add(this.labelHowManyPlaying);
            this.Controls.Add(this.buttonUrban);
            this.Controls.Add(this.buttonRural);
            this.Controls.Add(this.buttonSuburb);
            this.Controls.Add(this.labelSelectAreaType);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewGameScreen";
            this.Text = "New Game Screen";
            this.Load += new System.EventHandler(this.newGameScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSelectAreaType;
        private System.Windows.Forms.Button buttonSuburb;
        private System.Windows.Forms.Button buttonRural;
        private System.Windows.Forms.Button buttonUrban;
        private System.Windows.Forms.Label labelHowManyPlaying;
        private System.Windows.Forms.TextBox textBoxNumberOfPlayers;
        private System.Windows.Forms.Label labelInvalidNumOfPlay;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label labelHowManyWeeksPlayingFor;
        private System.Windows.Forms.TextBox textBoxNumberOfWeeks;
        private System.Windows.Forms.Label labelInvalidNumOfWeeks;
        private System.Windows.Forms.Label labelInvalidUserArea;
    }
}