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

        public Form1(string nombreJugador)
        {
            InitializeComponent();

            // Recupera una palabra para el juego del jugador
            label2.Text = holaMundo.retornaPalabra();
            // Escribe el nombre del jugador
            label4.Text = nombreJugador;

            // Envía al servicio web el nombre del jugador para empezar a contar su tiempo
            holaMundo.guardarNombreJugador(nombreJugador);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
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
                // Envía la letra para su respectivo chequeo contra la palabra
                // a adivinar
                label2.Text = holaMundo.saludito(textBox1.Text);

                // Chequea si la letra no estaba en la palabra
                if (holaMundo.letraFallida())
                {
                    modificarImagen(Convert.ToInt32(holaMundo.obtenerCantidadErrores()));
                    
                    // Chequea si el jugador ya perdió
                    if (holaMundo.juegoPerdido())
                    {
                        MessageBox.Show("Perdiste!", "JUEGO TERMINADO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.button1.Enabled = false;
                    }
                }

                // Chequea si la palabra fue adivinada
                if (holaMundo.palabraAdivinada())
                {
                    MessageBox.Show("Ganaste!", "JUEGO TERMINADO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.button1.Enabled = false;
                }

                // Borra el contenido de la letra que ya digitó
                textBox1.Text = "";
            }
        }

        // Método que se encarga de dibujar cada una de las partes del ahorcado, basado en los errores
        // del jugador
        public void modificarImagen(int numImagen)
        {
            if(numImagen != 0)
                pictureBox1.Image = Image.FromFile("C:\\Users\\Josué\\Desktop\\Ahorcado\\"+(numImagen)+".png");
        }

    }
}
