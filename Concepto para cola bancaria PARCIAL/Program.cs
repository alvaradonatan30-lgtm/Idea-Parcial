using System;

class Program
{
    static void Main()
    {
        Turno turno = new();

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("\nControl de Cola Bancaria");
            Console.WriteLine("1. Llegada de nuevo Cliente");
            Console.WriteLine("2. Atender al siguiente");
            Console.WriteLine("3. Ver clientes en cola (Estado)");
            Console.WriteLine("4. Salir del programa");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                AgregarCliente(turno);
                break;

                case "2":
                AtenderSiguiente(turno);
                break;

                case "3":
                EstadoCola(turno);
                break;

                case "4":
                salir = true;
                Console.WriteLine("Fin del programa");
                break;

                default:
                Console.WriteLine("Opcion no válida");
                break;
            }
        }
    }

    static void AgregarCliente(Turno turno)
    {
        Console.Write("Ingrese el nombre del cliente: ");
        string nombreCliente = Console.ReadLine()!;

        Cliente cliente = turno.AgregarCliente(nombreCliente);

        Console.WriteLine($"Bienvenido {cliente.Nombre}, su turno es el {cliente.NumeroTurno}");
    }

    static void AtenderSiguiente(Turno turno)
    {
        Cliente cliente = turno.AtenderProximo();

        if (cliente == null)
        {
            Console.WriteLine("No hay clientes en espera.");
            return;
        }

        Console.WriteLine($"Atendiendo al turno {cliente.NumeroTurno} - {cliente.Nombre}");
    }

    static void EstadoCola(Turno turno)
    {
        int cantidad = turno.CantidadEnEspera();

        Console.WriteLine($"Clientes en espera: {cantidad}");

        Cliente siguiente = turno.ObtenerProximo();

        if (siguiente == null)
        {
            Console.WriteLine("No hay clientes en espera pendientes.");
        }
        else
        {
        Console.WriteLine($"Siguiente turno: {siguiente.NumeroTurno} - {siguiente.Nombre}");
        }
    }
}