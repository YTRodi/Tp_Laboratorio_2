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
            btnBinario.Enabled = false;
            btnDecimal.Enabled = false;
        }

        #region Métodos estáticos
        private static double Operar(string num1, string num2, string operador)
        {
            //Creo dos intancias del tipo Numero
            Numero aux1 = new Numero(num1);
            Numero aux2 = new Numero(num2);
            //retorno los valores.
            return Calculadora.Operar(aux1, aux2, operador);
        }

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
        private void btnOperar_Click(object sender, EventArgs e)
        {
            //(Esta bien crear las instancias aca? o hacerlo mediante un método estático?)

            //Numero aux1 = new Numero(txtBoxNumero1.Text);
            //Numero aux2 = new Numero(txtBoxNumero2.Text);
            //labelResultado.Text = (Calculadora.Operar(aux1,aux2, comboBoxOperaciones.Text)).ToString();
            labelResultado.Text = FormCalculadora.Operar(txtBoxNumero1.Text, txtBoxNumero2.Text, comboBoxOperaciones.Text).ToString();
            btnBinario.Enabled = true;
            btnDecimal.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            //Close();
            if (MessageBox.Show("Esta seguro de cerrar el formulario?", "Cerrando form...", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnBinario_Click(object sender, EventArgs e)
        {
            string aux = Numero.DecimalBinario(labelResultado.Text);
            labelResultado.Text = aux;

            btnDecimal.Enabled = true;
            btnBinario.Enabled = false;
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            labelResultado.Text = Numero.BinarioDecimal(labelResultado.Text);
            btnBinario.Enabled = true;
            btnDecimal.Enabled = false;
        }
        #endregion

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            //esto ponerlo en el boton de cerrar
            //FormClosingEventArgs = 
            if (MessageBox.Show("Esta re re re re seguro?","Cerrando form...",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;//lectura y escritura.
            }
        }
    }
}
