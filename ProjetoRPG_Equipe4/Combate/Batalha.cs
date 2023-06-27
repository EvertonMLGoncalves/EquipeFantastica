﻿using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Threading;

namespace ProjetoRPG_Equipe4.Combate
{
    internal static class Batalha
    {

        public static void IniciarBatalha(Personagem jogador, Personagem inimigo)
        {
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
                        flag = ControlarTurno(jogador, vidaInicialJogador, inimigo, vidaInicialInimigo, flag);
                        break;
                    case 2:
                        Console.WriteLine("# Fugindo... #");
                        TerminarBatalha(jogador, vidaInicialJogador, inimigo, vidaInicialInimigo);
                        Thread.Sleep(10000);
                        Console.Clear();
                        flag = !flag;
                        break;
                    default:
                        Console.WriteLine("Valor inválido"); flag = !flag;
                        break;
                }
            }

        }
        public static void TerminarBatalha(Personagem jogador, int vidainicialjogador, Personagem inimigo, int vidainicialinimigo)
        {
            jogador.ReceberXP(inimigo.XP);

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
                Console.WriteLine("########### RESULTADO DAS BATALHA ###########");
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

        public static bool ControlarTurno(Personagem jogador, int vidainicialjogador, Personagem inimigo, int vidainicialinimigo, bool flag)
        {
            Console.WriteLine("Você está atacando!");
            Thread.Sleep(3000);
            Console.Clear();
            jogador.Atacar(inimigo);
            Console.WriteLine("#############################");
            Thread.Sleep(1000);
            if (inimigo.PontosVida <= 0)
            {
                Console.WriteLine("■O■O■O■O■O■ VOCÊ VENCEU ■O■O■O■O■O■");
                TerminarBatalha(inimigo, vidainicialjogador, jogador, vidainicialinimigo);
                Thread.Sleep(5000);
                Console.Clear();
                flag = false;
            }
            if (inimigo.TurnosAfetado != 0) //~~Everton
            {
                if (inimigo.VerificarStatus())
                {
                    inimigo.VerificarDano();
                    Console.WriteLine($"{jogador.Nome} está sendo atacado!");
                    inimigo.Atacar(jogador);
                }
                else
                {
                    Console.WriteLine($"{inimigo.Nome} está dormindo: {inimigo.TurnosAfetado} turno(s) restante(s)");
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
                TerminarBatalha(jogador, vidainicialinimigo, inimigo, vidainicialinimigo);
                Console.Clear();
                Thread.Sleep(5000);
                flag = false;
            }
            Console.Clear();
            return flag;
        }
    }
}





