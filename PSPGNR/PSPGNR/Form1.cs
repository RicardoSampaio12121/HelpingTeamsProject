using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PSPGNR
{
    public partial class Form1 : Form
    {
        private Fiscalizacao utentes = null;
        private Root myDeserializedClass;
        //private List<Utente> toJson = new List<Utente>();

        public Form1()
        {
            InitializeComponent();
        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            //SUBMIT PSP/XML

            DataBaseManager.InsertPSP(utentes);
            MessageBox.Show("DONE!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //SUBMIT GNR/JSON
            DataBaseManager.InsertGNR(myDeserializedClass.Fiscalizacao);
            MessageBox.Show("DONE!");
        }
    }
}
