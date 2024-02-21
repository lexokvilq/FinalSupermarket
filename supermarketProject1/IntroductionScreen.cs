using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supermarketProject1
{


    //this is the first screen displayed to the user
    public partial class IntroductionScreen : Form
    {
        //this variable contains all the data from the save file
        private string userFileData;

        //this variable checks where the file has been read successfully or not
        private bool fileReadOk;
        public IntroductionScreen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //set the invalid message to be invisible by changing the color
            labelInvalidSaveFile.ForeColor = Color.WhiteSmoke;
        }

        public void buttonNewGame_Click(object sender, EventArgs e)
        {
            //if a new game is clicked, the user is not loading a file, so the UserLoadingFile variable in program is set to false
            Program.setUserLoadedFile(false);
            //hide this screen
            this.Hide();
            //show the new screen
            NewGameScreen ngs = new NewGameScreen();
            ngs.Show();
        }

        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            //assume that file is read successfully first
            fileReadOk = true;

            //it is possible to have a null text file, e.g just .txt so no validation required

            //the user is loading a file, so the userLoadingFile variable is set to true
            Program.setUserLoadedFile(true);

            //generate the name of the file that the user is loading, by adding the directory before the name of the file
            // and adding the .txt at the end of the file name
            Program.generateNameUserLoadingFile(textBoxLoadGame.Text);

            try
            {
                //stream reader is used to search for the name of the user's file
                using (StreamReader sr = new StreamReader(Program.UserLoadingFileName))
                {
                    //all the data is stored on one line so all the data can be read at once
                    //the data of the save file is then stored in userFileData
                    userFileData = sr.ReadLine();
                }
            
            //catch is called if there was an error reading the save file
            }
            catch 
            {
                //the file reading failed
                fileReadOk = false;
                
                //display an error message
                labelInvalidSaveFile.ForeColor = Color.Red;
            }

            //if the file has been read ok
            if (fileReadOk == true)
            {
                //call the function in Program.cs which loads all the file data into the prorgram
                Program.loadFile(userFileData);
                
                //hide this screen
                this.Hide();

                //show the main game screen input screen
                MainGameScreenInput mgsi = new MainGameScreenInput();
                mgsi.Show();
            }
        }

        



        //these two functions below can be ignored
        private void textBoxLoadGame_TextChanged(object sender, EventArgs e)
        {
        }
        private void labelInvalidSaveFile_Click(object sender, EventArgs e)
        {
        }
    }
}
