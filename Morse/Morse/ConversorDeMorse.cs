using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Conversor
{
    class ConversorDeMorse
    {
        static Dictionary<char, string> DiccionarioMorse = new Dictionary<char, string>()
        {
            {'A' , ".-"},
            {'B' , "-..."},
            {'C' , "-.-."},
            {'D' , "-.."},
            {'E' , "."},
            {'F' , "..-."},
            {'G' , "--."},
            {'H' , "...."},
            {'I' , ".."},
            {'J' , ".---"},
            {'K' , "-.-"},
            {'L' , ".-.."},
            {'M' , "--"},
            {'N' , "-."},
            {'O' , "---"},
            {'P' , ".--."},
            {'Q' , "--.-"},
            {'R' , ".-."},
            {'S' , "..."},
            {'T' , "-"},
            {'U' , "..-"},
            {'V' , "...-"},
            {'W' , ".--"},
            {'X' , "-..-"},
            {'Y' , "-.--"},
            {'Z' , "--.."},
        };

        public static string TextoAMorse(string texto)
        {
            string morse = "";

            for (int i = 0; i < texto.Length; i++)
            {
                if (texto[i] == ' ')
                {
                    morse += "/ ";
                }
                else
                {
                    morse += DiccionarioMorse[texto[i]] + " ";
                }
            }

            return morse;
        }

        public static string MorseATexto(string morse)
        {
            string texto = "";
            string letra = "";

            for (int i = 0; i < morse.Length; i++)
            {
                if (morse[i] == '/')
                {
                    texto += ' ';
                }
                else if (morse[i] != ' ')
                {
                    letra += morse[i];
                }
                else
                {
                    foreach (KeyValuePair<char, string> item in DiccionarioMorse)
                    {
                        if (letra == item.Value)
                        {
                            texto += item.Key;
                            letra = "";
                        }
                    }
                }
            }
            return texto;
        }

        public static void ArchivoAMp3(string filepath)
        {
            StreamReader file = new StreamReader(@filepath, true);

            byte[] punto = File.ReadAllBytes("punto.mp3");
            byte[] raya = File.ReadAllBytes("raya.mp3");

            string morse = file.ReadLine();
            string texto = MorseATexto(morse);

            string pathdestino = @"..\..\..\audio.mp3";

            int aux = 0;
            List<byte[]> ListaDeAudios = new List<byte[]>();
            
            if (!File.Exists(@pathdestino))
            {
                FileStream Archivo = File.Create(@pathdestino);
                Archivo.Close();
            }

            for (int i = 0; i < morse.Length; i++)
            {
                if (morse[i] != ' ')
                {
                    if (morse[i] == '.')
                    {
                        ListaDeAudios.Add(punto);
                    }
                    else if (morse[i] == '-')
                    {
                        ListaDeAudios.Add(raya);
                    }
                }
            }

            for (int i = 0; i < ListaDeAudios.Count; i++)
            {
                aux += ListaDeAudios[i].Length;
            }

            byte[] audio = new byte[aux];
            ListaDeAudios[0].CopyTo(audio, 0);

            aux = ListaDeAudios[0].Length;

            for (int i = 1; i < ListaDeAudios.Count; i++)
            {
                ListaDeAudios[i].CopyTo(audio, aux);
                aux += ListaDeAudios[i].Length;
            }

            File.WriteAllBytes(@pathdestino, audio);
        }
    }
}
