using System;
using System.Linq;

class Hueso : IComparable<Hueso>
{
    public string Nombre { get; set; }
    public double Peso { get; set; }
    public double Densidad { get; set; }
    public double Longitud { get; set; }
    public double Diametro { get; set; }

    public Hueso(string nombre, double peso, double densidad, double longitud, double diametro)
    {
        Nombre = nombre;
        Peso = peso;
        Densidad = densidad;
        Longitud = longitud;
        Diametro = diametro;
    }

    public override string ToString()
    {
        return $"{Nombre} - Peso: {Peso}, Densidad: {Densidad}, Longitud: {Longitud}, Diámetro: {Diametro}";
    }

    public int CompareTo(Hueso other)
    {
        return string.Compare(Nombre, other.Nombre, StringComparison.Ordinal);
    }
}

class Esqueleto
{
    private Hueso[] huesos = new Hueso[206];
    private int count = 0; // Contador para llevar el seguimiento de la cantidad actual de huesos

    public void CargarInformacion(Hueso[] arrayHuesos)
    {
        if (arrayHuesos.Length > huesos.Length)
        {
            Console.WriteLine("Error: La longitud del array de huesos excede la capacidad del esqueleto.");
            return;
        }

        Array.Copy(arrayHuesos, huesos, arrayHuesos.Length);
        count = arrayHuesos.Length;
    }

    public void Ordenar(string criterio)
    {
        switch (criterio.ToLower())
        {
            case "nombre":
                Array.Sort(huesos, 0, count);
                break;
            case "peso":
                Array.Sort(huesos, 0, count, Comparer<Hueso>.Create((h1, h2) => h1.Peso.CompareTo(h2.Peso)));
                break;
            case "densidad":
                Array.Sort(huesos, 0, count, Comparer<Hueso>.Create((h1, h2) => h1.Densidad.CompareTo(h2.Densidad)));
                break;
            case "longitud":
                Array.Sort(huesos, 0, count, Comparer<Hueso>.Create((h1, h2) => h1.Longitud.CompareTo(h2.Longitud)));
                break;
            case "diametro":
                Array.Sort(huesos, 0, count, Comparer<Hueso>.Create((h1, h2) => h1.Diametro.CompareTo(h2.Diametro)));
                break;
            default:
                Console.WriteLine("Criterio no válido. Ordenando por nombre por defecto.");
                Array.Sort(huesos, 0, count);
                break;
        }
    }

    public void Imprimir()
    {
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine(huesos[i]);
        }
    }
}

class Program
{
    static void Main()
    {
        Hueso[] arrayHuesos = new Hueso[]
        {
            new Hueso("Fémur", 2.5, 1.8, 40.0, 3.0),
            new Hueso("Cráneo", 1.0, 2.0, 25.0, 2.0),
            new Hueso("Húmero", 1.8, 1.6, 30.0, 2.5),
        };

        Esqueleto miEsqueleto = new Esqueleto();
        miEsqueleto.CargarInformacion(arrayHuesos);

        Console.WriteLine("Esqueleto sin ordenar:");
        miEsqueleto.Imprimir();

        Console.WriteLine("\nEsqueleto ordenado por nombre:");
        miEsqueleto.Ordenar("nombre");
        miEsqueleto.Imprimir();

        Console.WriteLine("\nEsqueleto ordenado por peso:");
        miEsqueleto.Ordenar("peso");
        miEsqueleto.Imprimir();

        Console.WriteLine("\nEsqueleto ordenado por densidad:");
        miEsqueleto.Ordenar("densidad");
        miEsqueleto.Imprimir();

        Console.WriteLine("\nEsqueleto ordenado por longitud:");
        miEsqueleto.Ordenar("longitud");
        miEsqueleto.Imprimir();

        Console.WriteLine("\nEsqueleto ordenado por diámetro:");
        miEsqueleto.Ordenar("diametro");
        miEsqueleto.Imprimir();
    }
}
