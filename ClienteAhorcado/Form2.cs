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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.button1.Enabled = false;
        }

        // Método que ingresa el nombre del jugador y despliega el juego
        private void button1_Click(object sender, EventArgs e)
        {
            // Oculta el formulario actual
            this.Hide();

            // Hace una instancia del formulario de juego y lo invoca
            Form1 juego = new Form1(textBox1.Text);
            juego.Show();
        }

        // Método que cierra la aplicación cuando el usuario le da click a la opción "Salir"
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Método que se encarga de chequear si se ha digitado algo
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Chequea si el textBox tiene algo escrito adentro
            if (textBox1.TextLength != 0)
            {
                this.button1.Enabled = true;
            }
            else 
            {
                this.button1.Enabled = false;
            }
        }
    }
}
