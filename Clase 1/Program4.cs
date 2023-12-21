/*
   Un número perfecto es un entero positivo, que es igual a la suma de todos los enteros positivos (excluido el mismo) que son divisores del número.

    El primer número perfecto es 6, ya que los divisores de 6 son 1, 2 y 3; y 1 + 2 + 3 = 6.

    Escribir una aplicación que encuentre los 4 primeros números perfectos.
*/

using System;
using System.Collections.Generic;
using System.Runtime.Remoting;

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

        static bool EsNumeroPerfecto(int numero)
        {
            int sumaDivisores = 0;
            bool resultado = false;
            
             for (int i = 0; i <= numero; i++)
             {
                if (i != 0)
                {
                    if (numero % i == 0) sumaDivisores += i;
                }                        
             }

                if (sumaDivisores == numero) resultado = true;         

            return resultado;
        }

        static List<int> BuscarNumerosPerfectos(int cantidadBuscar)
        {
            List<int> list_numerosPerfectosEncontrados = new List<int>();
            int numero = 1;
            int numerosEncontrados = 0;
            
            while (numerosEncontrados < cantidadBuscar)
            {
                if (EsNumeroPerfecto(numero))
                {
                    Console.WriteLine($"Se ha encontrado un numero: {numero}");
                    numerosEncontrados++;
                    list_numerosPerfectosEncontrados.Add(numero);
                }
                numero++;
            }

            return list_numerosPerfectosEncontrados;
        }

        static void Main(string[] args)
        {
            char caracterIngresado;
            int numeroIngresado;
            List<int> list_numerosPerfectos = new List<int>();

            do
            {
                Console.WriteLine("\n***** Menu principal *****");

                if(pedirValorInt("Ingrese la cantidad de numeros perfectos que quiere buscar (int): ", "Error! Ha ingresado un valor invalido.", out numeroIngresado))
                {
                    list_numerosPerfectos = BuscarNumerosPerfectos(numeroIngresado);

                    Console.WriteLine(list_numerosPerfectos.Count > 1
                        ? $"Se encontraron los siguientes numeros perfectos. La cantidad ingresada a buscar era {numeroIngresado}: {string.Join(", ", list_numerosPerfectos)}"
                        : "No hay numeros perfectos para mostrar.");

                    caracterIngresado = pedirRespuestaYesOrNo("\nDesea seguir oprando el programa?", "Error! Ha ingresado un valor invalido.");
                    if (caracterIngresado == 'n') break;                    
                }                
            } while (true);

            Console.WriteLine("\nPresione cualquier tecla para cerrar el programa...");
            Console.ReadLine();
        }
    }
}
