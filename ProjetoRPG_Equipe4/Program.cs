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
           Guerreiro g1 = (Guerreiro)new Guerreiro().CriarPersonagem();
            Inimigo n1 = (Inimigo) new Inimigo().CriarPersonagem();
             
            Arma arma1 = new Arma().CriarArma();
            Arma arma2 = new Arma().CriarArma();
            Arma.DroparArmas(g1, arma1);
            Arma.DroparArmas(n1 , arma2);
            Arma.DroparArmas(g1, arma2);

           // Habilidades habilidade1 = new Habilidades().criarHabilidade();
            //Habilidades habilidade2 = new Habilidades().criarHabilidade();
            
            //Habilidades.dropHabilidade(g1, habilidade1);
            //Habilidades.dropHabilidade(g1 , habilidade2);

            

           Batalha.IniciarBatalha(g1, n1);

            foreach(Arma arma in g1.ListaArmas) Console.WriteLine(arma.Nome);

            /* Guerreiro guerreiro1 = (Guerreiro)new Guerreiro().CriarPersonagem();
             Guerreiro guerreiro2 = (Guerreiro)new Guerreiro().CriarPersonagem();
             Guerreiro guerreiro3 = (Guerreiro)new Guerreiro().CriarPersonagem();
             Guerreiro guerreiro4 = (Guerreiro)new Guerreiro().CriarPersonagem();*/



            arma1.ExibirInfo();
          

            
            /*guerreiro1.ExibirInfo();

           guerreiro1.AtualizarDados();*/

            Console.ReadKey();

        }
    }
}
