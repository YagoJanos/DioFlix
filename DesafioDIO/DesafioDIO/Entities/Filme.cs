using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioDIO
{
    internal class Filme : Cinematografia
    {
        public Filme(int id, Genero genero, string titulo, string descricao, int ano) : base(id, genero, titulo, descricao, ano)
        {
            
        }
        

    }
}
