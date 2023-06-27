using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Personagens
{
    public class Arqueiro : Personagem
    {
        public int Destreza { get; set; }
        //public const int CODIGO = 2; //~~Helena
        public Arqueiro(int id, string nome, string sexo) : base(nome, sexo)
        {
            //Id = id;
            Nivel = 1;
            Destreza = 1;
            Defesa = 1;
            PontosVida = 100;
            Sexo = sexo;
            Nome = nome;
            Forca = 1;
            XP = 0;
            Status = "Saudável"; 
          
        }
        public Arqueiro() { }
        public override void ExibirInfo() //~~Everton c/ Helena na call
        {
            
            base.ExibirInfo();
            Console.WriteLine($"# Destreza: {Destreza}\t\t\t#");
            Console.WriteLine("#################################");
        }
        public override Personagem CriarPersonagem() //~~Everton c/ Helena na call
        {
            Destreza = 5;
            base.CriarPersonagem();
            CODIGO = 2; //~~Helena
            return this;
        }
        public override void AtualizarDados() //~~Everton c/ Helena na call
        {
            base.AtualizarDados();
        }
    }
}
