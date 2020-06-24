using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Inmobiliaria
{
    public class Helper
    {
        public static float Valor(string tipoDeOperacion, int precio)
        {
            float ValorDelInmueble;
            if (tipoDeOperacion == Convert.ToString((TipoDeOperacion)1))
            {
                ValorDelInmueble = precio + (precio * 21 / 100) + (precio * 10 / 100) + 10000;
            }
            else
            {
                ValorDelInmueble = (precio * 2 / 100) + (precio * 5 / 1000);
            }
            return ValorDelInmueble;
        }

        public static void Escribir(int id, string prop, string operacion, float tamanio, int cantidadDeBaños, int cantidadDeHabitaciones, string domicilio, int precio, bool estado, float valorDelInmueble, string path)
        {
            if (!File.Exists(@path))
            {
                FileStream Archivo = File.Create(@path);
            }
            using (StreamWriter file = new StreamWriter(@path, true))
            {
                file.WriteLine(id + ";" + prop + ";" + operacion + ";" + tamanio + ";" + cantidadDeBaños + ";" + cantidadDeHabitaciones + ";" + domicilio + ";" + precio + ";" + estado + ";" + valorDelInmueble);
            }
        }
    }
}
