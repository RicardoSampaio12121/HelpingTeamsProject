using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PSPGNR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            XmlSerializer serializer = new XmlSerializer(typeof(Fiscalizacao));
            Fiscalizacao utentes = null;

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
            
            if (utentes != null)
            {
                foreach (var u in utentes.Utente)
                {
                    MessageBox.Show($"CC: {u.Nus}  |  FN: {u.Firstname}  |  LN: {u.Lastname}");
                }
            }
        }
    }
}
