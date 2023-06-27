using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Threading;

namespace ProjetoRPG_Equipe4.Combate
{
    internal static class Batalha
    {


        public static void IniciarBatalha(Personagem jogador, Personagem inimigo) // ESSE OU O ATACAR PRECISA REFINAR!!
        {
            int XPganho = 0; // Adicionei o XP ~Helena
            bool flag = true;
            int vidaInicialJogador = jogador.PontosVida;
            int vidaInicialInimigo = inimigo.PontosVida;
            while (flag)
            {
                Console.WriteLine("##########################################");
                Console.WriteLine($"# Vida atual de {inimigo.Nome}: {inimigo.PontosVida} #");
                Console.WriteLine($"# Vida atual do seu personagem: {jogador.PontosVida} #");
                Console.WriteLine("##########################################");
                Thread.Sleep(3000);
                Console.Clear();
                Console.WriteLine("  ## SUA VEZ ###");
                Console.WriteLine("  # 1 - Atacar #");
                Console.WriteLine("  # 2 - Fugir  #");
                Console.WriteLine("  ##############");
                int op = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Você está atacando!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        jogador.Atacar(inimigo);
                        Console.WriteLine("#############################");
                        Thread.Sleep(1000);
                        if (inimigo.PontosVida <= 0)
                        {
                            Console.WriteLine("■O■O■O■O■O■ VOCÊ VENCEU ■O■O■O■O■O■");
                            XPganho += 10;// ~~Helena
                            TerminarBatalha(inimigo, vidaInicialInimigo, jogador, vidaInicialJogador, XPganho);
                            Thread.Sleep(5000);
                            Console.Clear();
                            flag = false;
                            break;
                        }
                        if (inimigo.TurnosAfetado != 0) //~~Everton
                        {
                            if (inimigo.VerificarStatus())
                            {
                                inimigo.VerificarDano();
                                Console.WriteLine("Você está sendo atacado!");
                                inimigo.Atacar(jogador);
                            }  
                            else
                            {
                                Console.WriteLine($"{inimigo.Nome} está dormindo e ficará {inimigo.TurnosAfetado} sem jogar...");
                            }
                        }
                        else  //~~Everton
                        {
                            Console.WriteLine("Você está sendo atacado!");
                            inimigo.Atacar(jogador);
                        }
                        if (jogador.PontosVida <= 0)
                        {
                            Console.WriteLine("****************** GAME OVER! ******************");
                            Console.Clear();
                            TerminarBatalha(jogador, vidaInicialJogador, inimigo, vidaInicialInimigo, XPganho);
                            Console.Clear();
                            Thread.Sleep(5000);
                            flag = false;
                            break;
                        }
                        
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Fugindo...");
                        TerminarBatalha(jogador, vidaInicialJogador, inimigo, vidaInicialInimigo, XPganho);
                        Thread.Sleep(5000);
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Valor inválido");
                        break;
                }
            }

        }
        public static void TerminarBatalha(Personagem jogador, int vidainicialjogador, Personagem inimigo, int vidainicialinimigo, int XPGanho)
        {
            jogador.XP += XPGanho;
            if (jogador.PontosVida <= 0)
            {
                
                Console.WriteLine("########## RESULTADO DAS BATALHA ##########");
                Console.WriteLine($"# {jogador.Nome} morreu...\t\t\t  #");
                Console.WriteLine($"# Vida atual de {inimigo.Nome}: {inimigo.PontosVida}  #");
                Console.WriteLine($"# Dano causado por {jogador.Nome}: {vidainicialinimigo - inimigo.PontosVida}\t\t  #");
                Console.WriteLine($"# XP final: {jogador.XP}\t\t\t\t  #");
                Console.WriteLine("###########################################");

            }
            else if (inimigo.PontosVida <= 0)
            {
                Console.WriteLine("########## RESULTADO DAS BATALHA ##########");
                Console.WriteLine($"# {inimigo.Nome} foi derrotado!\t    #");
                Console.WriteLine($"# Vida atual de {jogador}: {jogador.PontosVida}\t\t    #");
                Console.WriteLine($"# Dano causado por {inimigo.Nome}: {vidainicialjogador - jogador.PontosVida}  #");
                Console.WriteLine("#############################################");
            }
            else
            {
                Console.WriteLine("##########################################");
                Console.WriteLine($"# {jogador.Nome} fugiu da batalha\t\t #");
                Console.WriteLine($"# Vida atual de {jogador.Nome}: {jogador.PontosVida}\t\t #");
                Console.WriteLine($"# Dano recebido: {vidainicialjogador - jogador.PontosVida}\t\t\t #");
                Console.WriteLine($"# Vida atual de {inimigo.Nome}: {inimigo.PontosVida} #");
                Console.WriteLine($"# Dano recebido: {vidainicialinimigo - inimigo.PontosVida}\t\t\t #");
                Console.WriteLine("##########################################");
            }

        }

/*
        public static void ReceberXP(int experiencia) // ~~Dani Alves
        {
            XP += experiencia;

            int xpNecessario = CalcularXpNecessarioNivel(Nivel);
            if (XP >= xpNecessario)
            {
                Nivel++;
            }
        }

        private int CalcularXpNecessarioNivel(int nivel) // ~~Dani Alves
        {
            return 100 * nivel; //100 de xp para o prox nivel*/
        }
    }


