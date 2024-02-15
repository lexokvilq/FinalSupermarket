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

        private static bool valid;
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
            Program.setUserArea("Rural");
            buttonSuburb.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.Black;    
            buttonRural.ForeColor = Color.WhiteSmoke;    
        }

        private void buttonSuburb_Click(object sender, EventArgs e)
        {
            Program.setUserArea("Suburb");
            buttonRural.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.Black;
            buttonSuburb.ForeColor = Color.WhiteSmoke;
        }

        private void buttonUrban_Click(object sender, EventArgs e)
        {
            Program.setUserArea("Urban");
            buttonRural.ForeColor = Color.Black;
            buttonSuburb.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.WhiteSmoke;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //reset all the error messages
            labelInvalidNumOfPlay.ForeColor = Color.WhiteSmoke;
            labelInvalidNumOfWeeks.ForeColor = Color.WhiteSmoke;
            labelInvalidUserArea.ForeColor = Color.WhiteSmoke;

            //checking if the number of players is valid or not
            if (Program.checkIfString(textBoxNumberOfPlayers.Text) == true || 
                Program.checkIfInteger(textBoxNumberOfPlayers.Text) == false ||
                Convert.ToInt32(textBoxNumberOfPlayers.Text) < 2 ||
                Convert.ToInt32(textBoxNumberOfPlayers.Text) > 5 )
            {
                labelInvalidNumOfPlay.ForeColor = Color.Red;
                valid = false;
            }
            //checking if the number of weeks is valid or not
            if (Program.checkIfString(textBoxNumberOfWeeks.Text) == true ||
                Program.checkIfInteger(textBoxNumberOfWeeks.Text) == false ||
                Convert.ToInt32(textBoxNumberOfWeeks.Text) < 4 ||
                Convert.ToInt32(textBoxNumberOfWeeks.Text) > 52 )
            {
                labelInvalidNumOfWeeks.ForeColor = Color.Red;
                valid = false;
            }
            //check if the user area is valid or not
            if (string.IsNullOrWhiteSpace(Program.UserArea) == true)
            {
                labelInvalidUserArea.ForeColor = Color.Red;
                valid = false;
            }

            else if (valid == true)
            {
                labelInvalidNumOfPlay.ForeColor = Color.WhiteSmoke;
                labelInvalidNumOfWeeks.ForeColor = Color.WhiteSmoke; 

                Program.setNumOfPlayers(Convert.ToInt32(textBoxNumberOfPlayers.Text));

                Program.setEndNumOfWeeks(Convert.ToInt32(textBoxNumberOfWeeks.Text));                
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
