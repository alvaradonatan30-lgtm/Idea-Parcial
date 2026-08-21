using System;

class Program
{
    // Capacidad máxima de la cola del banco
    static int capacidadMaxima = 250;

    static int[] numerosTurno = new int[capacidadMaxima];
    static string[] nombresClientes = new string[capacidadMaxima];

    // Punteros y contadores de la cola
    static int frente = 0;
    static int final = 0;
    static int cantidadEnCola = 0;
    static int contadorTurnoGlobal = 1;

    static void Main()
    {
        bool salir = false;

        // Se mantiene el menú original
        while (!salir)
        {
            Console.WriteLine("\n--- Control de Cola Bancaria (Estructurado) ---");
            Console.WriteLine("1. Llegada de nuevo Cliente");
            Console.WriteLine("2. Atender al siguiente");
            Console.WriteLine("3. Ver clientes en cola (Estado)");
            Console.WriteLine("4. Salir del programa");
            Console.Write("Seleccione una opcion: ");
            string opcion = Console.ReadLine()!;

            switch (opcion)
            {
                case "1":
                    AgregarCliente();
                    break;
                case "2":
                    AtenderSiguiente();
                    break;
                case "3":
                    EstadoCola();
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("Fin del programa");
                    PausaYLimpiar();
                    break;
                default:
                    Console.WriteLine("Opcion no válida");
                    PausaYLimpiar();
                    break;
            }
        }
    }

    static void PausaYLimpiar()
    {
        Console.WriteLine("Presione cualquier tecla para continuar...");
        Console.ReadKey();
        Console.Clear();
    }

    static void AgregarCliente()
    {
        // Validación para evitar desbordamiento del arreglo
        if (cantidadEnCola == capacidadMaxima)
        {
            Console.WriteLine("La cola está llena. No se pueden recibir más clientes.");
            PausaYLimpiar();
            return;
        }

        Console.Write("Ingrese el nombre del cliente: ");
        string nombreCliente = Console.ReadLine()!;

        for (int i = 0; i < nombreCliente.Length; i++)
        {
            if (!char.IsLetter(nombreCliente[i]) && !char.IsWhiteSpace(nombreCliente[i]))
            {
                Console.WriteLine("Nombre inválido. Solo se permiten letras y espacios.");
                PausaYLimpiar();
                return;
            }
        }

        // Guardamos los datos en los arreglos paralelos
        numerosTurno[final] = contadorTurnoGlobal;
        nombresClientes[final] = nombreCliente;

        Console.WriteLine($"Bienvenido {nombreCliente}, su turno es el {contadorTurnoGlobal}");

        // Actualizamos los índices usando aritmética modular para la cola circular
        final = (final + 1) % capacidadMaxima;
        cantidadEnCola++;
        contadorTurnoGlobal++;
        PausaYLimpiar();
    }

    static void AtenderSiguiente()
    {
        if (cantidadEnCola == 0)
        {
            Console.WriteLine("No hay clientes en espera.");
            PausaYLimpiar();
            return;
        }

        // Extraemos los datos del frente de los arreglos paralelos
        int turnoAtendido = numerosTurno[frente];
        string nombreAtendido = nombresClientes[frente];

        Console.WriteLine($"Atendiendo al turno {turnoAtendido} - {nombreAtendido}");

        // Movemos el puntero del frente y reducimos el contador
        frente = (frente + 1) % capacidadMaxima;
        cantidadEnCola--;
        PausaYLimpiar();
    }

    static void EstadoCola()
    {
        Console.WriteLine($"Clientes en espera: {cantidadEnCola}");

        if (cantidadEnCola == 0)
        {
            Console.WriteLine("No hay clientes en espera pendientes.");
            PausaYLimpiar();
        }
        else
        {
            // Mostramos quién está en la posición 'frente'
            Console.WriteLine($"Siguiente turno: {numerosTurno[frente]} - {nombresClientes[frente]}");
            PausaYLimpiar();
        }
    }
}