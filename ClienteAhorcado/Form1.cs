using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteAhorcado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Establece el máximo largo del input
            //textBox1.MaxLength = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ECCI.ECCI_HolaMundoPortClient holaMundo = new ECCI.ECCI_HolaMundoPortClient();
            MessageBox.Show(holaMundo.salude(textBox1.Text));
            //label2.Text = holaMundo.salude(textBox1.Text);
        }
    }
}
