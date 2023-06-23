using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Personagens
{
    internal class Mago : Personagem
    {
        public int PontosMagia { get; set; }
        public const int CODIGO = 3;

        public Mago(int id, string nome, string sexo) : base(nome, sexo)
        {
            Id = id;
            Nivel = 1;
            PontosMagia = 1;
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
            Console.WriteLine($"PontosMagia: {PontosMagia}");
            base.ExibirInfo();
        }
        public override Personagem CriarPersonagem()
        {
            Console.WriteLine("Digite a PontosMagia do Personagem:");
            PontosMagia = int.Parse(Console.ReadLine());
            base.CriarPersonagem();
            return this;
        }
    }
}
