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

    //in the design this is called the introduction screen
    public partial class Form1 : Form
    {
        //add this to design
        //this string contains all the data from the save file
        public string userFileData;
        bool fileReadOk;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            labelInvalidSaveFile.ForeColor = Color.WhiteSmoke;
            fileReadOk = true;
        }

        public void buttonNewGame_Click(object sender, EventArgs e)
        {
            Program.userLoadedFile = false;
            //set the user save file to "" so the program knows that the user isn't loading a save file
            this.Hide();
            newGameScreen ngs = new newGameScreen();
            ngs.Show();
        }

        private void buttonLoadGame_Click(object sender, EventArgs e)
        {
            Program.userLoadedFile = true;
            //or search for the textBoxLoadGame.Text in the c# files 
            if (textBoxLoadGame.Text == "" || textBoxLoadGame.Text == " ")
            {
                labelInvalidSaveFile.ForeColor = Color.Red;
            }
            else
            {
                Program.userSaveFile = Program.userSaveFile + textBoxLoadGame.Text + ".txt";
                try
                {
                    //create an instance of stream reader to read from a file
                    //the using statement closes the stream reader
                    using (StreamReader sr = new StreamReader(Program.userSaveFile))
                    {
                        string file;
                        //read and display the lines from the fil until the end of the file is reached
                        while ((file = sr.ReadLine()) != null)
                        {
                            userFileData = userFileData + file;
                        }
                    }


                }
                catch (Exception)
                {
                    fileReadOk = false;
                    labelInvalidSaveFile.ForeColor = Color.Red;
                }

                //if the file has been read ok
                if (fileReadOk == true)
                {
                    Program.loadFile(userFileData);
                    this.Hide();
                    mainGameScreenInput mgsi = new mainGameScreenInput();
                    mgsi.Show();
                }



            }
        }

        private void textBoxLoadGame_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelInvalidSaveFile_Click(object sender, EventArgs e)
        {

        }
    }
}
