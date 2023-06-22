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
        public string Nome { get; set; } // editavel
        public int PontosVida { get; set; } // nasce: 100 | Morre com: 0 
        public int Forca { get; set; } // inicia com 1
        public int Defesa { get; set; } //inicia com 1
        public string Sexo { get; set; } // editavel
        public int XP { get; set; } // Experiencia, qnd vence o adverssario, ele ganha XP
        //public List<Habilidade> Habilidades { get; set; }
        public string Status { get; set; }

        public List<Arma> ListaArmas = new List<Arma>();

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
            if (inimigo.PontosVida <= 0) Console.WriteLine($"{inimigo.Nome} morreu \nDano Causado: {dano}");
            else Console.WriteLine($"Vida de {inimigo.Nome}: {inimigo.PontosVida} \nDano causado: {dano}");
        } 
        public virtual void ExibirInfo()  
        {
            Console.WriteLine($"----------------------\nNome: {Nome}");
            Console.WriteLine($"PontosVida: {PontosVida}");
            Console.WriteLine($"Forca: {Forca}");
            Console.WriteLine($"Defesa: {Defesa}");
            Console.WriteLine($"Sexo: {Sexo}");
            Console.WriteLine($"XP: {XP}");
            Console.WriteLine($"Status: {Status}");

        }
    }
}
