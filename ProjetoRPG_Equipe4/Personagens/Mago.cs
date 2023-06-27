using System;

namespace ProjetoRPG_Equipe4.Personagens
{
    public class Mago : Personagem
    {
        public int PontosMagia { get; set; }
        // public const int CODIGO = 3; //~~Helena

        public Mago(int id, string nome, string sexo) : base(nome, sexo)
        {
            //Id = id;
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
        public Mago() { }
        public override void ExibirInfo() //~~Everton c/ Helena na call
        {

            base.ExibirInfo();
            Console.WriteLine($"# PontosMagia: {PontosMagia}\t\t#");
            Console.WriteLine("#################################");
        }
        public override Personagem CriarPersonagem() //~~Everton c/ Helena na call
        {

            PontosMagia = 5;
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
