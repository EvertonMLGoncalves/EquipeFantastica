using ProjetoRPG_Equipe4.Artefatos;
using ProjetoRPG_Equipe4.Combate;
using ProjetoRPG_Equipe4.Enums;
using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Diagnostics;
using System.Media;
using System.Threading;

public class Jogo
{
    SoundPlayer flora = new SoundPlayer("flora.wav");
    SoundPlayer tensa = new SoundPlayer("tenso.wav");
    SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
    public static void Main(string[] args)
    {
        Guerreiro guerreiro = new Guerreiro();
        Arqueiro arqueiro = new Arqueiro();
        Mago mago = new Mago();

        // Fase 1
        Arma arma1 = new Arma(1, "Espada Fantástica", 80, 1, 4, "Cortar com muita ferocidade");
        Inimigo inimigo1 = new Inimigo("Guarda do Castelo", "Masculino", 3, 5, 5, 15, EnumTipoInimigo.GuardaDoCastelo, EnumHabilidadeInimigo.Atordoar);
        Habilidades habilidade1 = new Habilidades("Super Veneno", ProjetoRPG_Equipe4.Enums.TipoHabilidade.Envenenante, 2, 35);

        // Fase 2
        Arma arma2 = new Arma(2, "Flecha Perfeita", 60, 2, 2, "Acerta bem no coração");
        Inimigo inimigo2 = new Inimigo("Crocodilo do Fosso", "Macho", 5, 15, 15, 25, EnumTipoInimigo.CrocodiloDoFosso, EnumHabilidadeInimigo.GiroMortal);

        // Fase 3
        Habilidades habilidade3 = new Habilidades("Superdoado", TipoHabilidade.Atordoante, 1, 50);
        Inimigo inimigo3 = new Inimigo("Gragula da torre", "Feminino", 7, 25, 20, 30, EnumTipoInimigo.GargulaDaTorre, EnumHabilidadeInimigo.Incendiar);

        // Fase 4
        Inimigo inimigo4 = new Inimigo("Esqueleto Malígno", "Masculino", 9, 35, 30, 40, EnumTipoInimigo.EsqueletoMaligno, EnumHabilidadeInimigo.Regeneracao);
        Arma arma4 = new Arma(3, "Bola de fogo suprema", 50, 3, 3, "Bolada na cara!");

        // Fase 5
        Inimigo inimigo5 = new Inimigo("Minotauro", "Masculino", 12, 50, 40, 60, EnumTipoInimigo.Minotauro, EnumHabilidadeInimigo.Coice);
        Arma arma5 = new Arma(4, "Espada da sorte", 50, 1, 3, "Mata bem");

        // Fase 6
        Inimigo inimigo6 = new Inimigo("Ogro da Torre", "Masculino", 15, 60, 50, 70, EnumTipoInimigo.OgroDaTorre, EnumHabilidadeInimigo.GritoSupersonico);
        Habilidades habilidade6 = new Habilidades("Boa noite Cinderella", TipoHabilidade.Sedante, 1, 90);

        // Fase 7
        Inimigo inimigo7 = new Inimigo("Rei das Trevas", "Masculino", 20, 80, 70, 90, EnumTipoInimigo.ReiDasTrevas, EnumHabilidadeInimigo.Adormecer);

        Menu(guerreiro, arqueiro, mago, arma1, inimigo1, habilidade1,arma2,inimigo2,habilidade3,inimigo3,inimigo4,arma4,inimigo5,arma5,inimigo6,habilidade6,inimigo7);
        Console.ReadKey();


    }

    public static void Menu(Guerreiro guerreiro, Arqueiro arqueiro, Mago mago, Arma arma1, Inimigo inimigo1, Habilidades habilidade1,
        Arma arma2,Inimigo inimigo2, Habilidades habilidade3, Inimigo inimigo3, Inimigo inimigo4, Arma arma4,Inimigo inimigo5, Arma arma5, Inimigo inimigo6, Habilidades habilidade6, Inimigo inimigo7)
    {
        Personagem jogador = ComecoJogo(guerreiro, arqueiro, mago);
        Console.WriteLine("\tcarregando...");
        Console.Clear();
        Thread.Sleep(700);
        primeiroTurno(jogador, arma1, inimigo1, habilidade1);
        segundoTurno(jogador, arma2, inimigo2);
        TerceiroTurno(jogador, inimigo3, habilidade3);
        QuartoTurno(jogador, inimigo4, arma4);
        QuintoTurno(jogador, arma5, inimigo5);
        SextoTurno(jogador, inimigo6, habilidade6);
        SetimoTurno(jogador, inimigo6);
        Console.Beep();

    }

