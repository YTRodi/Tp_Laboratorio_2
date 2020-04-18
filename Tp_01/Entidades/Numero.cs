using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        #region Properties
        /// <summary>
        /// Propiedad sólo escritura validada.
        /// </summary>
        private string SetNumero//propiedad.
        {
            set
            {
                this.numero = ValidarNumero(value);
                //value representa el valor que asignamos a la propiedad.
            }
        }
        #endregion

        #region Constructores
        public Numero()
        {
            this.numero = default(double);//le asigno 0.
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        public Numero(double dblNumero) : this(dblNumero.ToString())
        {
            //Convierto el numero double en string. Asi puedo usar el constructor anterior.
        }
        #endregion

        #region Methods
        /// <summary>
        /// Valida el número en formato string que se ingresa.
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns>TODOOK=Retorna el número en formato double.//Sino retorna 0.</returns>
        public double ValidarNumero(string strNumero)
        {
            double retornoDbl = default(double);
            if (double.TryParse(strNumero, out retornoDbl))
            {
                return retornoDbl;
            }
            else
            {
                return 0;
            }
        }


        /// <summary>
        /// Convierte el string binario a decimal en formato string.
        /// </summary>
        /// <param name="numBinario"></param>
        /// <returns>El numero decimal en binario.</returns>
        public static string BinarioDecimal(string numBinario)
        {
            Numero numB = new Numero(numBinario);
            double numBConvertD = numB.numero;//guardo el atribuo double en numBConvertD
            //string retornoStr = string.Empty;
            int retorno = default(int);
            string errorMsg = "Error inválido";
            int residuo = 0;
            int exponente = 0;
            
            if(numBConvertD > 0)
            {
                do
                {
                    residuo = (int)numBConvertD % 10;//el residuo del número ingresado entre 10.
                    numBConvertD = numBConvertD / 10;
                    numBConvertD = Math.Floor(numBConvertD);//aca se podria poner el /10 y ahorro una línea.
                    retorno += (int)(residuo * Math.Pow(2, exponente));// 2 ^ nº cantidad (2^0, 2^1, 2^2...)
                    exponente++;//0, 1, 2, n cantidad de veces como tantos ciclos realice el bucle do while.
                } while (numBConvertD != 0);
            }
            else
            {
                return errorMsg;
            }

            return retorno.ToString();
        }


        /// <summary>
        /// Convierte un numero decimal a binario.
        /// </summary>
        /// <param name="numBin"></param>
        /// <returns>El numero decimal convertido en binario</returns>
        public static string DecimalBinario(string numBin)
        {
            Numero numD = new Numero(numBin);
            double numDecimal = Math.Floor(numD.numero);
            string retornoDeciBinario = string.Empty;
            string errorMsg = "Error inválido";

            if(numDecimal > 0)
            {
                while(numDecimal != 0)
                {
                    ////los num pares van a dar siempre residuos en 0 - impares residuo 1
                    if (numDecimal % 2 == 0)
                    {
                        retornoDeciBinario = "0" + retornoDeciBinario;
                    }
                    else
                    {
                        retornoDeciBinario = "1" + retornoDeciBinario;
                    }
                    numDecimal /= 2;
                    numDecimal = Math.Floor(numDecimal);
                }
            }
            else
            {
                retornoDeciBinario = errorMsg;
            }

            return retornoDeciBinario;
        }


        /// <summary>
        /// Convierte un numero decimal a binario.
        /// </summary>
        /// <param name="numDouble"></param>
        /// <returns>El numero decimal convertido en binario</returns>
        public static string DecimalBinario(double numDouble)
        {
            //Retorna solo la parte entera.
            //Y reutilizo código.
            return DecimalBinario(numDouble.ToString());//convierto el numeroDouble para poder usar la sobrecarga.
        }
        #endregion

        #region Operadores
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            double retornoDb = default(double);

            if(num2.numero == 0)
            {
                retornoDb = double.MinValue;
            }
            else
            {
                retornoDb = num1.numero / num2.numero;
            }
            return retornoDb;
        }
        #endregion
    }
}
