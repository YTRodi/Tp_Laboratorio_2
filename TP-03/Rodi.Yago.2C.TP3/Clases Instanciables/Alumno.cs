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
		private Universidad.EClases claseQueToma;
		private EEstadoCuenta estadoCuenta;
		#endregion

		#region Constructores
		public Alumno()
		{
		}
		public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
			: base(id, nombre, apellido, dni, nacionalidad)
		{
			this.claseQueToma = claseQueToma;
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

			if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
				cumpleRequisitos = true;

			return cumpleRequisitos;
		}

		public static bool operator !=(Alumno a, Universidad.EClases clase)
		{
			//return !(a == clase);
			//return a != clase;
			return a.claseQueToma == clase;
		}
		#endregion

		#region Override
		protected override string MostrarDatos()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendFormat(base.MostrarDatos());
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
					sb.AppendFormat("ESTADO DE CUENTA: Cuota al día\n");//tal cuál el tp
					break;

                case EEstadoCuenta.Deudor:
					sb.AppendFormat("ESTADO DE CUENTA: Deudor\n");

					break;
                case EEstadoCuenta.Becado:
					sb.AppendFormat("ESTADO DE CUENTA: Becado\n");
					break;
            }
			sb.AppendFormat($"{this.ParticiparEnClase()}");

			return sb.ToString();
		}

		protected override string ParticiparEnClase()
		{
			return $"TOMA CLASES DE {this.claseQueToma}.\n";
		}
		public override string ToString()
		{
			return this.MostrarDatos();
		}
		#endregion

	}
}
