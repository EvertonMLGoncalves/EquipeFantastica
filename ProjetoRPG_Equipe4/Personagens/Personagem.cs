using ProjetoRPG_Equipe4.Artefatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Personagens
{
    internal class Personagem
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

        //public List<Habilidade> Habilidades { get; set; }
        

        public List<Arma> ListaArmas = new List<Arma>();
         
        public Personagem() { } 

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
        public void Atacar(Personagem inimigo)
        {
            int dano = Forca - inimigo.Defesa;
            if (dano < 0)
            {
                dano = 0;
            }
            inimigo.PontosVida -= dano;
            Console.WriteLine($"{inimigo.Nome} está sendo atacado!");
            if (inimigo.PontosVida <= 0) Console.WriteLine($"Dano Recebido: {dano} \n{inimigo.Nome} morreu");
            else Console.WriteLine($"Dano Recebido: {dano} \nVida de {inimigo.Nome}: {inimigo.PontosVida}");

        }
        public virtual void ExibirInfo()
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
        public virtual Personagem CriarPersonagem()
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
            return this;
        }
       /* public virtual Personagem() { }*/ 
       public virtual void AtualizarDados()
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
