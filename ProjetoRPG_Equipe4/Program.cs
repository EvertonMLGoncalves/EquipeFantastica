using ProjetoRPG_Equipe4.Artefatos;
using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoRPG_Equipe4.Combate;

namespace ProjetoRPG_Equipe4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Guerreiro g1 = new Guerreiro(1, "Lucas", "Homem");

            Inimigo n1 = new Inimigo(1, 10, "Bicho feio", "Indefinido"); 
             
            Arma arma1 = new Arma(1, "Espada", 15);  
             
            Arma arma2 = new Arma(2, "Tridente", 40); 
             
            g1.ListaArmas.Add(arma1);

            n1.ListaArmas.Add(arma1);
            g1.ExibirInfo();

            /*Batalha.IniciarBatalha(g1, n1);*/

            Console.ReadKey();

        }
    }
}
