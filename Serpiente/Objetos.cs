using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpiente
{
    public class Objetos
    {
        public int x { get; set; }
        public int y { get; set; }
        public char simbolo { get; set; }

        public Tablero tablero;

        public Objetos(Tablero tablero)
        {
            this.tablero = tablero;
        }
        public Objetos(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
