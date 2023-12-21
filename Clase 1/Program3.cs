/*
   Mostrar por pantalla todos los números primos que haya hasta el número que ingrese el usuario por consola.

    Validar que el dato ingresado por el usuario sea un número.

    Volver a pedir el dato hasta que sea válido o el usuario ingrese "salir".

    Si ingresa "salir", cerrar la consola.

    Al finalizar, preguntar al usuario si desea volver a operar. Si la respuesta es afirmativa, iterar. De lo contrario, cerrar la consola.
*/

using System;
using System.Collections.Generic;

namespace Ejercicios_de_la_1er_Clase
{
    internal class Program
    {
        static bool pedirArrayDecimal(out decimal[] array, int length, string mensaje, string mensajeError)
        {
            bool resultado = false;
            array = new decimal[length];

            if (length > 0 || !string.IsNullOrEmpty(mensaje) || !string.IsNullOrEmpty(mensajeError))
            {                
                bool condicion;
                decimal numeroIngresado;
                decimal[] arrayAux = new decimal[length];

                for (int i = 0; i < length; i++)
                {
                    //Console.WriteLine($"\n- Iteracion numero {i + 1}");
                    condicion = pedirValorDecimal(mensaje, mensajeError, out numeroIngresado);
                    if (condicion)
                    {
                        arrayAux[i] = numeroIngresado;
                        resultado = true;
                    }
                }
                array = arrayAux;
            }

            return resultado;
        }
        static bool pedirValorDecimal(string mensaje, string mensajeError, out decimal valorDecimal)
        {
            bool resultado = false;
            valorDecimal = -1;

            if (!string.IsNullOrEmpty(mensaje) || !string.IsNullOrEmpty(mensajeError))
            {
                while (true)
                {
                    Console.WriteLine(mensaje);
                    if (decimal.TryParse(Console.ReadLine(), out decimal valorIngresado))
                    {
                        //Console.WriteLine($"Ingreso: {valorIngresado}");
                        valorDecimal = valorIngresado;
                        resultado = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(mensajeError);
                    }
                }
            }
            
            return resultado;
        }

        static bool pedirValorInt(string mensaje, string mensajeError, out int valorInt)
        {
            bool resultado = false;
            valorInt = -1;

            if (!string.IsNullOrEmpty(mensaje) || !string.IsNullOrEmpty(mensajeError))
            {
                while (true)
                {
                    Console.WriteLine(mensaje);
                    if (int.TryParse(Console.ReadLine(), out int valorIngresado))
                    {
                        //Console.WriteLine($"Ingreso: {valorIngresado}");
                        valorInt = valorIngresado;
                        resultado = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine(mensajeError);
                    }
                }
            }

            return resultado;
        }

        static bool calcularMaximo(decimal[] array, out decimal valorCalculado)
        {
            bool resultado = false;
            valorCalculado = -1;

            if (array != null && array.Length > 0)
            {
                valorCalculado = array[0];
                int len = array.Length;
                for (int i = 1; i < len; i++)
                {
                    if (valorCalculado < array[i])
                    {
                        valorCalculado = array[i];
                    }
                }
                resultado = true;
            }

            return resultado;
        }

        static bool calcularMinimo(decimal[] array, out decimal valorCalculado)
        {
            bool resultado = false;
            valorCalculado = -1;

            if (array != null && array.Length > 0)
            {
                valorCalculado = array[0];
                int len = array.Length;
                for (int i = 1; i < len; i++)
                {
                    if (valorCalculado > array[i])
                    {
                        valorCalculado = array[i];
                    }
                }
                resultado = true;
            }

            return resultado;
        }

        static bool calcularPromedio(decimal[] array, out decimal valorCalculado)
        {
            bool resultado = false;
            valorCalculado = -1;

            if (array != null && array.Length > 0)
            {
                int len = array.Length;
                decimal acumulador = 0;

                for (int i = 1; i < len; i++)
                {
                    acumulador += array[i];
                }

                if (acumulador > array.Length)
                {
                    valorCalculado = acumulador / len;
                    resultado = true;
                }               
            }

            return resultado;
        }

        static decimal potenciarNumero(decimal numero, int potenciador)
        {
            decimal resultado = numero;

            for (int i = 1; i <= potenciador - 1; i++)
            {
                resultado = resultado * numero;
            }

            return resultado;
        }

        static char pedirRespuestaYesOrNo(string mensaje, string mensajeError)
        {
            string valorIngresado;
            char respuesta = ' ';
            bool condicion = true;

            do
            {
                Console.WriteLine(mensaje);
                Console.WriteLine("Ingrese 's' o 'n': ");
                valorIngresado = Console.ReadLine();

                if ((!string.IsNullOrEmpty(valorIngresado)) && (char.TryParse(valorIngresado.ToLower(), out respuesta)) && (respuesta == 's' || respuesta == 'n'))
                {
                    //Console.WriteLine($"El usuario ingreso por consola: {respuesta}");
                    condicion = false;
                }
                else
                {
                    Console.WriteLine(mensajeError);
                }
            } while (condicion);

            return respuesta;
        }

        static bool EsNumeroPrimo(int numero)
        {
            bool resultado = true;

            if (numero < 2)
            {
                resultado = false;
            }
            for (int i = 2; i <= Math.Sqrt(numero); i++)
            {
                if(numero % i == 0)
                {
                    resultado = false;
                    break;
                }
            }

            return resultado;
        }

        static List<int> calcularNumerosPrimos(int limite)
        {
            List<int> list_primos = new List<int>();

            for (int i = 2; i <= limite; i++) 
            {
                if (EsNumeroPrimo(i))
                {
                    list_primos.Add(i);
                }                
            }

            return list_primos;
        }

        static void Main(string[] args)
        {
            char caracterIngresado;
            int numeroIngresado;
            List<int> list_primos = new List<int>();

            do
            {
                Console.WriteLine("\n***** Menu principal *****");

                if(pedirValorInt("Ingrese un numero tipo entero (int): ", "Error! Ha ingresado un valor invalido.", out numeroIngresado))
                {
                    list_primos = calcularNumerosPrimos(numeroIngresado);

                    Console.WriteLine(list_primos.Count > 1
                        ? $"Numeros primos hasta {numeroIngresado}: {string.Join(", ", list_primos)}"
                        : "No hay numeros primos para mostrar.");

                    caracterIngresado = pedirRespuestaYesOrNo("\nDesea seguir oprando el programa?", "Error! Ha ingresado un valor invalido.");
                    if (caracterIngresado == 'n') break;                    
                }                
            } while (true);

            Console.WriteLine("\nPresione cualquier tecla para cerrar el programa...");
            Console.ReadLine();
        }
    }
}
