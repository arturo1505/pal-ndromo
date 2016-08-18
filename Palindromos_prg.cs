using System;
using System.Collections.Generic;
using System.Text;

namespace Palindromos
{
    class Program1
    {

        const int espalindromo = 1;
        const int noespalindromo = 0;

        static void Main(string[] args)
        {
 
            char[] ncarateres;
			string[] arrPalabras = new string[4];
 
            Console.WriteLine("Ingrese "+ arrPalabras.Length +" palabras: ");
			Console.WriteLine("							");
			
			for (int nindice = 0; nindice < arrPalabras.Length; nindice++)
			{
				 
				Console.WriteLine("	Favor de Capturar una palabra: ");
				string vpalabra = Console.ReadLine();
				arrPalabras[nindice]=vpalabra;
			}
			
			 Console.WriteLine("							");
			 Console.WriteLine("****** Resultado ********");
			 
			for (int i = 0; i < arrPalabras.Length; i++)
            {
				ncarateres = new char[arrPalabras[i].Length];
				ncarateres = arrPalabras[i].ToCharArray(0, arrPalabras[i].Length);
            
				if (ValidarPalabra(0, ncarateres, arrPalabras[i].Length) == espalindromo)
					Console.WriteLine("true");
				else
					Console.WriteLine("false");
			}
        }

        
        static int ValidarPalabra(int pos, char[] palabra, int largo)
        {
        
            if (palabra[pos] == palabra[largo - pos - 1])
            {
                if (pos < largo - pos)
                    return (ValidarPalabra(++pos, palabra, largo));
                else
                    return (espalindromo);
            }
			
            return (noespalindromo);
        }
    }
} 
