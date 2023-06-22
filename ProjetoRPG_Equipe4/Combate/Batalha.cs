using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Combate
{
    internal static class Batalha
    {


        public static void IniciarBatalha(Personagem jogador, Personagem inimigo)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Digite: \n1-Para atacar \n2-para fugir");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Você está atacando!\n");
                        jogador.Atacar(inimigo);
                        Console.WriteLine("==========================");
                        Thread.Sleep(1000);
                        if (inimigo.PontosVida <= 0)
                        {
                            Console.WriteLine("VOCÊ VENCEU!!!!!!!!");
                            Thread.Sleep(3000);
                            flag = false;
                            break;
                        }
                        Console.WriteLine("Você está sendo atacado!\n");
                        inimigo.Atacar(jogador);
                        if (jogador.PontosVida <= 0)
                        {
                            Console.WriteLine("Você morreu...");
                            Console.WriteLine("--------------------------");
                            Thread.Sleep(10000);
                            flag = false;
                            break;

                        }
                        Console.WriteLine("--------------------------");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }

            }

        }
        public static void TerminarBatalha()
        {

        }
    }
}
