using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
	{
		#region Enumerados
		/// <summary>
		/// Enumerado que contiene los tres tipos de estado de cuenta.
		/// </summary>
		public enum EEstadoCuenta
		{
			AlDia,
			Deudor,
			Becado
		}
		#endregion

		#region Atributos
		private Universidad.EClases claseQueToma;
		private EEstadoCuenta estadoCuenta;
		#endregion

		#region Constructores
		/// <summary>
		/// Constructor por defecto de Alumno.
		/// </summary>
		public Alumno()
		{
		}

		/// <summary>
		/// Constructor que llama la base e inicializa el atributo:
		/// - ClaseQueToma.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		/// <param name="claseQueToma"></param>
		public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
			: base(id, nombre, apellido, dni, nacionalidad)
		{
			this.claseQueToma = claseQueToma;
		}

		/// <summary>
		/// Constructor que reutiliza el constructor anterior e inicializa
		/// el atributo: 
		/// - estadoCuenta.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		/// <param name="claseQueToma"></param>
		/// <param name="estadoCuenta"></param>
		public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
			: this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
		{
			this.estadoCuenta = estadoCuenta;
		}
		#endregion

		#region Operaciones
		/// <summary>
		/// Sobrecarga del operador "==" que compara si un 
		/// Alumno cumple los requisitos para tomar esa clase.
		/// </summary>
		/// <param name="a"></param>
		/// <param name="clase"></param>
		/// <returns></returns>
		public static bool operator ==(Alumno a, Universidad.EClases clase)
		{
			bool cumpleRequisitos = false;

			if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
				cumpleRequisitos = true;

			return cumpleRequisitos;
		}

		/// <summary>
		/// Sobrecarga del operador "!=" que compara si un
		/// Alumno no toma esa clase
		/// </summary>
		/// <param name="a"></param>
		/// <param name="clase"></param>
		/// <returns></returns>
		public static bool operator !=(Alumno a, Universidad.EClases clase)
		{
			return a.claseQueToma == clase;
		}
		#endregion

		#region Override
		/// <summary>
		/// Método que expone los datos del Alumno.
		/// </summary>
		/// <returns>Los datos del Alumno.</returns>
		protected override string MostrarDatos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat(base.MostrarDatos());

			if(this.estadoCuenta is EEstadoCuenta.AlDia)
				sb.AppendFormat("ESTADO DE CUENTA: Cuota al día\n");//tal cuál el tp
			else
				sb.AppendFormat($"ESTADO DE CUENTA: {this.estadoCuenta}\n");

			sb.AppendFormat($"{this.ParticiparEnClase()}");

			return sb.ToString();
		}

		/// <summary>
		/// Implementación del método abstracto de la clase Universitario.
		/// </summary>
		/// <returns>Las clases que toma el Alumno.</returns>
		protected override string ParticiparEnClase()
		{
			return $"TOMA CLASES DE {this.claseQueToma}.\n";
		}

		/// <summary>
		/// Sobrescritura del método ToString() que llama al
		/// método MostrarDatos().
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.MostrarDatos();
		}
		#endregion

	}
}
