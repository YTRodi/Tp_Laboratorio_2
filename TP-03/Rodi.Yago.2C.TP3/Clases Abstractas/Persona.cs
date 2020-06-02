using Excepciones;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Persona
	{
		#region Enumerados
		public enum ENacionalidad
		{
			Argentino,
			Extranjero
		}
		#endregion

		#region Atributos
		private string nombre;
		private string apellido;
		private ENacionalidad nacionalidad;
		private int dni;
		#endregion

		#region Properties
		public string Nombre 
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = this.ValidarNombreApellido(value);
			}
		}
		public string Apellido
		{
			get
			{
				return this.apellido;
			}
			set
			{
				this.apellido = this.ValidarNombreApellido(value);
			}
		}
		public ENacionalidad Nacionalidad
		{
			get
			{
				return this.nacionalidad;
			}
			set
			{
				this.nacionalidad = value;
			}
		}
		public int DNI
		{
			get
			{
				return this.dni;
			}
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad, value);
			}
		}

		public string StringToDNI
		{
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad, value);
			}
		}
		#endregion

		#region Constructores
		public Persona()
		{
		}

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
		{
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Nacionalidad = nacionalidad;
        }

		public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
			:this(nombre,apellido,nacionalidad)
		{
			this.DNI = dni;
		}
		public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
			: this(nombre, apellido, nacionalidad)
		{
			this.StringToDNI = dni;
		}
		//public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
		//	: this(nombre, apellido, null, nacionalidad)
		//{

		//}
		//public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
		//	: this(nombre, apellido, dni.ToString(), nacionalidad)
		//{

		//}
		//public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
		//{
		//	this.Nombre = nombre;
		//	this.Apellido = apellido;
		//	this.Nacionalidad = nacionalidad;
		//	this.StringToDNI = dni;
		//}

		#endregion

		#region Métodos
		private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
			int retornoDni = default(int);

			switch (nacionalidad)
			{
				case ENacionalidad.Argentino:
					if(dato >= 1 && dato <= 89999999)
						retornoDni = dato;
					else
						throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
					break;

				case ENacionalidad.Extranjero:
					if (dato >= 90000000 && dato < 99999999)
						retornoDni = dato;
					else
						throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
					break;
			}

			return retornoDni;
		}
		private int ValidarDni(ENacionalidad nacionalidad, string dato)
		{
			int retornoDniInt = default(int);

			if (int.TryParse(dato, out retornoDniInt))
				retornoDniInt = ValidarDni(nacionalidad, retornoDniInt);
			else
				throw new DniInvalidoException();

			return retornoDniInt;
		}

		private string ValidarNombreApellido(string dato)
		{
			Regex expresionRegular = new Regex("^[a-zA-ZÁÉÍÓÚáéíóú]*$");
			string retornoStr = null;//Caso contrario, no se cargará.

			if (expresionRegular.IsMatch(dato))
				retornoStr = dato;

			return retornoStr;
		}
		#endregion

		#region Override
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"NOMBRE COMPLETO: {this.Apellido}, {this.Nombre}");
			sb.AppendLine($"NACIONALIDAD: {this.Nacionalidad}");
			return sb.ToString();
		}
		#endregion

	}
}
