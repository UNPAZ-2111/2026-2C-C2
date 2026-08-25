// MODELO
//Portal portal = new Portal();
//portal.Mostrar();

//Console.ReadKey(); // Esperamos que se toque una tecla

Portal portal1 = new Portal(12, 12, ConsoleColor.Red);
Portal portal2 = new Portal(21, 21, ConsoleColor.Blue);
Jugador jugador = new Jugador(10, 10, 'J');

portal1.setDestinoX(50);
portal1.setDestinoY(50);

portal2.setDestinoX(33);
portal2.setDestinoY(33);

jugador.MoverA(11, 11);

Console.Clear(); // Borramos la pantalla
Console.CursorVisible = false;

Console.SetCursorPosition(portal1.getX(), portal1.getY());
// La clase que viene vemos propiedades :(
Console.BackgroundColor = portal1.getColor();
Console.Write(portal1.getSkin());

Console.SetCursorPosition(portal2.getX(), portal2.getY());
Console.BackgroundColor = portal2.getColor();
Console.Write(portal2.getSkin());

Console.ResetColor();

Console.SetCursorPosition(jugador.getX(), jugador.getY());
Console.Write(jugador.getSkin());

//portal.setDestinoX(80);
//portal.Mostrar();

Console.ReadKey(); // Esperamos que se toque una tecla
portal1.Deshacer();


jugador.MoverA(12, 12);
Console.SetCursorPosition(jugador.getX(), jugador.getY());
Console.Write(jugador.getSkin());

portal1.Teleportar(jugador);

Console.SetCursorPosition(jugador.getX(), jugador.getY());
Console.Write(jugador.getSkin());

Console.ReadKey();

// De vuelta a casa
portal1.Deshacer();

Console.SetCursorPosition(jugador.getX(), jugador.getY());
Console.Write(jugador.getSkin());

Console.ReadKey();


portal2.Teleportar(jugador);

Console.SetCursorPosition(jugador.getX(), jugador.getY());
Console.Write(jugador.getSkin());

Console.ReadKey();

class Portal 
{
    private int x;
    private int y;
    private ConsoleColor color;
    private int destinoX = 20;
    private int destinoY = 20;
    private char skin = '#';
    
    // Atributos necesarios para "Desahacer"
    private int ultimaX;
    private int ultimaY;
    private Jugador ultimoJugador;    
    
    public Portal()
    {
        //Console.WriteLine("Se acaba de crear un objeto de clase Portal :)");
        x = 10; 
        y = 10;
        color = ConsoleColor.DarkBlue;
    }
    public Portal(int x, int y, ConsoleColor color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }
    
    // Métodos "getter"
    // formación de nombres prefijo "get" y luego el id del atributo
    public int getX() { return x; }
    public int getY() { return y; }
    public char getSkin() { return skin; }
    public ConsoleColor getColor() { return color; }
    
    // Métodos "setter"
    public void setDestinoX(int x) { destinoX = x; }
    public void setDestinoY(int y) { destinoY = y; }
    
    public void Teleportar(Jugador unJugador)
    {
        if (x == unJugador.getX() & y == unJugador.getY())
        {
            ultimaX = unJugador.getX();
            ultimaY = unJugador.getY();
            ultimoJugador = unJugador;
            unJugador.MoverA(destinoX, destinoY);
        }
    }
    public void Deshacer()
    {
        if (ultimoJugador != null)
            ultimoJugador.MoverA(ultimaX, ultimaY);
    }
    public void Mostrar()
    {
        Console.WriteLine($"({x},{y}) -> ({destinoX},{destinoY})");
    }
}


class Jugador
{
    private int x;
    private int y;
    private char skin;
    
    
    public int getX() { return x; }
    public int getY() { return y; }
    public char getSkin() { return skin; }
   
    public Jugador (int x, int y, char skin )
    {        
        this.x = x;
        this.y = y;
        this.skin = skin;
    }

    public void MoverA(int x, int y)
    {
        this.x = x;
        this.y = y;
    }   
}