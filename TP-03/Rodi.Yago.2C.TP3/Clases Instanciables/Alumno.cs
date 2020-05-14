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
		public enum EEstadoCuenta
		{
			AlDia,
			Deudor,
			Becado
		}
		#endregion
		#region Atributos
		private Universidad.EClases ClaseQueToma;
		private EEstadoCuenta estadoCuenta;
		#endregion

		#region Constructores
		public Alumno()
		{
		}
		public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
			: base(id, nombre, apellido, dni, nacionalidad)
		{
			this.ClaseQueToma = claseQueToma;
		}
		public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
			: this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
		{
			this.estadoCuenta = estadoCuenta;
		}

		#endregion

		#region Operaciones
		public static bool operator ==(Alumno a, Universidad.EClases clase)
		{
			bool cumpleRequisitos = false;

			if(a.ClaseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
				cumpleRequisitos = true;

			return cumpleRequisitos;
		}

		public static bool operator !=(Alumno a, Universidad.EClases clase)
		{
			//return !(a == clase);
			return a != clase;
		}
		#endregion

		#region Override
		protected override string MostrarDatos()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(base.MostrarDatos());
			sb.AppendLine($"Clase que toma: {this.ParticiparEnClase()}");
			sb.AppendLine($"Estado de cuenta: {this.estadoCuenta}");//cuota al dia, esta becado, deudor
			return sb.ToString();
		}

		protected override string ParticiparEnClase()
		{
			return $"Toma clase de {this.ClaseQueToma}.";
		}
		public override string ToString()
		{
			return this.MostrarDatos();
		}
		#endregion

	}
}
