class Program
{
    /*static public int Main(string[] args)
    {
        for (int i = 0; i < args.GetLength(0); i++)
            Console.WriteLine(args[i]);
            return 48;
    }*/
    static public void Main()
    {    
        //Carta carta1 = new Carta(1, "Espadas");
        //Console.WriteLine(carta1.Descripcion());
        Mazo mazo = new Mazo();
        mazo.Generar();
        
        //Console.WriteLine(mazo.CantidadCartas());
        //mazo.Mostrar();

        //Carta miCarta = mazo.QuitarCartaAlAzar();
        
        //Console.WriteLine($"me tocó la carta: {miCarta.Descripcion()}");

        //mazo.Mostrar();

        /*
        Jugador jugador = new Jugador();
        while(!jugador.ManoCompleta())
            jugador.RecibirCarta(mazo.QuitarCartaAlAzar());

        jugador.Mostrar();
        */
        
        Carta carta1 = new Carta(1, "Espadas");
        Carta carta2 = new Carta(1, "Espadas");

        if (carta1 == carta2)
            Console.WriteLine("Son igualitas");
        else
            Console.WriteLine("Pero claro que no, ya sabemos que se estáncomparando referencias!!!");
        
    }
}

class Carta
{
    private int valor;
    private string palo;
    
    public Carta(int valor, string palo)
    {
        this.valor = valor;
        this.palo = palo;
    }

    public int getValor()   { return valor; }
    public string getPalo() { return palo; }

    public string Descripcion() { return $"{valor} de {palo}"; }


}

class Mazo
{
    // Declaramos la lista
    private List<Carta> cartas;

    public Mazo()
    {
        // Creamos (construimos) la lista
        cartas = new List<Carta>();
    }
    public void Generar()
    {
        cartas.Clear();
        
        /* Trucho, pero aprobado
        Generar12Cartas("Bastos");
        Generar12Cartas("Copas");
        Generar12Cartas("Espadas");
        Generar12Cartas("Oros");
        */

        string[] palos = {"Bastos", "Copas", "Espadas", "Oros"};
        for (int i = 0; i < palos.GetLength(0); i++)
            Generar12Cartas(palos[i]);
    }

    public void Generar12Cartas(string palo)
    {
        for (int i = 0; i < 1; i++)
            cartas.Add(new Carta(i+1, palo));
    }

    public int CantidadCartas() { return cartas.Count(); }
    
    public void Mostrar()
    {
        for (int i = 0; i < cartas.Count(); i++)
            Console.WriteLine(cartas[i].Descripcion());
    }

    public Carta QuitarCartaAlAzar()
    {
        Random rng = new Random();
        int ubicacion = rng.Next(cartas.Count());
        Carta carta = cartas[ubicacion];
        cartas.RemoveAt(ubicacion);
        return carta;
    }
}

class Jugador
{
    private List<Carta> mano;

    public Jugador()
    {
        mano = new List<Carta>();
    } 
    public bool RecibirCarta(Carta unaCarta)
    {
        if (!ManoCompleta())
        {
            mano.Add(unaCarta);
            return true;
        }
        return false;
    }
    public bool ManoCompleta() { return mano.Count() == 3; }

    public void Mostrar()
    {
        // Versión básica
        //for (int i = 0; i < mano.Count(); i++)
        //    Console.WriteLine(mano[i].Descripcion());

        // Versión con iteradores
        foreach (Carta estaCarta in mano)
            Console.WriteLine(estaCarta.Descripcion());

    }
}
