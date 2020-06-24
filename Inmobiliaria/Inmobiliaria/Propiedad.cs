using System;
using System.Collections.Generic;
using System.Text;

namespace Inmobiliaria
{
    enum TipoDePropiedad
    {
        Departamento = 0,
        Casa = 1,
        Duplex = 2,
        Penthhouse = 3,
        Terreno = 4,
    }

    enum TipoDeOperacion
    {
        Alquiler = 0,
        Venta = 1,
    }

    public class Propiedad
    {
        int id;
        string prop;
        string operacion;
        float tamanio;
        int cantidadDeBaños;
        int cantidadDeHabitaciones;
        string domicilio;
        int precio;
        bool estado;
        float valorDelInmueble;

        public int Id { get => id; set => id = value; }
        public string Prop { get => prop; set => prop = value; }
        public string Operacion { get => operacion; set => operacion = value; }
        public float Tamanio { get => tamanio; set => tamanio = value; }
        public int CantidadDeBaños { get => cantidadDeBaños; set => cantidadDeBaños = value; }
        public int CantidadDeHabitaciones { get => cantidadDeHabitaciones; set => cantidadDeHabitaciones = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public int Precio { get => precio; set => precio = value; }
        public bool Estado { get => estado; set => estado = value; }
        public float ValorDelInmueble { get => valorDelInmueble; set => valorDelInmueble = value; }
    }
}
