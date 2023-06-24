using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Artefatos
{
    public class Habilidades
    {
        public string Nome {get;set;}
        public string Tipo { get;set;}
        //public enum Nivel { get;set; }

        public int Utilizado { get;set;} // Quantidade de vezes que se pode usar X habilidade
        public int DanoHabilidade { get;set;}

        public Habilidades() { }
        public Habilidades(string nome, string tipo, int danoHabilidade)
        {
            Nome = nome;
            Tipo = tipo;
            DanoHabilidade = danoHabilidade;
        }

        public Habilidades CriarHabilidade()
        {
            Console.WriteLine("### CRIAR HABILIDADE ###");
            Console.Write("Nome: ");
            Nome = Console.ReadLine();
            Console.Write("Tipo: ");
            Tipo = Console.ReadLine();
            Console.Write("Dano da habilidade: ");
            DanoHabilidade = int.Parse(Console.ReadLine());
            Console.Write("Quantidade de vezes que pode ser uitilizado: ");
            Utilizado = int.Parse(Console.ReadLine());
            Console.WriteLine("############################");
            Console.WriteLine("");
            return this;
        }

        public static void AdicionarHabilidade(Personagem perosonagem, Habilidades habilidade) // MVP de associar personagem com habilidade
        {
            perosonagem.ListaDeHabilidades.Add(habilidade);
            Console.WriteLine($"Habilidade {habilidade.Nome} adicionada com sucesso á {perosonagem.Nome}");
        }

        public void ExibirInfo()
        {
            Console.WriteLine("### INFORMAÇÕES DESSA HABILIDADE ####");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Dano da habilidade: {DanoHabilidade}");
            Console.WriteLine("############################");
            Console.WriteLine("");
        }

        
        
        public void Atrapalhar(Personagem personagem, Arma arma) // MVP de como +/- (mais pra menos) vai ficar esse rolezinho ~~Helena
        {
            switch (arma.HabilidadeArma)
            {
                case "Envenenar":
                    personagem.Status = "Envenenado";
                    personagem.Forca -= (int)(personagem.Forca * 0.3); break;
                case "Artodoar":
                    personagem.Status = "Artodoado";
                    personagem.Defesa -= (int)(personagem.Defesa * 0.3); break;
                case "Queimar":
                    personagem.Status = "Queimado";
                    personagem.PontosVida -= 5; break;
            }

        }


    }
}
