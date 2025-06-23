using System;
using System.Collections.Generic;
using System.Linq;

public class GestorTurnos
{
    private List<Paciente> pacientes = new List<Paciente>();
    private List<Medico> medicos = new List<Medico>();
    private List<Turno> turnos = new List<Turno>();
    private bool[,] matrizDisponibilidad = new bool[7, 24];

    public void AgregarPaciente(Paciente paciente) => pacientes.Add(paciente);
    public void AgregarMedico(Medico medico) => medicos.Add(medico);

    public Turno? AgendarTurno(DateTime fechaHora, int idPaciente, int idMedico)
    {
        var paciente = pacientes.FirstOrDefault(p => p.Id == idPaciente);
        var medico = medicos.FirstOrDefault(m => m.Id == idMedico);

        if (paciente == null || medico == null) return null;

        var turno = new Turno
        {
            FechaHora = fechaHora,
            Paciente = paciente,
            Medico = medico
        };

        turnos.Add(turno);
        return turno;
    }

    public bool CancelarTurno(int idTurno)
    {
        var turno = turnos.FirstOrDefault(t => t.Id == idTurno);
        if (turno == null) return false;

        turno.Estado = "Cancelado";
        return true;
    }

    public List<Turno> ObtenerTurnosPorFecha(DateTime fecha) =>
        turnos.Where(t => t.FechaHora.Date == fecha.Date).ToList();

    public List<Turno> ObtenerTurnosPorPaciente(int idPaciente) =>
        turnos.Where(t => t.Paciente.Id == idPaciente).ToList();

    public void ImprimirTodosTurnos()
    {
        Console.WriteLine("\nLISTADO COMPLETO DE TURNOS");
        Console.WriteLine("=".PadRight(60, '='));
        foreach (var turno in turnos)
        {
            Console.WriteLine($"ID: {turno.Id} | Fecha: {turno.FechaHora:g}");
            Console.WriteLine($"Paciente: {turno.Paciente.Nombre} {turno.Paciente.Apellido}");
            Console.WriteLine($"Médico: {turno.Medico.Nombre} ({turno.Medico.Especialidad})");
            Console.WriteLine($"Estado: {turno.Estado}\n");
        }
    }
}
