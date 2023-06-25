using ProjetoRPG_Equipe4.Enums;
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
        public string Nome { get; set; }
        public TipoHabilidade Tipo { get; set; }
        public int Nivel { get; set; }

        public int Utilizado { get; set; } // Quantidade de vezes que se pode usar X habilidade
        public int DanoHabilidade { get; set; }

        public Habilidades() { }
        public Habilidades(string nome, TipoHabilidade tipo, int utilizado, int danoHabilidade)
        {
            Nome = nome;
            Tipo = tipo; 
            Utilizado = utilizado;
            DanoHabilidade = danoHabilidade;
        }

        public Habilidades CriarHabilidade()
        {
            Console.WriteLine("### CRIAR HABILIDADE ###");
            Console.Write("Nome: ");
            Nome = Console.ReadLine();
            Console.Write("Tipo: \n1- Envenenante \n2-Atordoante \n3-Incendiante \n4-Sedante");
            int op = int.Parse(Console.ReadLine());
            if (op == 1) Tipo = TipoHabilidade.Envenenante;
            else if (op == 2) Tipo = TipoHabilidade.Atordoante;
            else if (op == 3) Tipo = TipoHabilidade.Incendiante;
            else if (op == 4) Tipo = TipoHabilidade.Sedante;
            Console.Write("Dano da habilidade: ");
            DanoHabilidade = int.Parse(Console.ReadLine());
            Console.Write("Quantidade de vezes que pode ser utilizado: ");
            Utilizado = int.Parse(Console.ReadLine());
            Console.Clear();
            return this;
        }

        public static void AdicionarHabilidade(Personagem personagem, Habilidades habilidade) // MVP de associar personagem com habilidade
        {
            personagem.ListaDeHabilidades.Add(habilidade);
            Console.WriteLine($"Habilidade {habilidade.Nome} adicionada com sucesso á {personagem.Nome}"); 
            Console.ReadLine();
            Console.Clear();
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

        /*p*//*ublic static void Envenenar(Personagem personagem) // implementado por Claudia
        {
            personagem.Status = "Envenenado";
            personagem.TurnosSemJogar = 5;

            while (personagem.TurnosSemJogar > 0)  // Everton: Arrumando o método e incrementando porcentagem
            {
                personagem.PontosVida -= (int)(personagem.PontosVida * 0.10); //perde 10% da vida a cada turno 
                personagem.TurnosSemJogar--;
            }
        }*/

        public static int Envenenar(Personagem personagem) // implementado por Claudia / Editado por Everton
        {
            personagem.Status = "Envenenado";
            personagem.TurnosSemJogar = 5;
            return personagem.PontosVida -= (int)(personagem.PontosVida * 0.10); //perde 10% da vida a cada turno 

        }

        /*public static void Atordoar(Personagem personagem) // Claudia
        {
            personagem.Status = "Atordoado";
            int defesaInicial = personagem.Defesa;
            personagem.TurnosSemJogar = 3; // Everton

            while (personagem.TurnosSemJogar > 0) 
            while (personagem.TurnosSemJogar > 0) 
            {
                personagem.Defesa -= (int)(personagem.Defesa * 0.3); 
                personagem.TurnosSemJogar--; //Everton
            } 
            personagem.Defesa = defesaInicial; //Everton: Dps de passar o atordoamento, ele recupera a defesa inicial

        }*/
        public static int Atordoar(Personagem personagem) // Claudia + Everton
        {
            personagem.Status = "Atordoado";
            int defesaInicial = personagem.Defesa;
            personagem.TurnosSemJogar = 3; // Everton
            return personagem.Defesa -= (int)(personagem.Defesa * 0.3);

        }

        /*public static void Queimar(Personagem personagem) // Claudia
        {
            personagem.Status = "Queimado";
            personagem.TurnosSemJogar = 3;
            double danoFogo = 0.05;

            while (personagem.TurnosSemJogar > 0)
            {
                personagem.PontosVida -= (int)(personagem.PontosVida * danoFogo);
                personagem.TurnosSemJogar--;
                danoFogo += 0.05; // a porcentagem que causa o efeito progressivo de dano do fogo
            }
        }*/
        public static int Queimar(Personagem personagem) // Claudia + Everton
        {
            personagem.Status = "Queimado";
            personagem.TurnosSemJogar = 3;
            return personagem.PontosVida -= (int)(personagem.PontosVida * 0.10*3);

        }


        /*public static void Adormecer(Personagem personagem) // Claudia 
        {
            personagem.Status = "Adormecido";
            personagem.TurnosSemJogar = 1;

            while (personagem.TurnosSemJogar > 0)
            {
                // O jogador nao faz nada 
                personagem.TurnosSemJogar--;
            }
        }*/
        public static void Adormecer(Personagem personagem) // Claudia + Everton
        {
            personagem.Status = "Adormecido";
            personagem.TurnosSemJogar = 1;
        }

        public static void UsarHabilidade(Habilidades habilidade, Personagem inimigo) //~Everton
        {
            if (habilidade.Tipo == TipoHabilidade.Envenenante)
            {
                Habilidades.Envenenar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está envenenado por {inimigo.TurnosSemJogar} turnos");
            }
            else if (habilidade.Tipo == TipoHabilidade.Atordoante)
            {
                Habilidades.Atordoar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está atordoado por {inimigo.TurnosSemJogar} turnos");
            }
            else if (habilidade.Tipo == TipoHabilidade.Incendiante)
            {
                Habilidades.Queimar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está queimando por {inimigo.TurnosSemJogar} turnos");
            }
            else
            {
                Habilidades.Adormecer(inimigo);
                Console.WriteLine($"{inimigo.Nome} está sedado por {inimigo.TurnosSemJogar} turnos");
            }

        }

    }
}
