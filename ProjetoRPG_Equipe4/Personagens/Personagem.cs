using ProjetoRPG_Equipe4.Artefatos;
using System;
using System.Collections.Generic;

namespace ProjetoRPG_Equipe4.Personagens
{
    public class Personagem
    {
        public int Id { get; set; }
        public string Nome { get; set; } // editavel          
        public string Sexo { get; set; } // editavel
        public int PontosVida { get; set; } // nasce: 100 | Morre com: 0 
        public int Nivel { get; set; }
        public int Forca { get; set; } // inicia com 1
        public int Defesa { get; set; } //inicia com 1 
        public string Status { get; set; }
        public int XP { get; set; } // Experiencia, qnd vence o adverssario, ele ganha XP 
        public int CODIGO { get; set; } // adc para fzr o drop de armas //~~Helena 
        public int TurnosSemJogar { get; set; }
        public List<Habilidades> ListaDeHabilidades = new List<Habilidades>();
        public List<Arma> ListaArmas = new List<Arma>();   // adicionam-se as armas aqui //~~Helena

        public Personagem() { } //~~Helena

        public Personagem(string nome, string sexo)
        {
            Nome = nome;
            PontosVida = 100;
            Forca = 1;
            Defesa = 1;
            Sexo = sexo;
            XP = 0;
            Status = "Saudável";
        }
        // construtor para testes
        public Personagem(int id, string nome, string sexo, int pontosVida,
            int nivel, int forca, int defesa, string status, int xP,
            int codigo, int turnosSemJogar)
        {
            Id = id;
            Nome = nome;
            Sexo = sexo;
            PontosVida = pontosVida;
            Nivel = nivel;
            Forca = forca;
            Defesa = defesa;
            Status = status;
            XP = xP;
            CODIGO = codigo;
            TurnosSemJogar = turnosSemJogar;
        }

        Random random = new Random();
        public void Atacar(Personagem inimigo) //~~Helena tudo // ESSE OU O ATACAR PRECISA REFINAR!!
        {
            int danoArma = 0;
            int dano = 0;
            int danoHabilidade = 0;
            int i = 1;
            int index = 1;
            //Escolhada arma
            if (ListaArmas.Count > 0) // vendo se o personagem tem arma
            {
                if (CODIGO == 1 || CODIGO == 2 || CODIGO == 3)
                { //Checando se nn é um inimigo 
                    Console.Clear(); //Everton
                    foreach (Arma arma in ListaArmas)
                    {
                        Console.WriteLine($"{index} - {arma.Nome}");
                        index++;
                    }
                    index = 1;
                    Console.WriteLine("Qual arma você vai querer usar? (escolha com base no número!)");
                    i = int.Parse(Console.ReadLine());
                    Arma armaEscolhida = ListaArmas[i - 1];
                    danoArma = armaEscolhida.DanoArma;
                    armaEscolhida.DanoArma -= (int)(armaEscolhida.DanoArma * 0.2);
                    if (armaEscolhida.DanoArma <= 0) ListaArmas.RemoveAt(i - 1);
                }
                else
                { // se for inimigo
                    i = random.Next(0, ListaArmas.Count - 1);
                    Arma armaEscolhida = ListaArmas[i];
                    danoArma = armaEscolhida.DanoArma;

                    armaEscolhida.DanoArma -= (int)(armaEscolhida.DanoArma * 0.2);
                    if (armaEscolhida.DanoArma <= 0) ListaArmas.RemoveAt(i);
                }
            }
            else dano = Forca - inimigo.Defesa;
            danoArma += Forca;
            // Everton ~ Implementando o sistema de habilidades
            //Perguntando se o personagem vai querer usar uma habilidade e vendo se ele tem alguma:
            if (ListaDeHabilidades.Count > 0)
            {
                Console.WriteLine("Escolha uma habilidade: \n0 - para sair e atacar");
                foreach (Habilidades habilidadee in ListaDeHabilidades)
                {
                    Console.WriteLine($"{index} - {habilidadee.Nome}");
                    index++;
                }
                i = int.Parse(Console.ReadLine());
                if (i > 0)
                {
                    Habilidades habilidade = ListaDeHabilidades[i - 1];
                    Habilidades.UsarHabilidade(habilidade, inimigo);
                    danoHabilidade = habilidade.DanoHabilidade;
                }
            }

            int danoTotal = danoArma + dano + danoHabilidade;

            //Golpe crítico
            bool golpeCritico = false; //checar se houve golpe critico para a saida de dados
            if (GolpeCritico())
            {
                danoTotal = danoTotal + (int)(danoTotal * 0.5);
                golpeCritico = true;
            } //50% mais de dano ~~Dani Alves

            //Ataque
            if (danoTotal < 0) danoTotal = 0;
            inimigo.PontosVida -= danoTotal;
            Console.WriteLine($"{inimigo.Nome} está sendo atacado!");


            if (golpeCritico) Console.WriteLine($"{inimigo.Nome} recebeu um golpe crítico! Aumentando em 50% o seu dano :("); // ~~Dani Alves com alteração de Helena na frase e sua localização
            //Caso morte ocorra
            if (inimigo.PontosVida <= 0) Console.WriteLine($"Dano Recebido: {danoTotal} \n{inimigo.Nome} morreu");
            //Caso morte não ocorra
            else Console.WriteLine($"Dano Recebido: {danoTotal} \nVida de {inimigo.Nome}: {inimigo.PontosVida}");

        }

