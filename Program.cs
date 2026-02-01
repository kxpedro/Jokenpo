using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

internal class Program
{
    
    public enum Gestos : int
    {
        Pedra = 1,
        Papel = 2,
        Tesoura = 3
    }

    public enum Resultado : int
    {
        Vitoria = 1,
        Derrota = 2,
        Empate = 3
    }

    public static int NumeroDePartidas { get; set; }
    public static int ScoreJogador { get; set; }
    public static int ScoreAdversario { get; set; }

    private static void Main(string[] args)
    {
        var jogando = true;
        do
        {
            Console.WriteLine("Deseja jogar? (Y/N)");
            var jogarNovamente = Console.ReadLine();

            if (!string.IsNullOrEmpty(jogarNovamente) && jogarNovamente.ToUpper().Equals("Y"))
                Jogar();
            else
                jogando = false;

        } while (jogando);

    }

    public static void Jogar()
    {
        Console.WriteLine("=-==---=-=-==-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=");

        var jogadorValue = EscolhaDoJogador();

        var adversarioValue = new Random().Next(-1, 2);
        var resultado = Batalha(adversarioValue, jogadorValue);

        if (resultado == Resultado.Vitoria)
        {
            ScoreJogador++;
            Console.WriteLine("Vitória");
        }
        else if (resultado == Resultado.Derrota)
        {
            ScoreAdversario++;
            Console.WriteLine("Derrota");
        }
        else if (resultado == Resultado.Empate)
        {
            ScoreJogador++;
            ScoreAdversario++;
            Console.WriteLine("Empate");
        }
        
        NumeroDePartidas++;

        Console.WriteLine("=-==---=-=-==-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=");
        Console.WriteLine("Score");
        Console.WriteLine("Jogador: " + ScoreJogador);
        Console.WriteLine("Adversário: " + ScoreAdversario);
        Console.WriteLine(string.Empty);
        Console.WriteLine("Partidas: " + NumeroDePartidas);
        Console.WriteLine("=-==---=-=-==-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-==-=-=-=");

    }

    public static Gestos EscolhaDoJogador()
    {
        Console.WriteLine("Escolha entre Pedra, papel e tesoura.");
        Console.WriteLine("Pedra = 1");
        Console.WriteLine("Papel = 2");
        Console.WriteLine("Tesoura = 3");
        var jogadorInput = Console.ReadLine();
        var jogadorValue = 0;

        if (string.IsNullOrEmpty(jogadorInput) || !int.TryParse(jogadorInput, out jogadorValue))
        {
            Console.WriteLine("Selecione uma opção válida.");
            EscolhaDoJogador();
        }

        Console.WriteLine("Escolhido: " + (Gestos)jogadorValue);
        return (Gestos)jogadorValue;
    }

    public static Resultado Batalha(float adversarioValue, Gestos jogadorValue)
    {
        var resultado = 0;

        if (adversarioValue > 0) { Console.WriteLine("Adversário: Papel"); }
        else if (adversarioValue < 0) { Console.WriteLine("Adversário: Pedra"); }
        else if (adversarioValue == 0) { Console.WriteLine("Adversário: Tesoura"); }
        
        // Pedra
        if (adversarioValue < 0 && jogadorValue == Gestos.Papel)
            resultado = (int)Resultado.Vitoria;
        else if (adversarioValue < 0 && jogadorValue == Gestos.Tesoura)
            resultado = (int)Resultado.Derrota;
        else if (adversarioValue < 0 && jogadorValue == Gestos.Pedra)
            resultado = (int)Resultado.Empate;

        // Papel
        if (adversarioValue > 0 && jogadorValue == Gestos.Papel)
            resultado = (int)Resultado.Empate;
        else if (adversarioValue > 0 && jogadorValue == Gestos.Tesoura)
            resultado = (int)Resultado.Vitoria;
        else if (adversarioValue > 0 && jogadorValue == Gestos.Pedra)
            resultado = (int)Resultado.Derrota;

        // Tesoura        
        if (adversarioValue == 0 && jogadorValue == Gestos.Papel)
            resultado = (int)Resultado.Derrota;
        else if (adversarioValue == 0 && jogadorValue == Gestos.Tesoura)
            resultado = (int)Resultado.Empate;
        else if (adversarioValue == 0 && jogadorValue == Gestos.Pedra)
            resultado = (int)Resultado.Vitoria;

        return (Resultado)resultado;
    }
        
}