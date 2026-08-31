class Program
{
    static void Main(string[] args)
    {
        Mago merlin = new Mago(100);
        //merlin.Mostrar();
        Mascota draco = new Mascota(2);
        
        draco.Mostrar();
        draco.RecibirAtaque(2);
        draco.Mostrar();
        
        merlin.AdoptarMascota(draco);
        merlin.InvocarMascota();
        
        merlin.Mostrar();

        merlin.RegenerarPiedra();
        merlin.Mostrar();

    }
}


class Mago
{
    private int mana;
    private Piedra piedra;
    private Mascota miMascota;

    public Mago(int mana) 
    {
        this.mana = mana;
        piedra = new Piedra(1);
        miMascota = null;
    }
    public void Descansar() 
    { 
        mana++; 
        if (miMascota != null)
            miMascota.Descansar();
    }
    public void InvocarMascota()
    {
        if (miMascota != null)
            piedra.SerUsada(miMascota);
    }
    public void RegenerarPiedra() 
    {
        piedra.SerRegenerada(this);
    }
    public int EntregarMana()
    {
        int manaEntregado = 0;
        mana--;
        if (mana >= 0)
            manaEntregado = 1;
        return manaEntregado;
    }
    public void AdoptarMascota(Mascota unaMascota)
    {
        miMascota = unaMascota;
    }
    public void DejarMascota()
    {
        miMascota = null;
    }
    public void Mostrar()
    {
        Console.WriteLine($"Mana:{mana}");
        piedra.Mostrar();
        if (miMascota != null)
            miMascota.Mostrar();
    }
}

class Piedra
{
    private int carga;
    private int cargaActual;

    public Piedra()
    {
        carga = 3;
        Recargar();
    }
    public Piedra(int carga)
    {
        this.carga = carga;
        Recargar();
    }
    private void Recargar()
    {
        cargaActual = carga;
    }
    public void SerRegenerada(Mago unMago)
    {
        if (unMago.EntregarMana() == 1)
            Recargar();
    }
    public void SerUsada(Mascota unaMascota)
    {
        unaMascota.SerRevivida();
        cargaActual--;
    }
    public void Mostrar()
    {
        Console.WriteLine($"Carga[{cargaActual}/{carga}]");
    }

}

class Mascota
{
    private int vida;
    private int vidaActual;

    public Mascota(int vida) 
    {
        this.vida = vida;
        vidaActual = vida;
    }
    public void SerInvocada()
    {
        vidaActual = vida;
    }
    public void RecibirVida() { vidaActual++; }
 
    public void RecibirAtaque(int fuerza) { vidaActual -= fuerza;}

    public bool estaViva() { return (vidaActual > 0);}

    public void Descansar() { RecibirVida(); }

    public void SerRevivida() { vidaActual = vida; }

    public void Mostrar()
    {
        Console.WriteLine($"Vida:[{vidaActual}/{vida}]");
    }
}