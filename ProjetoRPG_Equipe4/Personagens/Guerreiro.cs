using Microsoft.SqlServer.Server;
using ProjetoRPG_Equipe4.Artefatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Personagens
{
    internal class Guerreiro : Personagem
    {
        public int Furia { get; set; }
        
        

        public Guerreiro(int id, string nome, string sexo) : base(nome, sexo)
        {
            Id = id;
            Nivel = 1;
            Furia = 1;
            Defesa = 30;
            PontosVida = 1500;
            Sexo = sexo;
            Nome = nome;
            Forca = 90;
            XP = 0;
            Status = "Saudável";
            CODIGO = 1;
        }
        public Guerreiro() { }
        public override void ExibirInfo() //~~Everton c/ Helena na call
        {
            Console.WriteLine($"Fúria: {Furia}");
            base.ExibirInfo();
        }
        public override Personagem CriarPersonagem() //~~Everton c/ Helena na call
        {
            Console.WriteLine("Digite a Fúria do Personagem:"); 
            Furia = int.Parse(Console.ReadLine());
            CODIGO = 1; //~~Helena
            base.CriarPersonagem();
            
            return this;
        }
        public override void AtualizarDados() //~~Everton c/ Helena na call
        {
            base.AtualizarDados();
        }
    }
}
