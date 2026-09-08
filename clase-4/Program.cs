class Program
{
    static void Main(string[] args)
    {
        Persona perso = new Persona(10);
        Protagonista prota = new Protagonista("Cacho", 100, 100, perso);

        prota.Mostrar();
        prota.Atacar();
        prota.UsarPersona();
        prota.Mostrar();

        Compa compa = new Compa("Mirta", 100, 100, perso);
        compa.UsarPersona();
        compa.SeguirOrden("Preparate unos mates");
        compa.Mostrar();

        prota.CambiarPersona(new Persona(50));
        prota.UsarPersona();
        prota.Mostrar();

        //UsuarioPersona fafa = new UsuarioPersona();

    }
}

abstract class UsuarioPersona
{
    protected string nombre;
    protected int vida;
    protected int espiritu;
    protected Persona miPersona;

    public UsuarioPersona(string nombre, int vida, int espiritu, Persona unaPersona)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.espiritu = espiritu;
        miPersona = unaPersona;
    }
    public void Atacar() { vida--; }
    
    public void UsarPersona()
    {
        miPersona.Atacar(this);
    }

    public void ConsumirEspiritu(int cantidad) { espiritu -= cantidad; }

    virtual public void Mostrar()
    {
        Console.WriteLine($"[UsuarioPersona] Nombre:{nombre} Vida:{vida} Espiritu:{espiritu}");
    }
}

class Protagonista : UsuarioPersona
{
    public Protagonista(string nombre, int vida, int espiritu, Persona unaPersona) : base(nombre, vida, espiritu, unaPersona)
    {}

    public void CambiarPersona(Persona unaPersona) { miPersona = unaPersona; }

    override public void Mostrar()
    {
        Console.WriteLine($"[Protagonista] Nombre:{nombre} Vida:{vida} Espiritu:{espiritu} Persona:{miPersona}");
    }
}

class Compa : UsuarioPersona
{
    public Compa(string nombre, int vida, int espiritu, Persona unaPersona) : base(nombre, vida, espiritu, unaPersona)
    {}
   
    public void SeguirOrden(string orden)
    {
        Console.WriteLine($"Acatando orden:{orden}"); 
    }
}

class Persona
{
    private int cuotaEspiritu;

    public Persona(int cuotaEspiritu)
    {
        this.cuotaEspiritu = cuotaEspiritu;
    }

    public void Atacar(UsuarioPersona usuario)
    {
        if (usuario is Protagonista)
            usuario.ConsumirEspiritu(cuotaEspiritu);
        else
            usuario.ConsumirEspiritu(cuotaEspiritu * 2);
       
    }
}