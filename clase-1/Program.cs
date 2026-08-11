// CONTROLADOR

// Vamos a crear un objeto de clase "Jugador"
// necesitamos una referencia para invocar al objeto

Jugador player = new Jugador();

// Ahora podemos invocar sus métodos(comportamientos)
player.Mostrar();
player.Atacar(10);
player.Mostrar();
player.RecibirAtaque(80);
player.Mostrar();


// MODELO

// Declaramos y definimos la clase "Jugador"
class Jugador 
{
    // Declaramos una "variable de clase" para cada atributo
    // Si queremos podemos indicar su valor inicial (inicializamos)
    private int vida = 100;
    private int energia = 100;

    // Declaramos y definimos una "función de clase" para cada
    // Método (comportamiento) la semana próxima aclaramos

    public void Atacar(int fuerza)
    {
        energia -= fuerza; // energia = energia - fuerza
    }

    public void RecibirAtaque(int fuerza)
    {
        vida -= fuerza; 
    }


    public void Mostrar()
    {
        Console.WriteLine($"Vida:{vida} Energia:{energia}");
    }


}