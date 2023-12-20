/*
   Ingresar 5 números por consola, guardándolos en una variable escalar. Luego calcular y mostrar: el valor máximo, el valor mínimo y el promedio.
*/

using System;
using System.Linq;

namespace Ejercicios_de_la_1er_Clase
{
    internal class Program
    {
        static bool pedirArrayInt(out int[] array, int length, string mensaje, string mensajeError)
        {
            bool resultado = false;
            array = new int[length];

            if (length > 0 || !string.IsNullOrEmpty(mensaje) || !string.IsNullOrEmpty(mensajeError))
            {                
                bool condicion;
                int numeroIngresado;
                int[] arrayAux = new int[length];

                for (int i = 0; i < length; i++)
                {
                    //Console.WriteLine($"\n- Iteracion numero {i + 1}");
                    condicion = pedirValorInt(mensaje, mensajeError, out numeroIngresado);
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

        static bool calcularMaximo(int[] array, out int valorCalculado)
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

        static bool calcularMinimo(int[] array, out int valorCalculado)
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

        static bool calcularPromedio(int[] array, out decimal valorCalculado)
        {
            bool resultado = false;
            valorCalculado = -1;

            if (array != null && array.Length > 0)
            {
                int len = array.Length;
                int acumulador = 0;

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
        static void Main(string[] args)
        {
            int[] arrayNumerosInt = new int[5];
            int valorMaximo;
            int valorMinimo;
            decimal promedio;
            string mensajeError = "No se puede calcular el valor pedido, la serie de numeros está vacia o es nula.";


            Console.WriteLine("*** Ingrese cinco (5) numeros ***");

            if (pedirArrayInt(out arrayNumerosInt, arrayNumerosInt.Length, "Ingrese un numero tipo 'int' (entero): ", "Error! Ha ingresado un valor invalido..."))
            {
                Console.WriteLine(calcularMaximo(arrayNumerosInt, out valorMaximo)
                    ? $"\nEl valor maximo de esta serie de numeros es: {valorMaximo}"
                    : mensajeError);

                Console.WriteLine(calcularMinimo(arrayNumerosInt, out valorMinimo)
                    ? $"El valor minimo de esta serie de numeros es: {valorMinimo}"
                    : mensajeError);

                Console.WriteLine(calcularPromedio(arrayNumerosInt, out promedio)
                    ? $"El promedio de esta serie de numeros es: {promedio}"
                    : mensajeError);
            }

            Console.WriteLine("\nPresione cualquier tecla para cerrar el programa...");
            Console.ReadLine();
        }
    }
}
