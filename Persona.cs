public abstract class Persona
{
    public int Id { get; protected set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public InformacionContacto Contacto { get; set; }
}
