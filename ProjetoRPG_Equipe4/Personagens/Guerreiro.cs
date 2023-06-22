using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Personagens
{
    internal class Guerreiro : Personagem
    {
        public int Id { get; set; }
        public int Nivel { get; set; }
        public int Furia { get; set; }

        public int Codigo { get; set; }

        public Guerreiro(int id, string nome, string sexo) : base(nome, sexo)
        {
            Id = id;
            Nivel = 1;
            Furia = 1;
            Defesa = 1;
            PontosVida = 100;
            Sexo = sexo;
            Nome = nome;
            Forca = 50;
            XP = 0;
            Status = "Saudável";
            Codigo = 1;
        }
        public override void ExibirInfo()
        { 
            base.ExibirInfo();
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Furia: {Furia}\n----------------------"); 
   
        }
    }
}
