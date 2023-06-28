using ProjetoRPG_Equipe4.Enums;
using ProjetoRPG_Equipe4.Personagens;
using System;
using System.Threading;

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
            Console.WriteLine($"# Habilidade {habilidade.Nome} adicionada com sucesso á {personagem.Nome} #");
        }

        public void ExibirInfo()
        {
            Console.WriteLine("### INFORMAÇÕES DESSA HABILIDADE ####");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Dano da habilidade: {DanoHabilidade}");
            Console.WriteLine("############################");

        }


        public static void Envenenar(Personagem inimigo)
        {
            inimigo.Status = "Envenenado";
            inimigo.TurnosAfetado = 5;
            inimigo.DanoPorTurno = (int)(inimigo.PontosVida * 0.1); // 10% da vida do personagem por turno
        }
        public static void Atordoar(Personagem inimigo)
        {
            inimigo.Status = "Atordoado";
            inimigo.TurnosAfetado = 1;
            inimigo.Defesa -= (int)(inimigo.Defesa * 0.3); // Reduz 30% da defesa
        }

        public static void Queimar(Personagem inimigo)
        {
            inimigo.Status = "Queimado";
            inimigo.TurnosAfetado = 3;
            inimigo.DanoPorTurno = (int)(inimigo.PontosVida * 0.15);

        }

        public static void Adormecer(Personagem inimigo)
        {
            inimigo.Status = "Adormecido";
            inimigo.TurnosAfetado = 1;
            inimigo.DanoPorTurno = 0; // Sem dano por turno
        }

        public static void UsarHabilidade(Habilidades habilidade, Personagem inimigo)
        {
            if (habilidade.Tipo == TipoHabilidade.Envenenante)
            {
                Envenenar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está envenenado por {inimigo.TurnosAfetado} turnos");
            }
            else if (habilidade.Tipo == TipoHabilidade.Atordoante)
            {
                Atordoar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está atordoado por {inimigo.TurnosAfetado} turno");
            }
            else if (habilidade.Tipo == TipoHabilidade.Incendiante)
            {
                Queimar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está queimando por {inimigo.TurnosAfetado} turnos");
            }
            else
            {
                Adormecer(inimigo);
                Console.WriteLine($"{inimigo.Nome} está sedado por {inimigo.TurnosAfetado} turno");
            }
        }
        public static void EscolherHabilidade(Personagem personagem, Personagem inimigo, int danohabilidade)
        {
            if (personagem.ListaDeHabilidades.Count > 0 && personagem.ListaDeHabilidades.Exists(h => h.Utilizado != 0))
            {
                int index = 1;
                Console.WriteLine("### HABILIDADES ###");
                Console.WriteLine("# 0 - Sair e Atacar");
                foreach (Habilidades habilidadee in personagem.ListaDeHabilidades)
                {
                    /*Console.WriteLine($"# {index} - {habilidadee.Nome}");*/
                    Console.WriteLine($"# {index} - {habilidadee.Nome} - {habilidadee.Utilizado} vez(es) restante(s)");
                    index++;
                }
                Console.WriteLine("#####################");
                Console.Write("# ");
                int i = int.Parse(Console.ReadLine());
                Thread.Sleep(1000);
                Console.Clear();
                if (i > 0)
                {
                    Habilidades habilidade = personagem.ListaDeHabilidades[i - 1];
                    Habilidades.UsarHabilidade(habilidade, inimigo);
                    danohabilidade = habilidade.DanoHabilidade;
                    personagem.ListaDeHabilidades[i - 1].Utilizado--;
                }

            }

        }
    }
}
