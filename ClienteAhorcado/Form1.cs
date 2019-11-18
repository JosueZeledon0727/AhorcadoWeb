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
        ECCI.ECCI_HolaMundoPortClient holaMundo = new ECCI.ECCI_HolaMundoPortClient();

        public Form1()
        {
            InitializeComponent();
            label2.Text = holaMundo.retornaPalabra();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Establece el máximo largo del input
            textBox1.MaxLength = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Chequea si hay algo dentro del textBox, digitado por el usuario
            if (textBox1.TextLength != 0)
            {
                label2.Text = holaMundo.saludito(textBox1.Text);
            }

            // Chequea si la palabra fue adivinada
            if (holaMundo.palabraAdivinada())
            {
                MessageBox.Show("JUEGO TERMINADO! :3");
                this.button1.Enabled = false;
            }
        }

    }
}
