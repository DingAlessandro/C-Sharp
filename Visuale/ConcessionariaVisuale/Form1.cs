using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Concessionaria
{
    public partial class Form1 : Form
    {
        int type = -1;
        List<Veicolo> veicolo = new List<Veicolo>();
        public Form1()
        {
            InitializeComponent();
        }

        public void EnaVi(int type) 
        {
            label1.Visible = !label1.Visible;
            label1.Enabled = !label1.Enabled;
            textBox1.Visible = !textBox1.Visible;
            textBox1.Enabled = !textBox1.Enabled;
            label2.Visible = !label2.Visible;
            label2.Enabled = !label2.Enabled;
            textBox2.Visible = !textBox2.Visible;
            textBox2.Enabled = !textBox2.Enabled;
            label3.Visible = !label3.Visible;
            label3.Enabled = !label3.Enabled;
            textBox3.Visible = !textBox3.Visible;
            textBox3.Enabled = !textBox3.Enabled;
            label4.Visible = !label4.Visible;
            label4.Enabled = !label4.Enabled;
            textBox4.Visible = !textBox4.Visible;
            textBox4.Enabled = !textBox4.Enabled;
            if (type == 0)
            {
                label5.Visible = !label5.Visible;
                label5.Enabled = !label5.Enabled;
                textBox5.Visible = !textBox5.Visible;
                textBox5.Enabled = !textBox5.Enabled;
            }
            button1.Enabled = !button1.Enabled;
            button1.Visible = !button1.Visible;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void motoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (type == -1)
            {
                type = 1;
                EnaVi(type);
                label3.Text = "Numero Tempi";
                label4.Text = "Porta Casco (Y/N)";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(type == 1) 
            {
                if (textBox1.Text != null && textBox2.Text != null && textBox3.Text != null && textBox4.Text != null)
                {
                    if (int.TryParse(textBox3.Text, out int p))
                    {
                        Moto moto = new Moto(textBox1.Text, textBox2.Text, p, textBox4.Text == "Y");
                        veicolo.Add(moto);
                        listBox1.Items.Add(moto.Write());
                    }
                }
            }
            EnaVi(type);
        }
    }
}
