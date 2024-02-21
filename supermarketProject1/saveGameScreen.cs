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
    public partial class SaveGameScreen : Form
    {
        //this is the name of the save file, the user has chosen
        private static string saveFileName;
        public SaveGameScreen()
        {
            InitializeComponent();
            
            //The error message is set to invisible
            labelInvalidFileName.ForeColor = Color.WhiteSmoke;

            //The directory where the file is added to the save file name
            //This directory will change on different devices
            saveFileName = "C:\\Users\\maxle\\OneDrive\\Documents\\Visual Studio 2022\\SUPERMARKET PROJECT OLD HOME REAL\\FinalSupermarket\\supermarketProject1\\bin\\Debug\\";
        }

        //The user presses the save and quit button
        private void buttonSaveQuit_Click(object sender, EventArgs e)
        {
            //The name the user has chosen is added to the saveFileName
            saveFileName = saveFileName + textBoxSaveFileName.Text;

            //The Program.saveFile saves the progress of the simulation, if the file could not be saved
            //the function returns false
            bool programHasBeenSaved = Program.saveFile(saveFileName);
            if (programHasBeenSaved == true)
            {
                //The file has been saved
                Application.Exit();
            }
            else
            {
                //The file has not been saved
                
                //Display error message
                labelInvalidFileName.ForeColor = Color.Red;
            }
        }

        //This is not needed for the simulation
        private void textBoxSaveFileName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}