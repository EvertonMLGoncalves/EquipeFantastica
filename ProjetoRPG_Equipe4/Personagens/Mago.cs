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
        // public const int CODIGO = 3; //~~Helena

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
        public override void ExibirInfo() //~~Everton c/ Helena na call
        {
            Console.WriteLine($"PontosMagia: {PontosMagia}");
            base.ExibirInfo();
        }
        public override Personagem CriarPersonagem() //~~Everton c/ Helena na call
        {
            Console.WriteLine("Digite a PontosMagia do Personagem:");
            PontosMagia = int.Parse(Console.ReadLine());
            CODIGO = 3; //~~Helena
            base.CriarPersonagem();
            return this;
        }
        public override void AtualizarDados() //~~Everton c/ Helena na call
        {
            base.AtualizarDados();
        }
    }
}
