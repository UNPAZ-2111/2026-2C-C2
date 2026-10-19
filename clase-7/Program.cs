// Repaso arreglos n-dimensionales (1D "vectores", 2D "matrices")

// Para declarar un arreglo utilizamos []
//int[] tirada;

// Para construir el arreglo utilizamos "new"
//tirada = new int[40];

// también podemos hacer todo de una
//int[] tirada = new int[5];
/*
tirada[0] = 1;
tirada[1] = 3;
tirada[2] = 1;
tirada[3] = 2;
tirada[4] = 4;
*/
//Random rng = new Random();

//Console.WriteLine($"La longitud del arreglo tirada es: {tirada.GetLength(0)}");

// para "poblar" un arreglo usamos un ciclo de repetición fijo y una asignaciṕn
//for (int i = 0; i < tirada.GetLength(0); i++)
//    tirada[i] = rng.Next(1, 7);


// recorremos y mostramos cada elemento
//for (int i = 0; i < tirada.GetLength(0); i++)
//    Console.Write($"{tirada[i]} ");

// Ejemplito de matriz (2D)
/*
char[,] letras;
letras = new char[20, 40];

for(int f = 0; f < letras.GetLength(0); f++)
    for (int c = 0; c < letras.GetLength(1); c++)
        letras[f, c] = (char)(rng.Next(65, 91));

for(int f = 0; f < letras.GetLength(0); f++)
    {
    for (int c = 0; c < letras.GetLength(1); c++)
        Console.Write($"{letras[f,c]} ");
    Console.WriteLine();
    }
*/

class Program
{
    static void Main(string[] args)
    {
        Personaje perso = new Personaje(5);
        //perso.AgarrarItem(new Pistola()); // Ubicacion: 0
        //perso.AgarrarItem(new Agua());    // Ubicacion: 1
        //perso.AgarrarItem(new Agua());    // Ubicacion: 2
        //perso.AgarrarItem(new Botella()); // Ubicacion: 3 (sin éxito)
        //perso.DejarItem(1);
        //perso.AgarrarItem(new Botella()); // Ubicacion: 3 (sin éxito)
        Random rng = new Random();
        for (int i = 0; i < 3; i++)
        {
            switch(rng.Next(3))
            {
                case 0:
                    Console.WriteLine("Salió Pistola");
                    perso.AgarrarItem(new Pistola());
                    break;
                case 1:
                    Console.WriteLine("Salió Botella");
                    perso.AgarrarItem(new Botella());
                    break;
                case 2:
                    Console.WriteLine("Salió Agua");
                    perso.AgarrarItem(new Agua());
                    break;     
            }
        }
        
        perso.Mostrar();
        if (perso.estaArmado())
            Console.WriteLine("Cuidado está armado");
        /*
        perso.DejarItem(0);
        if (perso.estaArmado())
            Console.WriteLine("Cuidado está armado");
        else   
            Console.WriteLine("atacá tranca");
        */
    }
}
class Personaje
{
    private Item?[] inventario;

    private int pesoMaximo;

    public Personaje(int pesoMaximo)
    {
        inventario = new Item[3];
        this.pesoMaximo = pesoMaximo;
    }

    public bool AgarrarItem(Item unItem)
    {
        if (PesoTotal() + unItem.getPeso() > pesoMaximo)
            return false;

        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] == null)
            {
                inventario[i] = unItem;
                return true;
            }
        return false;
    }
    public bool DejarItem(int ubicacion)
    {
        if ((ubicacion < 0) | (ubicacion >= inventario.GetLength(0)))
            return false;
        
        inventario[ubicacion] = null;
        return true;

    }

    public bool estaArmado()
    {
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] is Pistola)
                return true;
        return false;
    }
    
    private int PesoTotal()
    {
        int pesoTotal = 0;
        for (int i = 0; i < inventario.GetLength(0); i++)
            if (inventario[i] != null)
                pesoTotal += inventario[i].getPeso();
        return pesoTotal;
    }
    
    public void Mostrar()
    {
        Console.WriteLine("Inventario:");
        for (int i = 0; i < inventario.GetLength(0); i++)
        {
            Console.Write($"[{i}] ");
            if (inventario[i] != null)
                Console.WriteLine($"{inventario[i].getDescripcion()} [{inventario[i].getPeso()}]");
            else
                Console.WriteLine();    
        }
        Console.WriteLine($"Peso total: {PesoTotal()}");        
    }
}

class Item
{
    private string descripcion;
    private int peso;

    public Item(string descripcion, int peso) 
    { 
        this.descripcion = descripcion; 
        this.peso = peso;
    }

    public string getDescripcion() { return descripcion; }
    public int getPeso() { return peso; }
}

class Pistola : Item
{
    public Pistola() : base("Super Pistola", 4) {}
}

class Botella : Item
{
    public Botella() : base("Super Botella", 2) {}
}

class Agua : Item
{
    public Agua() : base("H2O", 1) {} 
}

