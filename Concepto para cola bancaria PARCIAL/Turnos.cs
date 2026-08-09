using System.Collections.Generic;
using System.Linq;

public class Turno
{
    private Queue<Cliente> cola = new();
    private int turnoproximo = 1;

    public Cliente AgregarCliente(string nombre)
    {
        Cliente cliente = new(turnoproximo, nombre);

        cola.Enqueue(cliente);

        turnoproximo ++;

        return cliente;
    }

    public Cliente AtenderProximo()
    {
        if (cola.Count == 0)
        {
            return null;
        }

        return cola.Dequeue();
    }

    public Cliente ObtenerProximo()
    {
        if (cola.Count == 0)
        {
            return null;
        }

        return cola.Peek();
    }

    public int CantidadEnEspera()
    {
        return cola.Count;
    }
}