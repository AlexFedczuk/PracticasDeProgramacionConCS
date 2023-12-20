/*
   Ingresar un número y mostrar el cuadrado y el cubo del mismo. Se debe validar que el número sea mayor que cero, caso contrario, mostrar el mensaje: "ERROR. ¡Reingresar número!".
*/

using System;

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


        static void Main(string[] args)
        {           
            decimal numeroIngresado;
            bool condicion;
            decimal numeroCalculadoAlCuadrado;
            decimal numeroCalculadoAlCubo;
            int potenciaCuadrado = 2;
            int potenciaCubo = 3;

            do
            {
                condicion = pedirValorDecimal("Ingrese un numero y mayor a 0 (cero): ", "Error! Ha ingresado un valor invalido.", out numeroIngresado);
                if (numeroIngresado < 1)
                {
                    Console.WriteLine("ERROR. ¡Reingresar número!");
                }
            }while(condicion == false || numeroIngresado < 1);

            numeroCalculadoAlCuadrado = potenciarNumero(numeroIngresado, potenciaCuadrado);
            numeroCalculadoAlCubo = potenciarNumero(numeroIngresado, potenciaCubo);

            Console.WriteLine($"El numero (ingresado) {numeroIngresado} a la potencia de {potenciaCuadrado} da igual a {numeroCalculadoAlCuadrado}");
            Console.WriteLine($"El numero (ingresado) {numeroIngresado} a la potencia de {potenciaCubo} da igual a {numeroCalculadoAlCubo}");

            Console.WriteLine("\nPresione cualquier tecla para cerrar el programa...");
            Console.ReadLine();
        }
    }
}
