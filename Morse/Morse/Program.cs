using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using Conversor;


namespace Morse
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase;
            string morse;
            string texto;
            do
            {
                Console.Clear();
                Console.WriteLine("Frase que desea convertir a morse (solo letras)");
                frase = Console.ReadLine();
            } while (Regex.IsMatch(frase, @"^[a-zA-Z]+") == false);

            morse = ConversorDeMorse.TextoAMorse(frase.ToUpper());

            string archivo = @"..\..\..\ArchivoMorse.txt";
            if (!File.Exists(archivo))
            {
                var file = File.Create(archivo);
                file.Close();
            }
            File.WriteAllText(archivo, morse);

            morse = File.ReadAllText(archivo);
            texto = ConversorDeMorse.MorseATexto(morse);
            Console.WriteLine("\nCodigo morse: " + morse + "\nTexto convertido del codigo morse: " + texto);

            ConversorDeMorse.ArchivoAMp3(archivo);
        }
    }
}
