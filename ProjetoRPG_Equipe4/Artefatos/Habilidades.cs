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
            Console.Write("Quantidade de vezes que pode ser utilizado: ");
            Utilizado = int.Parse(Console.ReadLine());
            Console.WriteLine("#########################");
            Console.WriteLine("");
            return this;
        }

        public static void AdicionarHabilidade(Personagem personagem, Habilidades habilidade) // MVP de associar personagem com habilidade
        {
            personagem.ListaDeHabilidades.Add(habilidade);
            Console.WriteLine($"Habilidade {habilidade.Nome} adicionada com sucesso á {personagem.Nome}");
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

        public void Envenenar(Personagem personagem) // implementado por Claudia
        {
            personagem.Status = "Envenenado";
            int turnosRemanescentes = 5;

            while(turnosRemanescentes > 0) 
            {
                personagem.PontosVida -= 1;
                turnosRemanescentes--;  
            }
        }
      
        public void Atordoar(Personagem personagem) // Claudia
        {
            personagem.Status = "Atordoado";
            int turnosRemanescentes = 3;

            while (turnosRemanescentes > 0)
            {
                personagem.Defesa -= (int)(personagem.Defesa * 0.3);
                turnosRemanescentes--;
            }
        }

        public void Queimar(Personagem personagem) // Claudia
        {
            personagem.Status = "Queimado";
            int turnosRemanescentes = 3;
            double danoFogo = 0.05;

            while(turnosRemanescentes > 0)
            {
                personagem.PontosVida -= (int)(personagem.PontosVida * danoFogo);
                turnosRemanescentes--;
                danoFogo += 0.05; // a porcentagem que causa o efeito progressivo de dano do fogo
            }
        }
    }
}
