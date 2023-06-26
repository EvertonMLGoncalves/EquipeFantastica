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
            /*Guerreiro g1 = (Guerreiro)new Guerreiro().CriarPersonagem();
            Inimigo n1 = (Inimigo)new Inimigo().CriarPersonagem();
            *//* 
             Guerreiro g1 = new Guerreiro(1, "Joao", "Macho"); 
             Inimigo n1 = new Inimigo(1, 10, "Guarda Maligno", "Macho", Enums.EnumTipoInimigo.GuardaDoCastelo, Enums.EnumHabilidadeInimigo.Atordoar);*//*

            Arma arma1 = new Arma().CriarArma();
            Arma arma2 = new Arma().CriarArma();
            Arma.AdicionarArma(g1, arma1);
            Arma.AdicionarArma(n1 , arma2);
            Arma.AdicionarArma(g1, arma2);  
            
            Habilidades h1 = new Habilidades().CriarHabilidade(); 
            Habilidades h2 = new Habilidades().CriarHabilidade(); 
             
            Habilidades.AdicionarHabilidade(g1 , h1);
            Habilidades.AdicionarHabilidade(g1, h2);*/



            // Habilidades habilidade1 = new Habilidades().criarHabilidade();
            //Habilidades habilidade2 = new Habilidades().criarHabilidade();

            //Habilidades.dropHabilidade(g1, habilidade1);
            //Habilidades.dropHabilidade(g1 , habilidade2);
            // /*foreach(Arma arma in g1.ListaArmas) Console.WriteLine(arma.Nome);*/

            /* Guerreiro guerreiro1 = (Guerreiro)new Guerreiro().CriarPersonagem();
             Guerreiro guerreiro2 = (Guerreiro)new Guerreiro().CriarPersonagem();
             Guerreiro guerreiro3 = (Guerreiro)new Guerreiro().CriarPersonagem();
             Guerreiro guerreiro4 = (Guerreiro)new Guerreiro().CriarPersonagem();*/



            /*arma1.ExibirInfo();
          */


            /*guerreiro1.ExibirInfo();

           guerreiro1.AtualizarDados();*/


            Guerreiro g1 = new Guerreiro(1, "Joao", "m");
            Inimigo n1 = new Inimigo(0, 400, "Cavaleiro do mal", "M");  
             
            Arma arma1 = new Arma(1, "Espada", 60, 1, "Espadas", 1, "");
            Arma arma2 = new Arma(1, "Espada Longa", 90, 1, "Espadas", 1, "");
            Arma.VerificarHabilidadeItem(arma1, g1);
            Arma.VerificarHabilidadeItem(arma2, g1);
            Arma.AdicionarArma(g1, arma1);
            Arma.AdicionarArma(n1, arma2);
            Arma.AdicionarArma(g1, arma2);

            /*foreach (var arma in g1.ListaArmas)
            {
                Console.WriteLine(arma.Nome);
            }*/

            /*Habilidades h1 = new Habilidades("Bola de fogo", Enums.TipoHabilidade.Incendiante, 1, 30);
            Habilidades.AdicionarHabilidade(g1, h1);*/

            Batalha.IniciarBatalha(g1, n1);








            Console.ReadKey();

        }
    }
}
