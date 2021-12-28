using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDIO
{
    internal class Serie : Cinematografia
    {
    
        public Serie(int id, Genero genero, string titulo, string descricao, int ano) : base(id, genero, titulo, descricao, ano)
        {
            
        }

       
    }
}
