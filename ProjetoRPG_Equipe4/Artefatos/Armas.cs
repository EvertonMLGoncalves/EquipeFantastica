using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoRPG_Equipe4.Artefatos
{
    internal class Arma
    {
        

        public int Id { get; set; } 
         
        public string Nome { get; set; } 
         
        public int DanoBase { get; set; }  
         
        public int Apropriado { get; set; }
         
        public Arma() { }
        public Arma(int id, string nome, int danoBase)
        {
            Id = id;
            Nome = nome;
            DanoBase = danoBase; 

        }
    }
}
