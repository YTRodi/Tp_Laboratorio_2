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
		/// <summary>
		/// Enumerado que contiene los dos tipos de nacionalidad.
		/// </summary>
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
		/// <summary>
		/// Propiedad de lectura y escritura (con valicación),
		/// que retorna el nombre de la Persona.
		/// </summary>
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

		/// <summary>
		/// Propiedad de lectura y escritura (con valicación),
		/// que retorna el apellido de la Persona.
		/// </summary>
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

		/// <summary>
		/// Propiedad de lectura y escritura,
		/// que retorna la nacionalidad de la Persona.
		/// </summary>
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

		/// <summary>
		/// Propiedad de lectura y escritura (con validación, primer sobrecarga del método
		/// ValidarDni()), que retorna el dni de la Persona.
		/// </summary>
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

		/// <summary>
		/// Propiedad de lectura y escritura (con validación, segunda sobrecarga del método
		/// ValidarDni()), que retorna el dni de la Persona.
		/// </summary>
		public string StringToDNI
		{
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad, value);
			}
		}
		#endregion

		#region Constructores
		/// <summary>
		/// Constructor por defecto de Persona.
		/// </summary>
		public Persona()
		{
		}

		/// <summary>
		/// Constructor que inicializa los atributos:
		/// - nombre.
		/// - apellido.
		/// - nacionalidad.
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="nacionalidad"></param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
		{
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.Nacionalidad = nacionalidad;
        }

		/// <summary>
		/// Constructor que reutiliza el constructor anterior e inicializa
		/// el atributo: 
		/// - dni (en formato int).
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
			:this(nombre,apellido,nacionalidad)
		{
			this.DNI = dni;
		}

		/// <summary>
		/// Constructor que reutiliza el constructor anterior e inicializa
		/// el atributo: 
		/// - dni (en formato string).
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
			: this(nombre, apellido, nacionalidad)
		{
			this.StringToDNI = dni;
		}
		#endregion

		#region Métodos
		/// <summary>
		/// Método que valida la nacionalidad y el rango que puede tener el dni.
		/// </summary>
		/// <param name="nacionalidad"></param>
		/// <param name="dato"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Método que valida que el dni sea solo de números y llama a la 
		/// sobrecargar anterior.
		/// Caso contrario, lanza la excepción DniInvalidoException.
		/// </summary>
		/// <param name="nacionalidad"></param>
		/// <param name="dato"></param>
		/// <returns></returns>
		private int ValidarDni(ENacionalidad nacionalidad, string dato)
		{
			int retornoDniInt = default(int);

			if (int.TryParse(dato, out retornoDniInt))
				retornoDniInt = ValidarDni(nacionalidad, retornoDniInt);
			else
				throw new DniInvalidoException();

			return retornoDniInt;
		}

		/// <summary>
		/// Método que valida el nombre y apellido de la persona.
		/// </summary>
		/// <param name="dato"></param>
		/// <returns></returns>
		private string ValidarNombreApellido(string dato)
		{
			Regex expresionRegular = new Regex("^[a-zA-ZÁÉÍÓÚáéíóú]*$");
			string retornoStr = null;

			if (expresionRegular.IsMatch(dato))
				retornoStr = dato;

			return retornoStr;
		}
		#endregion

		#region Override
		/// <summary>
		/// Sobrescritura del método ToString() que expone
		/// los datos de la Persona.
		/// </summary>
		/// <returns></returns>
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
