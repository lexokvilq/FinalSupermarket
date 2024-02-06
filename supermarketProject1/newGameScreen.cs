using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarketProject1
{
    public partial class newGameScreen : Form
    {

        //add this into design
        public static bool valid;
        public newGameScreen()
        {
            InitializeComponent();
            valid = true;
        }

        private void labelSelectAreaType_Click(object sender, EventArgs e)
        {

        }

        private void buttonRural_Click(object sender, EventArgs e)
        {
            Program.userArea = "Rural";
            buttonSuburb.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.Black;    
            buttonRural.ForeColor = Color.WhiteSmoke;    
        }

        private void buttonSuburb_Click(object sender, EventArgs e)
        {
            Program.userArea = "Suburb";
            buttonRural.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.Black;
            buttonSuburb.ForeColor = Color.WhiteSmoke;
        }

        private void buttonUrban_Click(object sender, EventArgs e)
        {
            Program.userArea = "Urban";
            buttonRural.ForeColor = Color.Black;
            buttonSuburb.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.WhiteSmoke;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            labelInvalidNumOfPlay.ForeColor = Color.WhiteSmoke;
            labelInvalidNumOfWeeks.ForeColor = Color.WhiteSmoke;
            if (Program.checkIfString(textBoxNumberOfPlayers.Text) == true || 
                Convert.ToInt32(textBoxNumberOfPlayers.Text) < 2 ||
                Convert.ToInt32(textBoxNumberOfPlayers.Text) > 10)
            {
                labelInvalidNumOfPlay.ForeColor = Color.Red;
                valid = false;
            }
            if (Program.checkIfString(textBoxNumberOfWeeks.Text) == true ||
                Convert.ToInt32(textBoxNumberOfWeeks.Text) < 4 ||
                Convert.ToInt32(textBoxNumberOfWeeks.Text) > 52)
            {
                labelInvalidNumOfWeeks.ForeColor = Color.Red;
                valid = false;
            }
            else if (valid == true)
            {
                labelInvalidNumOfPlay.ForeColor = Color.WhiteSmoke;
                labelInvalidNumOfWeeks.ForeColor = Color.WhiteSmoke; 
                Program.numOfPlayers = Convert.ToInt32(textBoxNumberOfPlayers.Text);
                Program.endNumOfWeeks = Convert.ToInt32(textBoxNumberOfWeeks.Text);
                this.Hide();
                mainGameScreenInput mgsi = new mainGameScreenInput();
                mgsi.Show();
            }
            valid = true;
           
        }

        private void textBoxNumberOfPlayers_TextChanged(object sender, EventArgs e)
        {

        }

        private void newGameScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
