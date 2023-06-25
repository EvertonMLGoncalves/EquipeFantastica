using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoRPG_Equipe4.Enums;
namespace ProjetoRPG_Equipe4.Personagens
{
    internal class Inimigo : Personagem
    {
        /* public int Dificuldade { get; set; } */// equivalente ao nível do inimigo (nao existe mais ) //~~Everton c/ Helena na call
        /*public int Recompensa { get; set; }*/ // o quanto que desconta do XP dos bonzinhos (nao existe mais ) //~~Everton c/ Helena na call

        public EnumTipoInimigo Tipo { get; set; }
        public EnumHabilidadeInimigo Habilidade { get; set; }
        public Inimigo(int dificuldade, int recompensa, string nome, string sexo, EnumTipoInimigo tipo, EnumHabilidadeInimigo habilidade) : base(nome, sexo)
        {
            Nivel = dificuldade; //~~Everton c/ Helena na call
            XP = recompensa; //~~Everton c/ Helena na call
            Defesa = 1;
            PontosVida = 100;
            Sexo = sexo;
            Nome = nome;
            Forca = 70;
            XP = 0;
            Status = "Saudável";
            Tipo = tipo;
            Habilidade = habilidade;
        }
        public Inimigo() { }
        public override void ExibirInfo() //~~Everton c/ Helena na call
        { base.ExibirInfo();}
        public override Personagem CriarPersonagem() //~~Everton c/ Helena na call
        {base.CriarPersonagem(); CODIGO = 4;  return this;}
        public override void AtualizarDados() //~~Everton c/ Helena na call
        {base.AtualizarDados();}
    }
}