        //<>
        public virtual void ExibirInfo() //~~Everton c/ Helena na call
        {
            Console.WriteLine($"Id: {Id}");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Sexo: {Sexo}");
            Console.WriteLine($"PontosVida: {PontosVida}");
            Console.WriteLine($"Nivel: {Nivel}");
            Console.WriteLine($"Forca: {Forca}");
            Console.WriteLine($"Defesa: {Defesa}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"XP: {XP}");

        }
        public virtual Personagem CriarPersonagem() //~~Everton c/ Helena na call
        {
            Console.WriteLine("Digite o Id do Persongem:");
            Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Nome do Persongem:");
            Nome = Console.ReadLine();
            Console.WriteLine("Digite o Sexo do Persongem:");
            Sexo = Console.ReadLine();
            Console.WriteLine("Digite os de PontosVida do Persongem:");
            PontosVida = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Nivel do Persongem:");
            Nivel = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Forca do Persongem:");
            Forca = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a Defesa do Persongem:");
            Defesa = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o Status do Persongem:");
            Status = Console.ReadLine();
            Console.WriteLine("Digite o XP do Persongem:");
            XP = int.Parse(Console.ReadLine());
            ListaArmas = new List<Arma>(); ListaDeHabilidades = new List<Habilidades>();
            Console.Clear(); //Everton
            return this;
        }



        public virtual void AtualizarDados() //~~Everton c/ Helena na call
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Digite \n1-Nome \n2-Sexo \n3-para sair");
                int op = int.Parse(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.WriteLine("Digite o novo nome:");
                        string nome = Console.ReadLine();
                        Console.WriteLine($"Tem certeza que deseja alterar para {nome}\n1-sim \n2-não");
                        int opp = int.Parse(Console.ReadLine());
                        if (opp == 1)
                        {
                            Nome = nome;
                            break;
                        }
                        else break;
                    case 2:
                        Console.WriteLine("Digite o novo sexo:");
                        string sexo = Console.ReadLine();
                        Console.WriteLine($"Tem certeza que deseja alterar para {sexo}\n1-sim \n2-não");
                        opp = int.Parse(Console.ReadLine());
                        if (opp == 1)
                        {
                            Sexo = sexo;
                            break;
                        }
                        else break;
                    case 3:
                        flag = false;
                        break;
                }
            }
        }
        public void VerificarStatus() //~Everton
        {
            if (Status == "Atordoado")
            {
                Console.WriteLine($"{Nome} está atordoado e ficará {TurnosSemJogar} turno(s) sem jogar");
                Defesa -= (int)(Defesa * 0.3);
                TurnosSemJogar--;
            }
            else if (Status == "Queimado")
            {
                Console.WriteLine($"{Nome} está queimando e ficará {TurnosSemJogar} turno(s) sem jogar");
                PontosVida -= (int)(PontosVida * 0.15 * TurnosSemJogar);
                TurnosSemJogar--;
            }
            else if (Status == "Adormecido")
            {
                Console.WriteLine($"{Nome} está adormecido e ficará {TurnosSemJogar} turno(s) sem jogar");
                TurnosSemJogar--;
            }
            else if (Status == "Envenenado")
            {
                Console.WriteLine($"{Nome}  está envenenado e ficará  {TurnosSemJogar} turno(s) sem jogar");
                PontosVida -= (int)(PontosVida * 0.10);
                TurnosSemJogar--;
            }
        }

        private bool GolpeCritico() // ~~Dani Alves c/ implementação de Helena
        {
            int chanceCritico = 10; //10%

            Random random = new Random();
            return random.Next(1, 101) < chanceCritico; // incrementação da lógica (mudou-se 100 para 1,101)
        }


    }
}
