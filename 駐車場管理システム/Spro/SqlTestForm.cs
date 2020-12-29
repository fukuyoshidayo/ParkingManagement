using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ssk;

namespace Spro
{
    public partial class SqlTestForm : BsForm
    {
        public SqlTestForm()
        {
            InitializeComponent();
        }

        private void bt_戻る_Click(object sender, EventArgs e)
        {
            Bye();
        }


        private void save()
        {
            FileStream f = new FileStream(saveFileDialog1.FileName, FileMode.Create);
            StreamWriter wr = new StreamWriter(f, Encoding.Default);
            wr.Write(textBox1.Text);
            wr.Close();
            //f.Close();
        }

        private void bt_LOAD_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.FileName = openFileDialog1.FileName;
                FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open);
                StreamReader rd = new StreamReader(f, Encoding.Default);
                textBox1.Text = rd.ReadToEnd();
                rd.Close();
                //f.Close();
            }
        }

        private void bt_SAVE_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                save();
            }
        }
    }
}
