using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpiente
{
    public class Manzana : Objetos
    {
        public Manzana(Tablero tablero): base(tablero)
        {
            simbolo = 'M';
            CrearManzana();
        }

        public Manzana(int x, int y): base(x, y)
        {
            this.x = x;
            this.y = y;
            simbolo = 'M';
        }

        public void CrearManzana()
        {
            tablero.CrearObjeto(this);
        }
    }
}