    public static Personagem ComecoJogo(Guerreiro guerreiro, Arqueiro arqueiro, Mago mago)
    {
        SoundPlayer flora = new SoundPlayer("flora.wav");
        /*flora.Load();*//*
        flora.PlayLooping();*/
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
        Console.WriteLine("\tNão obstante apenas com a morte do Rei Gwyn, o Cavaleiro das Trevas Nevra decidiu apossar-se não apenas da felicidade daquele vilarejo...");
        Console.WriteLine("\tfelicidade daquele vilarejo. Mas também, da filha do mesmo - a Princesa Aurora. Você acha que pode impedí-lo? Do contrário, a linguagem");
        Console.WriteLine("\tmística Java se apossará, contorcendo a mente daqueles que acreditaram fervorosamente num dia melhor. Os guardas do castelo já foram pegos!");
        Console.WriteLine("\tApresse-se!\n");
        Thread.Sleep(5000);
        Console.WriteLine("Pressione qualquer tecla para continuar");
        Console.ReadKey();
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
            Console.WriteLine("* Digite 'X' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'X') flag = false;
        }
        Thread.Sleep(500);
        flora.Stop();
        return jogador;
    }
    public static void primeiroTurno(Personagem jogador, Arma arma, Inimigo inimigo, Habilidades habilidade)
    {

        SoundPlayer tensa = new SoundPlayer("tenso.wav");
        SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
        /*tensa.Load();*//*
        tensa.PlayLooping();*/
        Console.WriteLine("\tO guarda do castelo está a sua frente. Deve ser um daqueles humanos manipulados.");
        Thread.Sleep(2000);
        Console.WriteLine($"\tFoi uma boa ter guardado a sua {arma.Nome} que achaste nos escombros.");
        Thread.Sleep(4000);
        Console.WriteLine();
        Arma.AdicionarArma(jogador, arma);
        Console.WriteLine("\nPressione qualquer tecla para continuar");
        Console.ReadKey();
        Console.Clear();
        bool flag = true;
        while (flag)
        {
            arma.ExibirInfo();
            Console.WriteLine("* Digite 'X' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'X') flag = false;
        }
        Console.Clear();
        Console.WriteLine($"\tAtente-se. O/A {inimigo.Nome} está chegando mais perto de forma errática e bizarra, a batalha irá começar.");
        Thread.Sleep(4000);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tUfa! A batalha acabou! Foi por pouco...");
        Thread.Sleep(2550);
        tensa.Stop();
        Console.Clear();
        /*yoshi.Load();
        yoshi.PlayLooping();*/
        Console.WriteLine($"\tOpa! O que é isso aqui? eu acho que é uma {habilidade.Nome}!");
        Habilidades.AdicionarHabilidade(jogador, habilidade);
        Thread.Sleep(8000);
        Console.Clear();
        flag = true;
        while (flag)
        {
            habilidade.ExibirInfo();
            Console.WriteLine("* Digite 'X' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'X') flag = false;
        }
        yoshi.Stop();
        Console.Clear();
    }

    public static void segundoTurno(Personagem jogador, Arma arma, Inimigo inimigo)
    {

        SoundPlayer tensa = new SoundPlayer("tenso.wav");
        SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
        tensa.Load();
        tensa.PlayLooping();
        Console.WriteLine("\tEsse castelo é lindo...");
        Thread.Sleep(2000);
        Console.WriteLine("\tAh, óbvio que haveria um mascote! Se prepare, um Crocodilo feroz se prepara para te atacar!");
        Thread.Sleep(4000);
        Console.Clear();
        Console.WriteLine($"\tFique atento(a)! o/a {inimigo.Nome} está chegando mais perto, a batalha irá começar!");
        Thread.Sleep(4000);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tA batalha acabou, mas você sequer entrou pelo portão principal. Não seja otimista.");
        Thread.Sleep(3500);
        tensa.Stop();
        Console.Clear();
        yoshi.Load();
        yoshi.PlayLooping();
        Console.WriteLine($"\tVocê encontra algo no meio dos tijolos quebrados. É uma {arma.Nome}!");
        Thread.Sleep(700);
        Arma.AdicionarArma(jogador, arma);
        Thread.Sleep(7000);
        Console.Clear();
        bool flag = true;
        while (flag)
        {
            arma.ExibirInfo();
            Console.WriteLine("* Digite 'X' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'X') flag = false;
        }
        yoshi.Stop();
        Console.Clear();
    }

    public static void TerceiroTurno(Personagem jogador, Inimigo inimigo, Habilidades habilidade)
    {
        SoundPlayer flora = new SoundPlayer("flora.wav");
        SoundPlayer tensa = new SoundPlayer("tenso.wav");
        SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
        flora.Load();
        flora.PlayLooping();
        Console.WriteLine("\tQue esculturas bonitas!");
        Thread.Sleep(4000);
        Console.Clear();
        Console.WriteLine("#################################");
        Console.WriteLine("### VOCÊ RECEBEU UMA MENSAGEM ###");
        Console.WriteLine("# 1 - Ver mensagem              #");
        Console.WriteLine("# 2 - Prosseguir (não ver)      #");
        Console.WriteLine("#################################");
        int response = int.Parse(Console.ReadLine());
        Console.Clear();
        if (response == 1)
        {
            Console.WriteLine("\t############################################################");
            Console.WriteLine("\tDE: Anônimo");
            Console.WriteLine($"\tPARA: {jogador.Nome}");
            Console.WriteLine();
            Console.WriteLine($"\tSó você sabe o que está passando por. \n\t Ouvi dizer que existem monstros muito\n\t" +
                $"perigosos nesse castelo, por conta disso estou\n\tte enviando uma habilidade de {habilidade.Nome}.\n\n\tÉ bem potente, mas só pode ser utilizada uma vez, hein!");
            Console.WriteLine("\tÉ cortesia de alguém que se divertiria te vendo apanhar ou vencer. Não quero sua gratidão.\n");
            Console.WriteLine("\t############################################################");
            Thread.Sleep(15000);
            flora.Stop();
            yoshi.Load();
            yoshi.PlayLooping();
            Habilidades.AdicionarHabilidade(jogador, habilidade);
            Thread.Sleep(4000);
            Console.Clear();
            bool flag = true;
            while (flag)
            {
                habilidade.ExibirInfo();
                Console.WriteLine("* Digite 'X' para prosseguir");
                char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
                if (val == 'X') flag = false;
            }
            yoshi.Stop();
            Console.Clear();
        }
        else Console.WriteLine("OK!");
        flora.Stop();
        tensa.Load();
        tensa.Play();
        Console.WriteLine($"\tPelos céus, a {inimigo.Nome} está se virando, a batalha irá começar!");
        Thread.Sleep(4000);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tVocê já deve estar se perguntando de onde surgem tantas criaturas medonhas... Não importa. Só siga em frente.");
        Thread.Sleep(4050);
        tensa.Stop();
        Console.Clear();

    }

    public static void QuartoTurno(Personagem jogador, Inimigo inimigo, Arma arma)
    {

        SoundPlayer tensa = new SoundPlayer("tenso.wav");
        SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
        tensa.Load();
        tensa.Play();
        Console.WriteLine("\tTem tanta coisa antiga aqui né?");
        Thread.Sleep(4000);
        Console.WriteLine("\tSerá que alguém ja tentou resgatar a princesa e não conseguiu?");
        Thread.Sleep(4000);
        Console.Clear();
        Console.WriteLine($"\t\t# {inimigo.Nome}: Tsc. Claro que alguém já tentou salvar ela!");
        Thread.Sleep(4000);
        Console.WriteLine($"\t\t# {jogador.Nome}: Você? Quer me ajudar? Parece que não está na melhor forma.");
        Thread.Sleep(4000);
        Console.WriteLine($"\t\t# {inimigo.Nome}: Pelo menos você entende que não estou do seu lado, idiota! Mwahahaha!");
        Thread.Sleep(4000);
        Console.Clear();
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tVocê pensa que o Cavalheiro das Trevas deve ser alguém terrível para manipular até mesmo esqueletos.");
        Console.WriteLine("\tPelo menos, você consegue sacar a arma do defunto. Um morto pela segunda vez.");
        Thread.Sleep(5000);
        tensa.Stop();
        yoshi.Load();
        yoshi.Play();
        Console.WriteLine();
        Arma.AdicionarArma(jogador, arma);
        Thread.Sleep(3333);
        Console.Clear();
        bool flag = true;
        while (flag)
        {
            arma.ExibirInfo();
            Console.WriteLine("* Digite 'X' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'X') flag = false;
        }
        yoshi.Stop();
        Console.Clear();
    }

    public static void QuintoTurno(Personagem jogador, Arma arma, Inimigo inimigo)
    {

        SoundPlayer tensa = new SoundPlayer("tenso.wav");
        SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
        tensa.Load();
        tensa.Play();
        Console.WriteLine("\tAcho que a princesa é por esse lado!");
        Thread.Sleep(2000);
        Console.WriteLine("\t* começando a subir as escadas *");
        Console.WriteLine("\tIsso é um cavalo?");
        Thread.Sleep(3000);
        Console.WriteLine("\tAh não....");
        Thread.Sleep(3333);
        Console.Clear() ;
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("\tQue bicho estranho! Enfim... Que bom que está.. né?");
        Thread.Sleep(3333);
        Console.Clear();
        tensa.Stop();
        yoshi.Load();
        yoshi.Play();
        Console.WriteLine("\tOpa, o que é isso que caiu aqui??");
        Thread.Sleep(2005);
        Console.WriteLine();
        Arma.AdicionarArma(jogador, arma);
        Thread.Sleep(3000);
        Console.Clear();
        bool flag = true;
        while (flag)
        {
            arma.ExibirInfo();
            Console.WriteLine("* Digite 'X' para prosseguir");
            char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
            if (val == 'X') flag = false;
        }
        Console.Clear();
        yoshi.Stop();
    }

    public static void SextoTurno(Personagem jogador, Inimigo inimigo, Habilidades habilidade)
    {

        SoundPlayer flora = new SoundPlayer("flora.wav");
        SoundPlayer tensa = new SoundPlayer("tenso.wav");
        SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
        flora.Load();
        flora.Play();
        Console.WriteLine("\tQue esculturas bonitas!");
        Thread.Sleep(2000);
        Console.Clear();
        Console.WriteLine("#################################");
        Console.WriteLine("### VOCÊ RECEBEU UMA MENSAGEM ###");
        Console.WriteLine("# 1 - Ver mensagem              #");
        Console.WriteLine("# 2 - Prosseguir (não ver)      #");
        Console.WriteLine("#################################");
        int response = int.Parse(Console.ReadLine());
        Console.Clear();
        if (response == 1)
        {
            Console.WriteLine("\t############################################################");
            Console.WriteLine("\tDE: Sábio");
            Console.WriteLine($"\tPARA: {jogador.Nome}");
            Console.WriteLine();
            Console.WriteLine($"\tOlá {jogador.Nome}, estou muito orgulhoso de você e toda tua\n\tperserverança! Nosso vilarejo se uniu e conseguimos combrar essa arma!\n\t" +
                $"Lembre-se de utilizá-la com muita sabedoria\n");
            Console.WriteLine("\tAbraços\n");
            Console.WriteLine("\t############################################################");
            Thread.Sleep(1000);
            flora.Stop();
            yoshi.Load();
            yoshi.Play();
            Habilidades.AdicionarHabilidade(jogador, habilidade);
            Thread.Sleep(2000);
            Console.Clear();
            bool flag = true;
            while (flag)
            {
                habilidade.ExibirInfo();
                Console.WriteLine("* Digite 'X' para prosseguir");
                char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
                if (val == 'X') flag = false;
                
            }
            Console.Clear();
            yoshi.Stop();
        }
        else { Console.WriteLine("OK!"); Thread.Sleep(2000); Console.Clear(); }
        flora.Stop();
        tensa.Load();
        tensa.Play();
        Console.WriteLine("\tO que será que vem agora?");
        Batalha.IniciarBatalha(jogador, inimigo);
        Console.WriteLine("Tchau...");
        Thread.Sleep(2000);
        Console.Clear();
        tensa.Stop();
    }

    public static void SetimoTurno(Personagem jogador, Inimigo inimigo)
    {
        SoundPlayer tensa = new SoundPlayer("tenso.wav");
        SoundPlayer yoshi = new SoundPlayer("Yoshi.wav");
        tensa.Load();
        tensa.Play();
        Console.WriteLine($"\t\t# {jogador.Nome}: Princesa! Princesa! Estou chegando aí!");
        Thread.Sleep(2000);
        Console.WriteLine($"\t\t# {inimigo.Nome}: Você acha que ficaria tão barato assim?");
        Thread.Sleep(2000);
        Console.WriteLine($"\t\t# {jogador.Nome}: Se estou aqui, é porque sua defesa não foi exatamente das melhores.");
        Thread.Sleep(3333);
        Console.WriteLine();
        Console.WriteLine("Envolto(a) na adrenalina de atacar uma criatura horrenda e trazer a paz para o vilarejo vitimado pelos atos infames");
        Console.WriteLine("Você ataca com toda sua força!");
        Thread.Sleep(5000);
        Console.Clear();

        Batalha.IniciarBatalha(jogador, inimigo);
        tensa.Stop();
        Console.WriteLine("Isso foi definitivamente mais difícil do que você imaginava...");
        Console.WriteLine("d88888b      d8b   db      d8888b.");
        Console.WriteLine("88'          888o  88      88  `8D");
        Console.WriteLine("88ooooo      88V8o 88      88   88");
        Console.WriteLine("88~~~~~      88 V8o88      88   88");
        Console.WriteLine("88.          88  V888      88  .8D");
        Console.WriteLine("Y88888P      VP   V8P      Y8888D'");
        yoshi.Stop();
    }
}
