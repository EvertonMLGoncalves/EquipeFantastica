using ProjetoRPG_Equipe4.Artefatos;
using ProjetoRPG_Equipe4.Combate;
using ProjetoRPG_Equipe4.Enums;
using ProjetoRPG_Equipe4.Personagens;
using System;
//using System.Media;
using System.Threading;

public class Jogo
{
    public static void Main(string[] args)
    {
        Guerreiro guerreiro = new Guerreiro();
        Arqueiro arqueiro = new Arqueiro();
        Mago mago = new Mago();

        // Turno 1
        Arma arma1 = new Arma(1, "Espada Fantástica", 80, 1, 10, "Cortar com muita ferozidade");
        Inimigo inimigo1 = new Inimigo("Guarda do Castelo", "Homem", 3, 5, 5, 15, EnumTipoInimigo.GuardaDoCastelo, EnumHabilidadeInimigo.Atordoar);
        Habilidades habilidade1 = new Habilidades("Super Veneno", ProjetoRPG_Equipe4.Enums.TipoHabilidade.Envenenante, 2, 35);

        // Turno 2
        Arma arma2 = new Arma(2, "Flecha Perfeita", 60, 2, 5, "Acerta bem no coração");
        Inimigo inimigo2 = new Inimigo("Crocodilo do Fosso", "Macho", 5, 15, 15, 25, EnumTipoInimigo.CrocodiloDoFosso, EnumHabilidadeInimigo.GiroMortal);

        // Turno 3
        Habilidades habilidade3 = new Habilidades("Superdoado", TipoHabilidade.Atordoante, 1, 90);
        Inimigo inimigo3 = new Inimigo("Gragula da torre", "Femea", 7, 25, 20, 30, EnumTipoInimigo.GargulaDaTorre, EnumHabilidadeInimigo.Incendiar);

        // Turno 4
        Inimigo inimigo4 = new Inimigo("Esqueleto Malígno", "Homem", 9, 35, 30, 40, EnumTipoInimigo.EsqueletoMaligno, EnumHabilidadeInimigo.Regeneracao);
        Arma arma4 = new Arma(3, "Bola de fogo suprema", 50, 3, 3, "Bolada na cara!");

        Menu(guerreiro, arqueiro, mago, arma1, inimigo1, habilidade1);
        Console.ReadKey();


    }

    public static void Menu(Guerreiro guerreiro, Arqueiro arqueiro, Mago mago, Arma arma1, Inimigo inimigo1, Habilidades habilidade1)
    {
        Personagem jogador = ComecoJogo(guerreiro, arqueiro, mago);
        Console.WriteLine("\tcarregando...");
        Console.Clear();
        Thread.Sleep(700);
        primeiroTurno(jogador, arma1, inimigo1, habilidade1);
        Console.Beep();

    }

    public static Personagem ComecoJogo(Guerreiro guerreiro, Arqueiro arqueiro, Mago mago)
    {
        /*SoundPlayer player = new SoundPlayer();
        player.SoundLocation = "https://www.youtube.com/watch?v=Jv1j1GzGO2w";
        player.Load();
        player.PlayLooping();*/
        Console.WriteLine("### INICIANDO JOGO ###");
        Console.WriteLine("\tcarregando...");
        Thread.Sleep(1200);
        Console.Clear();
        Console.WriteLine("d8888b.  d8888b.  d888b       d88888b  .d8b.  d8b   db d888888b  .d8b.  .d8888. d888888b d888888b  .o88b.  .d88b.  ");
        Console.WriteLine("88  `8D 88  `8D 88' Y8b      88'     d8' `8b 888o  88 `~~88~~' d8' `8b 88'  YP `~~88~~'   `88'   d8P  Y8 .8P  Y8. ");
        Console.WriteLine("88oobY' 88oodD' 88           88ooo   88ooo88 88V8o 88    868    88ooo88 `8bo.      88       88    8P      88    88 ");
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

            case 1: jogador = guerreiro.CriarPersonagem(); break;
            case 2: jogador = arqueiro.CriarPersonagem(); break;
            case 3: jogador = mago.CriarPersonagem(); break;
            default: Console.WriteLine("Tente novamente! Escolha errada!"); return null;//player.Stop(); return null;
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
        //player.Stop();
        return jogador;
    }

