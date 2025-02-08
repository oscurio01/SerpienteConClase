using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpiente
{
    public class Bomba : Objetos
    {
        public Bomba(Tablero tablero) : base(tablero)
        {
            simbolo = 'B';
            CrearBomba();
        }

        public Bomba(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
            simbolo = 'B';
        }

        void CrearBomba()
        {
            tablero.CrearObjeto(this);
        }
    }
}
