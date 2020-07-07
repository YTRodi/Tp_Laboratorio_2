using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EntidadesHechas
{
    public static class PaqueteDAO
    {
        #region Delegados y eventos para posibles errores
        public delegate void DelegadoBDDAO(string msgError);
        public static event DelegadoBDDAO EventoErrorDAO;
        #endregion

        #region Atributos para la conexión a la BD
        private static string strConnection = @"Data Source = .\SQLEXPRESS; Database = correo-sp-2017; Trusted_Connection = True;";
        private static SqlConnection connectionDB;
        private static SqlCommand commandDB;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructo estático de PaqueteDAO que establece las conexiones a la base de datos.
        /// </summary>
        static PaqueteDAO()
        {
            connectionDB = new SqlConnection(strConnection);
            commandDB = new SqlCommand();
            commandDB.Connection = connectionDB;
            commandDB.CommandType = System.Data.CommandType.Text;
        }
        #endregion

        #region Métodos para las Querys
        /// <summary>
        /// Método estático que inserta un paquete en la tabla Paquetes.
        /// </summary>
        /// <param name="p">El paquete a insertar</param>
        /// <returns></returns>
        public static bool Insertar(Paquete p)
        {
            bool pudoInsertar = false;
            string queryInsertarP = $"INSERT INTO Paquetes (direccionEntrega, trackingID, alumno) " +
                                    $"VALUES(@drEntrega, @trID, @alumno)";
            string datosAlumno = "Rodi Yago";

            try
            {
                if (connectionDB.State != System.Data.ConnectionState.Open)
                    connectionDB.Open();

                commandDB.CommandText = queryInsertarP;

                commandDB.Parameters.Clear();
                commandDB.Parameters.AddWithValue("@drEntrega", p.DireccionEntrega);
                commandDB.Parameters.AddWithValue("@trID", p.TrackingID);
                commandDB.Parameters.AddWithValue("@alumno", datosAlumno);

                commandDB.ExecuteNonQuery();

                pudoInsertar = true;
            }
            catch (Exception e)
            {
                PaqueteDAO.EventoErrorDAO(e.Message);
            }
            finally
            {
                if (connectionDB.State != System.Data.ConnectionState.Closed)
                    connectionDB.Close();
            }
            return pudoInsertar;
        }
        #endregion
    }
}
