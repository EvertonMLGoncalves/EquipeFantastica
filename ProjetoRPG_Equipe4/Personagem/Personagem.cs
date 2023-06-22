using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Personagem
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
    }
}
