using System;

public class Turno
{
    private static int contadorId = 1;
    public int Id { get; }
    public DateTime FechaHora { get; set; }
    public required Paciente Paciente { get; set; }
    public required Medico Medico { get; set; }
    public string Estado { get; set; } = "Programado";

    public Turno()
    {
        Id = contadorId++;
    }
}


