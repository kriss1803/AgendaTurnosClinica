public class Medico : Persona
{
    private static int contadorId = 1;
    public required string Especialidad { get; set; }

    public Medico()
    {
        Id = contadorId++;
    }
}
