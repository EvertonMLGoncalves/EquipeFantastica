using ProjetoRPG_Equipe4.Personagens;
using System;

namespace ProjetoRPG_Equipe4.Artefatos
{
    public class Arma
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public int DanoArma { get; set; }

        public int PersonagemApropriado { get; set; }
        public string Categoria { get; set; }

        public int Raridade { get; set; }
        public string HabilidadeArma { get; set; }

        public Arma() { }
        public Arma(int id, string nome, int danoBase)
        {
            Id = id;
            Nome = nome;
            DanoArma = danoBase;

        }
        //construtor completo para testes
        public Arma(int id, string nome, int danoArma, int personagemApropriado, string categoria, int raridade, string habilidadeArma)
        {
            Id = id;
            Nome = nome;
            DanoArma = danoArma;
            PersonagemApropriado = personagemApropriado;
            Categoria = categoria;
            Raridade = raridade;
            HabilidadeArma = habilidadeArma;
        }

        public static void AdicionarArma(Personagem personagem, Arma arma) // ~Helena // Everton: Mudei o nome para "AdicionarArmas"
        {
            if (personagem.CODIGO != arma.PersonagemApropriado) arma.DanoArma -= (int)(arma.DanoArma * 0.2); 
            personagem.ListaArmas.Add(arma);
            Console.WriteLine($"{arma.Nome} foi adicionada à sacola de armas de {personagem.Nome} com sucesso!"); 
            Console.ReadKey(); //Everton
            Console.Clear(); //Everton
        }


        public Arma CriarArma() //~~Helena
        {
            Console.WriteLine("### CRIANDO ARMA ###");
            Console.Write($"ID: ");
            Id = int.Parse(Console.ReadLine());
            Console.Write($"Nome: ");
            Nome = Console.ReadLine();
            Console.Write($"Categoria: ");
            Categoria = Console.ReadLine();
            Console.Write("Personagem apropiado (1 - Guerreiro | 2 - Arqueiro | 3 - Mago): ");
            PersonagemApropriado = int.Parse(Console.ReadLine());
            Console.Write("Dano da arma: ");
            DanoArma = int.Parse(Console.ReadLine());
            Console.Write("Raridade (1-10): ");
            Raridade = int.Parse(Console.ReadLine());
            Console.Write("Habilidade: ");
            HabilidadeArma = Console.ReadLine();
            Console.WriteLine("###########################");
            Console.Clear(); //Everton:Colocando o console.clear()
            return this;
        }
        string apropriado = null;//~~Helena
        public void ExibirInfo() //~~Helena
        {
            Console.WriteLine("### EXIBIR INFORMAÇÕES DA ARMA ###");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Categoria: {Categoria}");

            if (PersonagemApropriado == 1) apropriado = "Guerreiro";
            else if (PersonagemApropriado == 2) apropriado = "Arqueiro";
            else apropriado = "Mago";

            Console.WriteLine($"Personagem apropriado: {apropriado}");
            Console.WriteLine($"Dano da arma: {DanoArma}");
            Console.WriteLine($"Raridade: {Raridade}");
            Console.WriteLine("###########################");
            Console.WriteLine();
        }
    }
}
