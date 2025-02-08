using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serpiente
{
    internal class Programa
    {
        static bool Salir = false;
        static Tablero tablero;
        static Serpiente serpiente;
        static Manzana manzana;
        static Bomba bomba;

        static void Main(string[] args)
        {
            tablero = new Tablero();
            serpiente = new Serpiente(tablero);
            manzana = new Manzana(tablero);
            bomba = new Bomba(tablero);

            while (!Salir)
            {
                tablero.PintarTablero(serpiente);
                serpiente.MovimientoJugador(ref Salir);
            }
            tablero.PintarTablero(serpiente);

            Console.WriteLine();
            Console.WriteLine("Game Over");
        }

    }
}
