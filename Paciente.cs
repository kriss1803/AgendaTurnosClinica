public class Paciente : Persona
{
    private static int contadorId = 1;

    public required string HistoriaClinica { get; set; }

    public Paciente()
    {
        Id = contadorId++;
    }
}