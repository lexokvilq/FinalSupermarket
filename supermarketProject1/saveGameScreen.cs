using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarketProject1
{
    public partial class saveGameScreen : Form
    {
        private static string saveFileName;
        public saveGameScreen()
        {
            InitializeComponent();
            labelInvalidFileName.ForeColor = Color.WhiteSmoke;

            //NEED TO CHANGE THIS FOR SEPERATE COMPUTERS
            saveFileName = "C:\\Users\\maxle\\OneDrive\\Documents\\Visual Studio 2022\\SUPERMARKET PROJECT OLD HOME REAL\\FinalSupermarket\\supermarketProject1\\bin\\Debug\\";

        }

        private void textBoxSaveFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonSaveQuit_Click(object sender, EventArgs e)
        {
            //check if the input is null
            if (string.IsNullOrEmpty(textBoxSaveFileName.Text) == true)
            {
                labelInvalidFileName.ForeColor = Color.Red;
            }
            else
            {
                saveFileName = saveFileName + textBoxSaveFileName.Text;
                //this function in program will write the data to the save file and return whether it has succedded or not
                bool programHasBeenSaved = Program.saveFile(saveFileName);
                if (programHasBeenSaved == true)
                {
                    Application.Exit(); 
                }
                else
                {
                    labelInvalidFileName.ForeColor = Color.Red;
                }
            }
        }
    }
}