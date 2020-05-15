using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
	public class Jornada
	{
		#region Atributos
		private List<Alumno> listaAlumnos;
		private Universidad.EClases clase;
		private Profesor instructor;
		#endregion

		#region Properties
		public List<Alumno> Alumnos
		{
			get
			{
				return this.listaAlumnos;
			}
			set
			{
				this.listaAlumnos = value;
			}
		}
		public Universidad.EClases Clase
		{
			get
			{
				return this.clase;
			}
			set
			{
				this.clase = value;
			}
		}
		public Profesor Instructor
		{
			get
			{
				return this.instructor;
			}
			set
			{
				this.instructor = value;
			}
		}
		#endregion

		#region Constructores
		private Jornada()
		{
			//this.listaAlumnos = new List<Alumno>();
			this.Alumnos = new List<Alumno>();
		}
		public Jornada(Universidad.EClases clase, Profesor instructor) : this()
		{
			this.Clase = clase;
			this.Instructor = instructor;
		}
		#endregion

		#region Métodos
		public bool Guardar(Jornada jornada)
		{
			return true;
		}

		public string Leer()
		{
			return "";
		}
		#endregion

		#region Operaciones
		public static bool operator ==(Jornada j, Alumno a)
		{
			bool participaEnLaClase = false;
			foreach (Alumno item in j.listaAlumnos)
			{
				if (item == a)
					participaEnLaClase = true;
			}
			return participaEnLaClase;
		}

		public static bool operator !=(Jornada j, Alumno a)
		{
			return !(j == a);
		}

		public static Jornada operator +(Jornada j, Alumno a)
		{
			if (j != a)
				j.listaAlumnos.Add(a);
			return j;
		}
		#endregion

		#region Override
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Clase: {this.Clase}");
			sb.AppendLine($"Profesor: {this.Instructor.ToString()}");

			foreach (Alumno item in this.listaAlumnos)
			{
				sb.AppendLine(item.ToString());
			}
			return sb.ToString();
		}
		#endregion

	}
}
