using ProjetoRPG_Equipe4.Artefatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Habilidades> ListaDeHabilidades { get; set; }
        public List<Arma> ListaArmas { get; set; } // adc para fzr o drop de armas //~~Helena

        public Personagem() {  } //~~Helena

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

        
        Random random = new Random();
        public void Atacar(Personagem inimigo) //~~Helena tudo // ESSE OU O ATACAR PRECISA REFINAR!!
        {
            int danoArma = 0;
            int danoHabilidade = 0;
            int dano = 0;
            int i = 1;
            int index = 1;
            //Escolhada arma
            if (ListaArmas.Count >0) // vendo se o personagem tem arma
            {
                if (inimigo.CODIGO == 1 || inimigo.CODIGO == 2 || inimigo.CODIGO ==3) { //Checando se nn é um inimigo
                    foreach (Arma arma in ListaArmas) Console.WriteLine($"{index} - {arma.Nome}");
                    Console.WriteLine("Qual arma você vai querer usar? (escolha com base no número!)");
                    i = int.Parse(Console.ReadLine());
                    Arma armaEscolhida = ListaArmas[i - 1];
                    danoArma = armaEscolhida.DanoArma;

                    armaEscolhida.DanoArma -= (int)(armaEscolhida.DanoArma * 0.2);
                    if (armaEscolhida.DanoArma <= 0) ListaArmas.RemoveAt(i - 1); }
                else { 
                    i = random.Next(0, ListaArmas.Count-1);
                    Arma armaEscolhida = ListaArmas[i ];
                    danoArma = armaEscolhida.DanoArma;

                    armaEscolhida.DanoArma -= (int)(armaEscolhida.DanoArma * 0.2);
                    if (armaEscolhida.DanoArma <= 0) ListaArmas.RemoveAt(i);}
            }
            else if (!(ListaDeHabilidades.Count > 0)) dano = Forca - inimigo.Defesa;

            
            
            int danoTotal = danoArma + danoHabilidade +dano;

            //Ataque
            if (danoTotal < 0) danoTotal = 0;
            inimigo.PontosVida -= danoTotal;
            Console.WriteLine($"{inimigo.Nome} está sendo atacado!");

            //Caso morte ocorra
            if (inimigo.PontosVida <= 0) Console.WriteLine($"Dano Recebido: {danoTotal} \n{inimigo.Nome} morreu");
            //Caso morte não ocorra
            else Console.WriteLine($"Dano Recebido: {danoTotal} \nVida de {inimigo.Nome}: {inimigo.PontosVida}");

        }
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

    }
}
