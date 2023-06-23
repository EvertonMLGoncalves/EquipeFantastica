using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Personagens
{
    internal class Arqueiro : Personagem
    {
        public int Destreza { get; set; }
        public const int CODIGO = 2;
        public Arqueiro(int id, string nome, string sexo) : base(nome, sexo)
        {
            Id = id;
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
        public override void ExibirInfo()
        {
            Console.WriteLine($"Destreza: {Destreza}");
            base.ExibirInfo();
        }
        public override Personagem CriarPersonagem()
        {
            Console.WriteLine("Digite a Destreza do Personagem:");
            Destreza = int.Parse(Console.ReadLine());
            base.CriarPersonagem();
            return this;
        }
    }
}
