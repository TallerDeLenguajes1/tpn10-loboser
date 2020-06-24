using System;
using System.IO;
using System.Collections.Generic;
using Inmobiliaria;

namespace Inmobiliaria
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 0;
            string path = @"C:\Repogit\tp10\tpn10-loboser\Inmobiliaria\Inmobiliaria\archivo.csv";
            string[] lineas = File.ReadAllLines(@path);

            for (int i = 0; i < lineas.Length; i++)
            {
                Console.WriteLine(lineas[i]);
                var valores = lineas[i].Split(';');

                Propiedad NuevaPropiedad = new Propiedad();

                NuevaPropiedad.Id = id;
                NuevaPropiedad.Prop = valores[0];
                NuevaPropiedad.Operacion = valores[1];
                NuevaPropiedad.Tamanio = 50;
                NuevaPropiedad.CantidadDeBaños = 1;
                NuevaPropiedad.CantidadDeHabitaciones = 5;
                NuevaPropiedad.Domicilio = "Asd";
                NuevaPropiedad.Precio = 10000;
                NuevaPropiedad.Estado = true;
                NuevaPropiedad.ValorDelInmueble = Helper.Valor(NuevaPropiedad.Operacion,NuevaPropiedad.Precio);

                Helper.Escribir(NuevaPropiedad.Id, NuevaPropiedad.Prop, NuevaPropiedad.Operacion, NuevaPropiedad.Tamanio, NuevaPropiedad.CantidadDeBaños, NuevaPropiedad.CantidadDeHabitaciones, NuevaPropiedad.Domicilio, NuevaPropiedad.Precio, NuevaPropiedad.Estado, NuevaPropiedad.ValorDelInmueble, @"..\..\..\destino.csv");

                id++;
            }
        }
    }
}
