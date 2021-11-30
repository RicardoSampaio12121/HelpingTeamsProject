using Newtonsoft.Json;
using System;
/*
 * Author: Ricardo Sampaio
 * Email: ricardo_cs@outlook.pt
 * 
 * Author: Cláudio Silva
 * Email: a18843@alunos.ipca.pt
 * 
 * This program can import XML and JSON files containing details about people that
 * GNR and PSP went to check to see if they were doing the quarantine.
 * 
 */

using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PSPGNR
{
    public partial class Form1 : Form
    {
        private Fiscalizacao utentes = null;
        private Root myDeserializedClass = null;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads an XML file and deserialize it into an object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            XmlSerializer serializer = new XmlSerializer(typeof(Fiscalizacao));

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        utentes = (Fiscalizacao)serializer.Deserialize(reader);
                    }
                }
            }
        }

        /// <summary>
        /// Loads a JSON file and deserializes it into an object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            string json = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        json = reader.ReadToEnd();
                    }
                }
            }
            myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);
        }

        /// <summary>
        /// Submits the data gathered from the XML file to be inserted into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if(utentes != null)
            {
                DataBaseManager.InsertPSP(utentes);
                MessageBox.Show("DONE!");
                utentes = null;
            }
            else
            {
                MessageBox.Show("Information was not given yet!");
            }
        }

        /// <summary>
        /// Submits the data gathered from the JSON file to be inserted into the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if(myDeserializedClass != null)
            {
                DataBaseManager.InsertGNR(myDeserializedClass.Fiscalizacao);
                MessageBox.Show("DONE!");
                myDeserializedClass = null;
            }
            else
            {
                MessageBox.Show("Information was not given yet!");
            }
        }
    }
}
