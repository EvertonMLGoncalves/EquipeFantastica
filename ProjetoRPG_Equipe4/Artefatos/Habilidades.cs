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
            Console.Clear();
        }

        public void ExibirInfo()
        {
            Console.WriteLine("### INFORMAÇÕES DESSA HABILIDADE ####");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Dano da habilidade: {DanoHabilidade}");
            Console.WriteLine("############################");

        }



        /* public static int Envenenar(Personagem personagem) // implementado por Claudia / Editado por Everton
         {
             personagem.Status = "Envenenado";
             personagem.TurnosAfetado = 5;
             return personagem.PontosVida -= (int)(personagem.PontosVida * 0.10); //perde 10% da vida a cada turno 

         }*/
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

        /*public static int Atordoar(Personagem personagem) // Claudia + Everton
        {
            personagem.Status = "Atordoado";
            int defesaInicial = personagem.Defesa;
            personagem.TurnosAfetado = 3; // Everton
            return personagem.Defesa -= (int)(personagem.Defesa * 0.3);

        }*/


        /*public static int Queimar(Personagem personagem) // Claudia + Everton
        {
            personagem.Status = "Queimado";
            personagem.TurnosAfetado = 3;
            return personagem.PontosVida -= (int)(personagem.PontosVida * 0.10*3);

        }*/
        // ARRUMAR DPS
        public static void Queimar(Personagem inimigo)
        {
            inimigo.Status = "Queimado";
            inimigo.TurnosAfetado = 3;
            inimigo.DanoPorTurno = (int)(inimigo.PontosVida * 0.15);

        }

        /* public static void Adormecer(Personagem personagem) // Claudia + Everton
         {
             personagem.Status = "Adormecido";
             personagem.TurnosAfetado = 1;
         }*/

        public static void Adormecer(Personagem inimigo)
        {
            inimigo.Status = "Adormecido";
            inimigo.TurnosAfetado = 1;
            inimigo.DanoPorTurno = 0; // Sem dano por turno
        }

        /* public static void UsarHabilidade(Habilidades habilidade, Personagem inimigo) //~Everton
         {
             if (habilidade.Tipo == TipoHabilidade.Envenenante)
             {
                 Habilidades.Envenenar(inimigo);
                 Console.WriteLine($"{inimigo.Nome} está envenenado por {inimigo.TurnosAfetado} turnos");
             }
             else if (habilidade.Tipo == TipoHabilidade.Atordoante)
             {
                 Habilidades.Atordoar(inimigo);
                 Console.WriteLine($"{inimigo.Nome} está atordoado por {inimigo.TurnosAfetado} turnos");
             }
             else if (habilidade.Tipo == TipoHabilidade.Incendiante)
             {
                 Habilidades.Queimar(inimigo);
                 Console.WriteLine($"{inimigo.Nome} está queimando por {inimigo.TurnosAfetado} turnos");
             }
             else
             {
                 Habilidades.Adormecer(inimigo);
                 Console.WriteLine($"{inimigo.Nome} está sedado por {inimigo.TurnosAfetado} turnos");
             }

         }*/

        public static void UsarHabilidade(Habilidades habilidade, Personagem inimigo)
        {
            if (habilidade.Tipo == TipoHabilidade.Envenenante)
            {
                Habilidades.Envenenar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está envenenado por {inimigo.TurnosAfetado} turnos");
            }
            else if (habilidade.Tipo == TipoHabilidade.Atordoante)
            {
                Habilidades.Atordoar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está atordoado por {inimigo.TurnosAfetado} turno");
            }
            else if (habilidade.Tipo == TipoHabilidade.Incendiante)
            {
                Habilidades.Queimar(inimigo);
                Console.WriteLine($"{inimigo.Nome} está queimando por {inimigo.TurnosAfetado} turnos");
            }
            else
            {
                Habilidades.Adormecer(inimigo);
                Console.WriteLine($"{inimigo.Nome} está sedado por {inimigo.TurnosAfetado} turno");
            }
        }

    }
}
