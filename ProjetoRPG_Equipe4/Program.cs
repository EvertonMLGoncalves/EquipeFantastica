using System;
using ProjetoRPG_Equipe4.Personagens;
using System.Threading;
using System.ComponentModel.Design;
using System.Media;
using ProjetoRPG_Equipe4.Artefatos;
using System.Collections.Concurrent;
using ProjetoRPG_Equipe4.Combate;
using ProjetoRPG_Equipe4.Enums;

public class Jogo
{
    public static void Main(string[] args)
    {
        Guerreiro guerreiro = new Guerreiro();
        Arqueiro arqueiro = new Arqueiro();
        Mago mago = new Mago();
        Arma arma1 = new Arma(1, "Espada Fantástica",80,1,3,"Cortar com muita ferozidade");
        Inimigo inimigo1 = new Inimigo("Guarda do Castelo", "Homem", 3, 5, 5, 10, EnumTipoInimigo.GuardaDoCastelo, EnumHabilidadeInimigo.Atordoar);
        Habilidades habilidade1 = new Habilidades("Super Veneno",ProjetoRPG_Equipe4.Enums.TipoHabilidade.Envenenante,2,30);
        Menu(guerreiro, arqueiro, mago,arma1, inimigo1, habilidade1);
        Console.ReadKey();
       

    }

    public static  void Menu(Guerreiro guerreiro, Arqueiro arqueiro, Mago mago,Arma arma1,Inimigo inimigo1, Habilidades habilidade1)
    {
        Personagem jogador = ComecoJogo(guerreiro, arqueiro, mago);
        Console.WriteLine("\tcarregando...");
        Console.Clear();
        Thread.Sleep(700);
        primeiroTurno(jogador,arma1, inimigo1,habilidade1);
        Console.Beep();
       
    }

    public static Personagem ComecoJogo(Guerreiro guerreiro, Arqueiro arqueiro, Mago mago)
    {
        string filePath = "Lalala.wav";
        SoundPlayer player = new SoundPlayer(filePath);
        player.Load();
        player.PlayLooping();
        Console.WriteLine("### INICIANDO JOGO ###");
        Console.WriteLine("\tcarregando...");
        Thread.Sleep(1200);
        Console.Clear();
        Console.WriteLine("d8888b.  d8888b.  d888b       d88888b  .d8b.  d8b   db d888888b  .d8b.  .d8888. d888888b d888888b  .o88b.  .d88b.  ");
        Console.WriteLine("88  `8D 88  `8D 88' Y8b      88'     d8' `8b 888o  88 `~~88~~' d8' `8b 88'  YP `~~88~~'   `88'   d8P  Y8 .8P  Y8. ");
        Console.WriteLine("88oobY' 88oodD' 88           88ooo   88ooo88 88V8o 88    88    88ooo88 `8bo.      88       88    8P      88    88 ");
        Console.WriteLine("88`8b   88~~~   88  ooo      88~~~   88~~~88 88 V8o88    88    88~~~88   `Y8b.    88       88    8b      88    88 ");
        Console.WriteLine("88 `88. 88      88. ~8~      88      88   88 88  V888    88    88   88 db   8D    88      .88.   Y8b  d8 `8b  d8' ");
        Console.WriteLine("88   YD 88       Y888P       YP      YP   YP VP   V8P    YP    YP   YP `8888Y'    YP    Y888888P  `Y88P'  `Y88P'  ");
        Thread.Sleep(3500);
        Console.Clear();
        Console.WriteLine("\tO ano era 2003... O rei malvado tinha acabado de prender a Princesa Aurora...");
        Console.WriteLine("\tMas... 20 anos depois você decide salva-la!");
        Thread.Sleep(3500);
        Console.Clear();
        Console.WriteLine("########### CRIANDO SEU PERSONAGEM ############");
        Console.WriteLine("# Escolha: (insira os números para escolher!) #");
        Console.WriteLine("# 1 - Guerreiro\t\t\t\t      #");
        Console.WriteLine("# 2 - Arqueiro\t\t\t\t      #");
        Console.WriteLine("# 3 - Mago\t\t\t\t      #");
        Console.WriteLine("###############################################");
        int escolha = int.Parse(Console.ReadLine());
        Console.Clear();
        Personagem jogador;

        switch (escolha)
        {
            case 1:jogador = guerreiro.CriarPersonagem(); break;
            case 2: jogador = arqueiro.CriarPersonagem(); break;
            case 3: jogador = mago.CriarPersonagem(); break;
            default: Console.WriteLine("Tente novamente! Escolha errada!"); player.Stop(); return null;

        }
        Thread.Sleep(1200);
        bool flag = true;
        while (flag)
        {
            jogador.ExibirInfo();
            Console.WriteLine("* Digite 'A' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'A') flag = false;
        }
        Thread.Sleep(500);
        player.Stop(); 
        return jogador;
    }

   public static void primeiroTurno(Personagem jogador, Arma arma, Inimigo inimigo, Habilidades habilidade)
    {
        
        SoundPlayer MusicaTensa = new SoundPlayer("Blablabla.wav");
        SoundPlayer Yoshi = new SoundPlayer("Yoshi.wav");
        MusicaTensa.Load();
        MusicaTensa.PlayLooping();
        Console.WriteLine("\tAh não, a frente do castelo você ja avista o Guarda do Castelo!");
        Console.WriteLine($"\tQue bom que sua irmã Lelezinha lhe enviou um(a) {arma.Nome}...");
        Thread.Sleep(1555);
        Console.WriteLine();
        Arma.AdicionarArma(jogador, arma);
        Thread.Sleep(1555);
        Console.Clear();
        bool flag = true;
        while (flag)
        {
            arma.ExibirInfo();
            Console.WriteLine("* Digite 'A' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'A') flag = false;
        }
        Console.Clear();
        Console.WriteLine($"Eita! o/a {inimigo.Nome} está chegando mais perto, a batalha irá começar!");
        Thread.Sleep(2400);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("Ufa! A batalha acabou! Foi por pouco...");
        MusicaTensa.Stop();
        Console.Clear();
        Yoshi.Load();
        Yoshi.PlayLooping();
        Console.WriteLine($"\tOpa! O que é isso aqui? eu acho que é uma {habilidade.Nome}!");
        Habilidades.AdicionarHabilidade(jogador, habilidade);
        Thread.Sleep(3000);
        flag = true;
        while (flag)
        {
            habilidade.ExibirInfo();
            Console.WriteLine("* Digite 'A' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'A') flag = false;
        }
        Yoshi.Stop();
    }

}
