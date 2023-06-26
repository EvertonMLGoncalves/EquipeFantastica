using ProjetoRPG_Equipe4.Enums;
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
       
        public static void VerificarHabilidadeItem(Arma arma, Personagem personagem)
        {
            Random random = new Random();
            if (arma.Raridade >= 1 && arma.Raridade <= 2)
            {
                int index = random.Next(0, 2);
                if (index == 0)
                {
                    Console.WriteLine("Esta arma não tem habilidade adicional");
                }
                else if (index == 1)
                {
                    Console.WriteLine($"Você ganhou uma habilidade do tipo {TipoHabilidade.Atordoante}");
                    Habilidades habilidade = new Habilidades("Golpe Certeiro", TipoHabilidade.Atordoante, 2, 0);
                    Habilidades.AdicionarHabilidade(personagem, habilidade);
                }
            }
            if (arma.Raridade > 4 && arma.Raridade <= 10)
            {
                int index = random.Next(2, 5);
                if (index == 0)
                {
                    Console.WriteLine("Esta arma não tem habilidade adicional");
                }
                else if (index == 1)
                {
                    Console.WriteLine($"Você ganhou uma habilidade do tipo {TipoHabilidade.Envenenante}");
                    Habilidades habilidade = new Habilidades("Golpe de Mestre", TipoHabilidade.Envenenante, 1, 50);
                    Habilidades.AdicionarHabilidade(personagem, habilidade);
                }
            }


        }
    }
}
