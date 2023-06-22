using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Batalha
{
    internal class Batalha
    {
        public void IniciarBatalha()
        {
            Console.WriteLine("Iniciando Batalha!");
            Console.WriteLine("Selecione: 1- Escolher Personagem \n2-Escolher Inimigo");
            int op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    break;

            }
        }
        public void TerminarBatalha()
        {

        }
    }
}
