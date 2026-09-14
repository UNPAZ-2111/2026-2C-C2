class Program
{
    static void Main(string[] args)
    {
        
        Random rng = new Random();

        Luchador player1; // = new Ryu(100);
        //Luchador player2; // = new Guile(100);
       
        if (rng.Next(10) < 5)
            player1 = new Ryu(100);
        else
            player1 = new Guile(100);

        
        //if (player1 is Ryu)
        //    Console.WriteLine($"{player1.getPuntosAcumulados()}");
        //else
        //    Console.WriteLine($"{player1.getAtaqueEspecialActivo()}");
        
        Ryu? unRyu = player1 as Ryu;
        if (unRyu != null)
            Console.WriteLine($"{unRyu.getPuntosAcumulados()}");

        Guile? unGuile = player1 as Guile;
        if (unGuile != null)
            Console.WriteLine($"{unGuile.getAtaqueEspecialActivo()}");

        /*
        Console.WriteLine(player1);

        bool gameOver = false;

        while (!gameOver)
        {
            player1.Atacar(player2);
            player2.Atacar(player1);
            player1.Mostrar();
            player2.Mostrar();
            Console.ReadKey();
            gameOver = !player1.estaVivo() | !player2.estaVivo();
        }
        */
    }

}

class Luchador
{
    protected string? nombre;
    protected int vida;
    protected int puntosAtaque;
    protected int puntosDefensa;

    public Luchador(int puntosTotales)
    {
        Random rng = new Random();
        puntosAtaque = rng.Next(0, puntosTotales + 1);
        puntosDefensa = puntosTotales - puntosAtaque;
        vida = 100;
    }

    public bool estaVivo() { return vida > 0; }
    virtual public void Atacar(Luchador rival) { }
    virtual public void RecibirAtaque(int puntos) { }

    virtual public void Mostrar()
    {
        Console.WriteLine($"{nombre} ({puntosAtaque}/{puntosDefensa}) Vida:{vida}");
    }
}

class Ryu : Luchador
{
    private int puntosAcumulados;

    public Ryu(int puntosTotales) : base (puntosTotales)
    {
        nombre = "Ryu Hoji";
    }

    public int getPuntosAcumulados() { return puntosAcumulados; }
    
    override public void Atacar(Luchador rival)
    {
        if (puntosAcumulados >= 50)
            AtacarEspecial(rival);
        else
            AtacarNormal(rival);
    } 
    private void AtacarNormal(Luchador rival)
    {
        rival.RecibirAtaque(puntosAtaque);
    }
    private void AtacarEspecial(Luchador rival)
    {
        rival.RecibirAtaque(puntosAtaque * 5);
        puntosAcumulados = 0;
    }
    override public void RecibirAtaque(int puntos)
    {
        int puntosEfectivos = puntos - puntosDefensa;
        //Console.WriteLine($"{nombre} recibe ataque efectivo {puntosEfectivos}");
        if (puntosEfectivos >= 0)
            vida -= puntosEfectivos;
        else
            puntosAcumulados += (puntosEfectivos * -1);
    }
    override public string? ToString()
    //public override void Mostrar()
    {
      return $"{nombre} [{puntosAtaque}-{puntosDefensa}-{puntosAcumulados}] Vida:{vida}";       
    }
}

class Guile : Luchador
{
    private bool ataqueEspecialActivo;
    private Random rng;

    public Guile(int puntosTotales) : base (puntosTotales)
    {
        nombre = "William Guile";
        rng = new Random();
    }
    public bool getAtaqueEspecialActivo() { return ataqueEspecialActivo; }
    override public void Atacar(Luchador rival)
    {
        if (ataqueEspecialActivo)
            AtacarEspecial(rival);
        else
            AtacarNormal(rival);
    } 
    private void AtacarNormal(Luchador rival)
    {
        if (rng.Next(10) < 5)
            ataqueEspecialActivo = true;
        else
            rival.RecibirAtaque(puntosAtaque);
    }
    private void AtacarEspecial(Luchador rival)
    {
        rival.RecibirAtaque(puntosAtaque * 5);
        ataqueEspecialActivo = false;
    }
    override public void RecibirAtaque(int puntos)
    {
        int puntosEfectivos = puntos - puntosDefensa;
        Console.WriteLine($"{nombre} recibe ataque efectivo {puntosEfectivos}");
     
        if (puntosEfectivos >= 0)
            vida -= puntosEfectivos;
    }
    public override void Mostrar()
    {
      Console.WriteLine($"{nombre} [{puntosAtaque}-{puntosDefensa}-{ataqueEspecialActivo}] Vida:{vida}");       
    }
}

