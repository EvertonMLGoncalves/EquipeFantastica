using ProjetoRPG_Equipe4.Enums;
namespace ProjetoRPG_Equipe4.Personagens
{
    public class Inimigo : Personagem
    {
        /* public int Dificuldade { get; set; } */// equivalente ao nível do inimigo (nao existe mais ) //~~Everton c/ Helena na call
        /*public int Recompensa { get; set; }*/ // o quanto que desconta do XP dos bonzinhos (nao existe mais ) //~~Everton c/ Helena na call

        public EnumTipoInimigo Tipo { get; set; }
        public EnumHabilidadeInimigo Habilidade { get; set; }
        public Inimigo(string nome, string sexo, int dificuldade, int forca, int defesa, int recompensa, EnumTipoInimigo tipo, EnumHabilidadeInimigo habilidade) :
            base(nome, sexo, dificuldade, forca, defesa, recompensa)
        {
            Nivel = dificuldade; //~~Everton c/ Helena na call
            XP = recompensa; //~~Everton c/ Helena na call
            Defesa = defesa;
            Sexo = sexo;
            Nome = nome;
            Forca = forca;
            XP = 50;
            Status = "Saudável";
            Tipo = tipo;
            Habilidade = habilidade;
        }
        //construtor para testes
        public Inimigo(int dificuldade, int recompensa, string nome, string sexo) : base(nome, sexo)
        {
            Nivel = dificuldade; //~~Everton c/ Helena na call
            XP = recompensa; //~~Everton c/ Helena na call
            Defesa = 20;
            PontosVida = 1700;
            Sexo = sexo;
            Nome = nome;
            Forca = 70;
            XP = 50;
            Status = "Saudável";
        }
        public Inimigo() { }
        public override void ExibirInfo() //~~Everton c/ Helena na call
        { base.ExibirInfo(); }
        public override Personagem CriarPersonagem() //~~Everton c/ Helena na call
        { base.CriarPersonagem(); CODIGO = 4; return this; }
        public override void AtualizarDados() //~~Everton c/ Helena na call
        { base.AtualizarDados(); }
    }
}