    public static void primeiroTurno(Personagem jogador, Arma arma, Inimigo inimigo, Habilidades habilidade)
    {
        /*SoundPlayer MusicaTensa = new SoundPlayer("Blablabla.wav");
        SoundPlayer Yoshi = new SoundPlayer("Yoshi.wav");
        MusicaTensa.Load();
        MusicaTensa.PlayLooping();*/
        Console.WriteLine("\tAh não, a frente do castelo você ja avista o Guarda do Castelo!");
        Console.WriteLine($"\tQue bom que sua irmã Lelezinha lhe enviou um(a) {arma.Nome}...");
        Thread.Sleep(1555);
        Console.WriteLine();
        Arma.AdicionarArma(jogador, arma);
        Thread.Sleep(7000);
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
        Console.WriteLine($"\tEita! o/a {inimigo.Nome} está chegando mais perto, a batalha irá começar!");
        Thread.Sleep(2400);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tUfa! A batalha acabou! Foi por pouco...");
        Thread.Sleep(2550);
        //MusicaTensa.Stop();
        Console.Clear();
       /* Yoshi.Load();
        Yoshi.PlayLooping();*/
        Console.WriteLine($"\tOpa! O que é isso aqui? eu acho que é uma {habilidade.Nome}!");
        Habilidades.AdicionarHabilidade(jogador, habilidade);
        Thread.Sleep(10000);
        Console.Clear();
        flag = true;
        while (flag)
        {
            habilidade.ExibirInfo();
            Console.WriteLine("* Digite 'A' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'A') flag = false;
        }
       // Yoshi.Stop();
    }

    public static void segundoTurno(Personagem jogador, Arma arma, Inimigo inimigo)
    {

        /*SoundPlayer MusicaTensa = new SoundPlayer("Blablabla.wav");
        SoundPlayer Yoshi = new SoundPlayer("Yoshi.wav");
        MusicaTensa.Load();
        MusicaTensa.PlayLooping();*/
        Console.WriteLine("\tAiAi... Esse castelo é lindo...");
        Console.WriteLine("\tAh não... De novo não! Isso é um Crocodilo do Fosso? Será que ele é do mal??");
        Thread.Sleep(2355);
        Console.Clear();
        Console.WriteLine($"\tEita! o/a {inimigo.Nome} está chegando mais perto, a batalha irá começar!");
        Thread.Sleep(2400);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tUfa! A batalha acabou! Essa foi tensa...");
        Thread.Sleep(2550);
        //MusicaTensa.Stop();
        Console.Clear();
        /* Yoshi.Load();
         Yoshi.PlayLooping();*/
        Console.WriteLine($"\tOpa! O que é isso aqui? eu acho que é uma {arma.Nome}!");
        Thread.Sleep(700);
        Arma.AdicionarArma(jogador, arma);
        Thread.Sleep(5000);
        Console.Clear();
        bool flag = true;
        while (flag)
        {
            arma.ExibirInfo();
            Console.WriteLine("* Digite 'A' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'A') flag = false;
        }
        // Yoshi.Stop();
    }

    public static void TerceiroTurno(Personagem jogador, Inimigo inimigo, Habilidades habilidade)
    {
        /*SoundPlayer MusicaTensa = new SoundPlayer("Blablabla.wav");
        SoundPlayer Yoshi = new SoundPlayer("Yoshi.wav");
        MusicaTensa.Load();
        MusicaTensa.PlayLooping();*/
        Console.WriteLine("\tQue esculturas bonitas!");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("#################################");
        Console.WriteLine("### VOCÊ RECEBEU UMA MENSAGEM ###");
        Console.WriteLine("# 1 - Ver mensagem              #");
        Console.WriteLine("# 2 - Prosseguir (não ver)      #");
        Console.WriteLine("#################################");
        int response = int.Parse(Console.ReadLine());
        Console.Clear() ;
        if (response == 1)
        {
            Console.WriteLine("\t############################################################");
            Console.WriteLine("\tDE: Lelezinha");
            Console.WriteLine($"\tPARA: {jogador.Nome}");
            Console.WriteLine();
            Console.WriteLine($"\tOi irmã(o)! Estou muito aflita pensando em tudo que você\n\testá passando. Ouvi dizer que existem monstros muito\n\t" +
                $"perigosos nesse castelo, por conta disso estou\n\tlhe enviando uma habilidade de {habilidade.Nome}.\n\n\tO sábio disse que é bem potente, mas só pode ser utilizada uma vez em.");
            Console.WriteLine("\tBeijinhos beijinhos sua irmã favorita.\n");
            Console.WriteLine("\t############################################################");
            Thread.Sleep(8000);
            Habilidades.AdicionarHabilidade(jogador, habilidade);
            Thread.Sleep(2000);
            Console.Clear();
            bool flag = true;
            while (flag)
            {
                habilidade.ExibirInfo();
                Console.WriteLine("* Digite 'A' para prosseguir");
                char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
                if (val == 'A') flag = false;
            }
            Console.Clear();
        }
        else Console.WriteLine("OK!");
        
        Console.WriteLine($"\tEita! a {inimigo.Nome} está se virando, a batalha irá começar!");
        Thread.Sleep(2400);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tUfa! A batalha acabou! Essa foi beeeem tensa né?...");
        Thread.Sleep(2550);
        //MusicaTensa.Stop();
        Console.Clear();
        
    }

    public static void QuartoTurno(Personagem jogador, Inimigo inimigo, Arma arma)
    {
        Console.WriteLine("\tTem tanta coisa antiga aqui né?");
        Thread.Sleep(1555);
        Console.WriteLine("\tSerá que alguém ja tentou resgatar a princesa e não conseguiu?");
        Thread.Sleep(4333);
        Console.Clear();
        Console.WriteLine($"\t# {inimigo.Nome}: Claro que alguém já tentou salvar ela!");
        Thread.Sleep(2000);
        Console.WriteLine($"\t# {jogador.Nome}: Você? Quer me ajudar? Quem sabe juntos podemos salvar ela!");
        Thread.Sleep(2000);
        Console.WriteLine($"\t# {inimigo.Nome}: Eu? Ajudar você? Claro que não! HAHAHAHA SOU MALIGNO!!");
        Thread.Sleep(2500);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tEu acho que esse esqueleto foi almediciado...");
        Console.WriteLine("\tPelo o menos consgeui roubar a dele");
        Thread.Sleep(2005);
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
    }

    


}
