using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                Console.WriteLine("Digite: \n1-Para atacar \n2-para fugir");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        jogador.Atacar(inimigo);
                        Console.WriteLine("Você está atacando!\n");
                        //jogador.Atacar(inimigo);
                        Console.WriteLine("==========================");
                        Thread.Sleep(1000);
                        if (inimigo.PontosVida <= 0)
                        {
                            Console.WriteLine("VOCÊ VENCEU!!!!!!!!");
                            XPganho += 10;// ~~Helena
                            TerminarBatalha(inimigo, vidaInicialInimigo, jogador, vidaInicialJogador, XPganho);
                            Thread.Sleep(10000);
                            Console.Clear();
                            flag = false;
                            break;
                        }
                        inimigo.Atacar(jogador);
                        if (jogador.PontosVida <= 0)
                        {
                            Console.WriteLine("\n****************** \nGAME OVER!  " +
                                "\n******************");
                            Console.WriteLine("--------------------------");
                            TerminarBatalha(jogador, vidaInicialJogador, inimigo, vidaInicialInimigo,XPganho);
                            Console.Clear();
                            Thread.Sleep(10000);
                            flag = false;
                            break;

                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.WriteLine("Fugindo...");
                        TerminarBatalha(jogador, vidaInicialJogador, inimigo, vidaInicialInimigo,XPganho);
                        Thread.Sleep(10000);
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
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Resultados da Batalha:");
                Console.WriteLine($"{jogador.Nome} morreu...");
                Console.WriteLine($"Vida atual de {inimigo.Nome}: {inimigo.PontosVida}");
                Console.WriteLine($"Dano causado por {jogador.Nome}: {vidainicialinimigo - inimigo.PontosVida}");
                Console.WriteLine($"XP final: {jogador.XP}");
                Console.WriteLine("------------------------------------------------------");

            }
            else if (inimigo.PontosVida <= 0)
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Resultados da Batalha:");
                Console.WriteLine($"{inimigo.Nome} foi derrotado!");
                Console.WriteLine($"Vida atual de {jogador}: {jogador.PontosVida}");
                Console.WriteLine($"Dano causado por {inimigo.Nome}: {vidainicialjogador - jogador.PontosVida}");
                Console.WriteLine("------------------------------------------------------");
            }
            else
            {
                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("Resultados da Batalha:");
                Console.WriteLine($"{jogador.Nome} fugiu da batalha");
                Console.WriteLine($"Vida atual de {jogador.Nome}: {jogador.PontosVida}");
                Console.WriteLine($"Dano recebido: {vidainicialjogador - jogador.PontosVida}");
                Console.WriteLine($"Vida atual de {inimigo.Nome}: {inimigo.PontosVida}");
                Console.WriteLine($"Dano recebido: {vidainicialinimigo - inimigo.PontosVida}");
                Console.WriteLine("------------------------------------------------------");
            }

        }


    }
}

