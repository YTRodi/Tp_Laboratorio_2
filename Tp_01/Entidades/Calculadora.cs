using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora 
    {
        /// <summary>
        /// Método estático que validar el operador que entra por parámetro.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns>El operador.</returns>
        private static string ValidarOperador(string operador)
        {
            switch(operador)
            {
                case "+":
                    break;

                case "-":
                    break;

                case "/":
                    break;

                case "*":
                    break;

                default:
                    return "+";
            }
            return operador;
        }

        /// <summary>
        /// Método estático que realiza la operación matemática específicada por el operador.
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operación.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double retornoDouble = default(double);
            switch(ValidarOperador(operador))
            {
                case "+":
                    retornoDouble = num1 + num2;
                    break;

                case "-":
                    retornoDouble = num1 - num2;
                    break;

                case "/":
                    retornoDouble = num1 / num2;
                    break;

                case "*":
                    retornoDouble = num1 * num2;
                    break;
            }
            return retornoDouble;
        }

    }
}
