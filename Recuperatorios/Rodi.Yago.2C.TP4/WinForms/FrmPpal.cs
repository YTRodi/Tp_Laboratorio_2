using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntidadesHechas;

namespace WinForms
{
    public partial class FrmPpal : Form
    {
        /*
         LE PUEDO AGREGAR UN PROGRESSBAR CHIQUITO A CADA PAQUETE 
        DESDE EL PRIMER ESTADO HASTA EL ENTREGADO/FINALIZADO.
         */
        #region Atributos
        Correo correo;
        #endregion

        /// <summary>
        /// Constructor por defecto de FrmPpal
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
        }

        #region Eventos del formulario
        /// <summary>
        /// Manejador del evento Load que se encarga de instanciar
        /// un nuevo correo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_Load(object sender, EventArgs e)
        {
            this.correo = new Correo();
            PaqueteDAO.EventoErrorDAO += ErrorBD;
        }

        /// <summary>
        /// Manejador del evento "EventoErrorDAO" que muestra el mensaje del error
        /// en una ventana en formato modal.
        /// </summary>
        /// <param name="msgError"></param>
        private void ErrorBD(string msgError)
        {
            MessageBox.Show(msgError,
                    "ERROR",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
        }

        /// <summary>
        /// Manejador del evento FormClosing que se encarga de ejecutar
        /// el método FinEntregas() (Cierra todos los hilos secundiarios en ejecución).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }

        /// <summary>
        /// Manejador del evento Click que Se encargará de Asignar nuevos paquetes.
        /// Informando cada vez que cambia de estado el nuevo paquete.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

                nuevoPaquete.InformaEstado += this.paq_InformaEstado;

                this.correo += nuevoPaquete;

                this.ActualizarEstados();
            }
            catch (TrackingIDException tckIDEx)
            {
                MessageBox.Show(tckIDEx.Message,
                    "Notificación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo una excepción en el evento Click del botón Agregar.\nDETALLES:\n " + ex.Message,
                    "Notificación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Manejador del evento Click que se encargar de mostrar la información
        /// de todos los paquetes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Manejador del evento Click que se encarga de mostrar los detalles de un paquete
        /// que se encuentre con el estado en "Entregado".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método Actualizará los estados del Turno.
        /// 
        /// Si está en el hilo principal, llama recursivamente al mismo método 
        /// para luego poder ejecutar el método ActualizarEstados().
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Método que actualiza los listBox:
        ///  lstEstadoIngresado,
        ///  lstEstadoEntregado,
        ///  lstEstadoEnViaje
        ///  
        /// </summary>
        private void ActualizarEstados()
        {
            //Limpio las ListBox
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;

                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;

                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }

        /// <summary>
        /// Método que mostrará los datos del elemento y lo guardará en un archivo
        /// .txt en el escritorio.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!(elemento is null))
            {
                if(elemento is Paquete)
                    rtbMostrar.Text = elemento.ToString();
                else
                    rtbMostrar.Text = elemento.MostrarDatos(elemento);

                GuardaString.Guardar(rtbMostrar.Text, @"\salida.txt");
            }
        }
        #endregion  
    }
}
