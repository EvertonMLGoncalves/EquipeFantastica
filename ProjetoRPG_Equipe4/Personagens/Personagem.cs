using ProjetoRPG_Equipe4.Artefatos;
using System;
using System.Collections.Generic;
using System.Threading;
namespace ProjetoRPG_Equipe4.Personagens
{
    public class Personagem
    {
        //public int Id { get; set; }
        public string Nome { get; set; } // editavel          
        public string Sexo { get; set; } // editavel
        public int PontosVida { get; set; } // nasce: 100 | Morre com: 0 
        public int Nivel { get; set; }
        public int Forca { get; set; } // inicia com 1
        public int Defesa { get; set; } //inicia com 1 
        public string Status { get; set; }
        public int XP { get; set; } // Experiencia, qnd vence o adverssario, ele ganha XP 
        public int CODIGO { get; set; } // adc para fzr o drop de armas //~~Helena 
        public int TurnosAfetado { get; set; } // O antigo TurnosSemJogar 
        public int DanoPorTurno { get; set; } // dano correspondente à habilidade utilizada, 
        /*  usado para controlar o dano e nao impedir o inimigo de jogar(exceto na habilidade de Adormecer)*/



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
        public Personagem(string nome, string sexo,
            int nivel, int forca, int defesa, int xP)
        {
            // Id = id;
            Nome = nome;
            Sexo = sexo;
            PontosVida = 100;
            Nivel = nivel;
            Forca = forca;
            Defesa = defesa;
            Status = "Saudável";
            XP = xP;
            CODIGO = 4;
        }

        Random random = new Random();
        public void Atacar(Personagem inimigo) //~~Helena 1 implementação
        {
            int danoArma = 0;
            int dano = 0;
            int danoHabilidade = 0;
            if (ListaArmas.Count > 0) // vendo se o personagem tem arma
            {
                if (CODIGO == 1 || CODIGO == 2 || CODIGO == 3)
                {
                    int i = Arma.EscolherArma(this);
                    Arma armaEscolhida = ListaArmas[i - 1];
                    danoArma = armaEscolhida.DanoArma;
                    armaEscolhida.DanoArma -= (int)(armaEscolhida.DanoArma * 0.2);
                    if (armaEscolhida.DanoArma <= 0) ListaArmas.RemoveAt(i - 1);
                }
                else
                { // se for inimigo 
                    int i = 0;
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

            Habilidades.EscolherHabilidade(this, inimigo, danoHabilidade);

            int danoTotal = danoArma + dano + danoHabilidade;

            if (danoTotal < 0) danoTotal = 0;
            inimigo.PontosVida -= danoTotal;
            //Console.WriteLine($"# {inimigo.Nome} está sendo atacado! #");  //!!/!!//!!
            /*Thread.Sleep(2000);*/
            /*Console.Clear();*/
            if (inimigo.PontosVida >= 0)
            {
                Console.WriteLine($"#############################################");
                Console.WriteLine($"- {inimigo.Nome} - HP: {inimigo.PontosVida}  \n- Dano Sofrido: -{danoTotal} ");
                Console.WriteLine($"#############################################");
                //Golpe crítico 
                if (GolpeCritico())
                {
                    bool flag = true;
                    while (flag)
                    {
                        Console.WriteLine($"{inimigo.Nome} recebeu um golpe crítico de {(int)(danoTotal * 0.5)}");
                        danoTotal = danoTotal + (int)(danoTotal * 0.5);
                        Console.WriteLine("* Digite 'X' para prosseguir");
                        char val = Char.ToUpper(Char.Parse(Console.ReadLine()));
                        if (val == 'X') flag = false;

                    }
                    Console.Clear();
                }  //50% mais de dano ~~Dani Alves 
                else
                {
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else Console.WriteLine($"{inimigo.Nome} morreu \nDano Sofrido: {danoTotal}");
        }

        //<>
        public virtual void ExibirInfo() //~~Everton c/ Helena na call
        {
            Console.WriteLine("### INFORMAÇÕES DO PERSONAGEM ###");
            //Console.WriteLine($"# Id: {Id}\t\t\t\t#");
            Console.WriteLine($"# Nome: {Nome}\t\t\t");
            Console.WriteLine($"# Sexo: {Sexo}\t\t\t");
            Console.WriteLine($"# Pontos de Vida: {PontosVida} \t\t");
            Console.WriteLine($"# Forca: {Forca} \t\t\t");
            Console.WriteLine($"# Defesa: {Defesa} \t\t\t");
            Console.WriteLine($"# Status: {Status} \t\t");
            Console.WriteLine($"# XP: {XP} \t\t\t");

        }
        public virtual Personagem CriarPersonagem() //~~Everton c/ Helena na call
        {
            Console.WriteLine("### CRIANDO O PERSONAGEM ###");
            //Id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            Nome = Console.ReadLine();
            Console.Write("Sexo: ");
            Sexo = Console.ReadLine();
            Console.WriteLine("###############################");
            PontosVida = 100;
            Nivel = 1;
            Forca = 5;
            Defesa = 5;
            Status = "Saudável";
            XP = 0;
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
        public void VerificarDano() //~Everton
        {
            if (Status == "Atordoado")
            {
                Console.WriteLine($"{Nome} está atordoado");
                Defesa -= (int)(Defesa * 0.3);
                TurnosAfetado--;
                if (TurnosAfetado == 0) Defesa += (int)(Defesa * 0.3);
            }
            else if (Status == "Queimado")
            {
                Console.WriteLine($"{Nome} está queimando: {TurnosAfetado} turno(s) restante(s)");
                PontosVida -= DanoPorTurno * TurnosAfetado;
                TurnosAfetado--;
                if (TurnosAfetado == 0) DanoPorTurno = 0;
            }
            else if (Status == "Adormecido")
            {
                Console.WriteLine($"{Nome} está adormecido: {TurnosAfetado} turno(s) restante(s)");
                TurnosAfetado--;
            }
            else if (Status == "Envenenado")
            {
                Console.WriteLine($"{Nome}  está envenenado: {TurnosAfetado} turno(s) restante(s)");
                PontosVida -= (int)(PontosVida * 0.1);
                TurnosAfetado--;
                if (TurnosAfetado == 0) DanoPorTurno = 0;
            }
        }
        public bool VerificarStatus()
        {
            if (Status == "Atordoado" || Status == "Queimado" || Status == "Envenenado")
            {
                return true;
            }
            else if (Status == "Adormecido")
            {
                return false;
            }
            else return true;

        }

        public bool GolpeCritico() // ~~Dani Alves c/ implementação de Helena
        {
            int chanceCritico = 10; //10%

            Random random = new Random();
            return random.Next(1, 101) < chanceCritico; // incrementação da lógica (mudou-se 100 para 1,101)
        }

        public void ReceberXP(int experiencia) // ~~Dani Alves
        {
            XP += experiencia;

            int xpNecessario = CalcularXpNecessarioNivel(Nivel);
            if (XP >= xpNecessario)
            {
                Nivel++;
                Forca += 10;
                Defesa += 5;
                PontosVida += 10;
            }
        }

        private int CalcularXpNecessarioNivel(int nivel) // ~~Dani Alves
        {
            return 100 * nivel; //100 de xp para o prox nivel
        }
    }
}
