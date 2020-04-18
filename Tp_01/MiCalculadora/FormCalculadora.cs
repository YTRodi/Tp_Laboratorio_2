using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form 
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        #region Métodos estáticos
        /// <summary>
        /// Crea dos intancias de la clase Numero y usar el método Operar.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado del método Operar.</returns>
        private static double Operar(string num1, string num2, string operador)
        {
            //Creo dos intancias del tipo Numero
            Numero aux1 = new Numero(num1);
            Numero aux2 = new Numero(num2);
            //retorno los valores.
            return Calculadora.Operar(aux1, aux2, operador);
        }

        /// <summary>
        /// Limpia la pantalla del formulario.
        /// </summary>
        private  void Limpiar()
        {
            btnBinario.Enabled = false;
            btnDecimal.Enabled = false;
            labelResultado.ResetText();
            comboBoxOperaciones.ResetText();
            txtBoxNumero1.Clear();
            txtBoxNumero2.Clear();   
        }
        #endregion


        //MANEJADORES DE EVENTOS.
        #region Manejadores de eventos.
        /// <summary>
        /// Botón que muestra en el label el resultado de la operacion de los dos numeros ingresados y el tipo de operación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            labelResultado.Text = FormCalculadora.Operar(txtBoxNumero1.Text, txtBoxNumero2.Text, comboBoxOperaciones.Text).ToString();
            btnBinario.Enabled = true;
            btnDecimal.Enabled = false;
        }

        /// <summary>
        /// Botón que llama al método que limpia el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Botón que cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Botón que convierte el número resultante a binario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBinario_Click(object sender, EventArgs e)
        {
            string aux = Numero.DecimalBinario(labelResultado.Text);
            labelResultado.Text = aux;

            btnDecimal.Enabled = true;
            btnBinario.Enabled = false;
        }

        /// <summary>
        /// Botón que convierte el número binario a decimal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecimal_Click(object sender, EventArgs e)
        {
            labelResultado.Text = Numero.BinarioDecimal(labelResultado.Text);
            btnBinario.Enabled = true;
            btnDecimal.Enabled = false;
        }
        #endregion

        /// <summary>
        /// Evento que cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de cerrar el formulario?", "Cerrando form...", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Evento que carga por defecto parámetros.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            btnBinario.Enabled = false;
            btnDecimal.Enabled = false;
        }
    }
}
