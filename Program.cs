using System;

class Program
{
    static void Main(string[] args)
    {
        GestorTurnos gestor = new GestorTurnos();

        // Datos de prueba
        gestor.AgregarPaciente(new Paciente
        {
            Nombre = "Ana",
            Apellido = "Torres",
            HistoriaClinica = "HC123456",
            Contacto = new InformacionContacto { Telefono = "555-1234" }
        });

        gestor.AgregarMedico(new Medico
        {
            Nombre = "Carlos",
            Apellido = "Mendoza",
            Especialidad = "Cardiología"
        });

        // Agendar turno
        gestor.AgendarTurno(
            new DateTime(2023, 12, 15, 10, 0, 0),
            1,
            1
        );

        // Consultas
        Console.WriteLine("=== Turnos agendados ===");
        gestor.ImprimirTodosTurnos();

        Console.WriteLine("\n=== Turnos por paciente ===");
        var turnosPaciente = gestor.ObtenerTurnosPorPaciente(1);
        foreach (var t in turnosPaciente)
        {
            Console.WriteLine($"{t.FechaHora:g} con Dr. {t.Medico.Apellido}");
        }
    }
}
