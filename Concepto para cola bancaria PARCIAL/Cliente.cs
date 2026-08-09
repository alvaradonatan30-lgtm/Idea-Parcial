public class Cliente
{
    public int NumeroTurno { get; set; }
    public string Nombre { get; set; }

    public Cliente(int numeroturno, string nombre)
    {
        NumeroTurno = numeroturno;
        Nombre = nombre;
    }
}
