using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpiente
{
    public class Serpiente
    {

        public int Direccion = 0;
        public int TamanyoSerpiente = 1;
        public int TamanyoMaximoSerpiente = 4;

        public List<(int, int)> Partes = new List<(int x, int y)>();

        int x;
        int y;
        char cuerpo = 'O';

        Tablero tablero;
        public Serpiente(Tablero tablero)
        {
            this.tablero = tablero;
            InicializarSerpiente();
        }

        void InicializarSerpiente()
        {
            x = tablero.AnchoTablero / 2;
            y = tablero.AltoTablero / 2;

            Partes.Add((x, y));
        }

        void CrearCuerpoSerpiente(int x, int y)
        {
            if (TamanyoSerpiente <= TamanyoMaximoSerpiente)
            {
                Partes.Add((x, y));
                TamanyoSerpiente++;
            }
        }

        void ModificarPosicion(int x, int y)
        {
            // Crea la nueva posicion de la cabeza y borra el anterior punto

            if (this.x != x || this.y != y)
            {
                Partes.Insert(0, (this.x, this.y));

                Partes.RemoveAt(Partes.Count - 1);
            }
        }

        void FueraDeLosLimites(int x, int y)
        {
            // Traspasar los limites y aparecer en el otro lado

            if (this.y < 0)
                this.y = y - 1;
            else if (this.y >= y)
                this.y = 0;
            if (this.x < 0)
                this.x = x - 1;
            else if (this.x >= x)
                this.x = 0;

        }

        public void MovimientoJugador(ref bool Salir)
        {
            int antiguaCabezaX = x;
            int antiguaCabezaY = y;

            CrearCuerpoSerpiente(antiguaCabezaX, antiguaCabezaY);

            var leerTeclado = Console.ReadKey(true);
            switch (leerTeclado.Key)
            {
                case ConsoleKey.W:
                    if (Direccion != 2)
                    {
                        Direccion = 1;
                        --y;
                    }
                    break;
                case ConsoleKey.D:
                    if (Direccion != 4)
                    {
                        Direccion = 3;
                        ++x;
                    }
                    break;
                case ConsoleKey.A:
                    if (Direccion != 3)
                    {
                        Direccion = 4;
                        --x;
                    }
                    break;
                case ConsoleKey.S:
                    if (Direccion != 1)
                    {
                        Direccion = 2;
                        ++y;
                    }
                    break;
            }
            ComprobacionDelMovimiento(ref Salir, ref antiguaCabezaX, ref antiguaCabezaY);
        }

        void ComprobacionDelMovimiento(ref bool Salir, ref int antiguaCabezaX, ref int antiguaCabezaY)
        {
            FueraDeLosLimites(tablero.AnchoTablero, tablero.AltoTablero);

            // Crea la nueva posicion y destruye la ultima
            ModificarPosicion(antiguaCabezaX, antiguaCabezaY);

            tablero.UbicarSerpiente(x, y);

            // Comprobar que no haya nada encima de la cabeza

            if (ZonaDelTableroOcupada(x, y, cuerpo) || ZonaDelTableroOcupada(x, y, 'B'))
                Salir = true;

            if (ZonaDelTableroOcupada(x, y, 'M'))
            {
                Objetos Manzana = new Manzana(x, y);
                Objetos Bomba = new Bomba(x, y);

                tablero.RemoverObjeto(Manzana);
                tablero.CrearObjeto(Manzana);
                tablero.CrearObjeto(Bomba);

                TamanyoMaximoSerpiente++;
            }
        }

        bool ZonaDelTableroOcupada(int x, int y, char objeto)
        {
            return tablero.TableroArray[x, y] == objeto;
        }

    }
}
