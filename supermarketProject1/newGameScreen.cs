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
    public partial class NewGameScreen : Form
    {
        //This valid boolean variable is used to check whether the users input is valid  
        private static bool valid;
        public NewGameScreen()
        {
            InitializeComponent();
            //The valid deafult value is true
            valid = true;
        }

        //The rural button is clicked      
        private void buttonRural_Click(object sender, EventArgs e)
        {
            //The user area is set to rural
            Program.setUserArea("Rural");
            //The suburb and urban area buttons are both set to be deselected
            buttonSuburb.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.Black;    
            //The rural button color is set to be selected
            buttonRural.ForeColor = Color.WhiteSmoke;    
        }

        //The suburb button is clicked
        private void buttonSuburb_Click(object sender, EventArgs e)
        {
            //The user area is set to suburb
            Program.setUserArea("Suburb");
            //The subrub button is set to selected color,
            //all the other buttons are set to the de selected color
            buttonRural.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.Black;
            buttonSuburb.ForeColor = Color.WhiteSmoke;
        }

        //The urban button is clicked
        private void buttonUrban_Click(object sender, EventArgs e)
        {
            //The user area is set to urban
            Program.setUserArea("Urban");
            //Urban button selected all other buttons deselected
            buttonRural.ForeColor = Color.Black;
            buttonSuburb.ForeColor = Color.Black;
            buttonUrban.ForeColor = Color.WhiteSmoke;
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //Set all the error messages to be invisible
            labelInvalidNumOfPlay.ForeColor = Color.WhiteSmoke;
            labelInvalidNumOfWeeks.ForeColor = Color.WhiteSmoke;
            labelInvalidUserArea.ForeColor = Color.WhiteSmoke;

            //validation of the number of players in the game
            //The number of players has to be a integer between 2 and 5 inclusive
            //First check if the value is a string, then if it is an integer then if the values is smaller than 2
            //then check if the value is greater than 5
            if (Program.checkIfString(textBoxNumberOfPlayers.Text) == true || 
                Program.checkIfInteger(textBoxNumberOfPlayers.Text) == false ||
                Convert.ToInt32(textBoxNumberOfPlayers.Text) < 2 ||
                Convert.ToInt32(textBoxNumberOfPlayers.Text) > 5 )
            {
                //The input is invalid
               
                //Display an error message
                labelInvalidNumOfPlay.ForeColor = Color.Red;
                //set the valid to be false
                valid = false;
            }

            //Validation for the number of weeks for the game
            //Needs to be an integer bettwen 4 and 52 inclusive
            //First check if the value is a string, then if it is an integer, then if it is smaller than 4
            //then if it is greater than 52
            if (Program.checkIfString(textBoxNumberOfWeeks.Text) == true ||
                Program.checkIfInteger(textBoxNumberOfWeeks.Text) == false ||
                Convert.ToInt32(textBoxNumberOfWeeks.Text) < 4 ||
                Convert.ToInt32(textBoxNumberOfWeeks.Text) > 52 )
            {
                //The input is invalid

                //Error message is displayed
                labelInvalidNumOfWeeks.ForeColor = Color.Red;
                //Valid is set to false
                valid = false;
            }

            //Check if the user area is valid or not
            //The user area can only be urban,subrub or rural
            //Check if the user area is a null value
            if (string.IsNullOrWhiteSpace(Program.UserArea) == true)
            {
                //The error message is displayed
                labelInvalidUserArea.ForeColor = Color.Red;
                //Valid is set to false
                valid = false;
            }

            //if all the checks have been passed and the valid is true
            if (valid == true)
            {
                //error messages are set to be invisible
                labelInvalidNumOfPlay.ForeColor = Color.WhiteSmoke;
                labelInvalidNumOfWeeks.ForeColor = Color.WhiteSmoke; 

                //Set the number of players to the valid value in the text box, number of players
                Program.setNumOfPlayers(Convert.ToInt32(textBoxNumberOfPlayers.Text));

                //Set the end number of weeks to the valid value in the number of weeks text box
                Program.setEndNumOfWeeks(Convert.ToInt32(textBoxNumberOfWeeks.Text));                
                
                //hide the window
                this.Hide();
 
                //load the new screen
                MainGameScreenInput mgsi = new MainGameScreenInput();
                mgsi.Show();
            }
            
            //Reset the valid to its deafult value, true, before the checks are gone through again when the user presses the submit button
            valid = true;
        }

        //None of the code below is needed
        private void textBoxNumberOfPlayers_TextChanged(object sender, EventArgs e)
        {
        }
        private void newGameScreen_Load(object sender, EventArgs e)
        {
        }
        private void labelSelectAreaType_Click(object sender, EventArgs e)
        {
        }

    }
}
