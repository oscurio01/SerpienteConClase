using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpiente
{
    public class Tablero
    {

        public int AnchoTablero = 0;
        public int AltoTablero = 0;
        public char[,] TableroArray = new char[0, 0];
        public List<Objetos> Objetos = new List<Objetos> ();

        int CabezaSerpX;
        int CabezaSerpY;

        public Tablero() 
        {
            InicializaElTablero();
        }

        void InicializaElTablero()
        {
            Console.WriteLine("Dime que largo quieres el tablero");

            AnchoTablero = LeerUnNumeroCorrecto(200, 5);


            Console.WriteLine("Dime el ancho del tablero");

            AltoTablero = LeerUnNumeroCorrecto(50, 5);

            TableroArray = new char[AnchoTablero, AltoTablero];

            for (int y = 0; y < AnchoTablero; y++)
            {
                for (int x = 0; x < AltoTablero; x++)
                {
                    TableroArray[y, x] = ' ';
                }
            }

        }

        int LeerUnNumeroCorrecto(int maximo, int minimo = 0, string texto = "Numero no valido")
        {
            int numeroCorrecto;
            while (true)
            {
                Console.Write("> ");
                if (int.TryParse(Console.ReadLine(), out numeroCorrecto) && numeroCorrecto >= minimo && numeroCorrecto <= maximo)
                    return numeroCorrecto;
                else
                    Console.WriteLine(texto);
            }
        }

        public void PintarTablero(Serpiente Serpiente)
        {
            Console.Clear();

            // Limpia el tablero
            for (int i = 0; i < AltoTablero; i++)
            {
                for (int j = 0; j < AnchoTablero; j++)
                {
                    TableroArray[j, i] = ' ';
                }
            }

            PintarObjetos();

            PintarSerpiente(Serpiente);

            //Parte superior
            Console.Write('+');
            for (int i = 0; i < AnchoTablero; i++)
            {
                Console.Write('=');
            }
            Console.Write('+');

            //Dibujo interno y exteriores
            for (int y = 0; y < AltoTablero; y++)
            {
                Console.WriteLine();

                for (int x = 0; x < AnchoTablero + 2; x++)
                {

                    if (x == 0)
                        Console.Write('|');
                    else if (x == AnchoTablero + 1)
                        Console.Write("|");
                    else
                    {
                        if (TableroArray[x - 1, y] == 'M')
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (TableroArray[x - 1, y] == 'B')
                            Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write(TableroArray[x - 1, y]);

                        Console.ResetColor();
                    }
                }

            }

            // Parte inferior
            Console.WriteLine();
            Console.Write('+');
            for (int x = 0; x < AnchoTablero; x++)
            {
                Console.Write('=');
            }
            Console.WriteLine('+');


        }

        void PintarObjetos()
        {
            foreach (var objeto in Objetos)
            {
                TableroArray[objeto.x, objeto.y] = objeto.simbolo;
            }
        }

        void PintarSerpiente(Serpiente serpiente)
        {
            foreach (var parte in serpiente.Partes)
            {
                TableroArray[parte.Item1, parte.Item2] = (serpiente.Partes.IndexOf(parte) == 0) ? '@' : 'O';
            }
        }

        public void UbicarSerpiente(int x, int y)
        {
            CabezaSerpX = x;
            CabezaSerpY = y;
        }

        public void CrearObjeto( Objetos Objeto)
        {
            bool NoSeRepiten = true;
            do
            {
                NoSeRepiten = true;

                HashSet<(int, int)> conjunto = new HashSet<(int, int)>();

                Objeto.x = new Random().Next(0, AnchoTablero - 1);
                Objeto.y = new Random().Next(0, AltoTablero - 1);

                Objetos.Add(Objeto);

                foreach (var obj in Objetos)
                {
                    if (!conjunto.Add((obj.x, obj.y)))
                    {
                        // hay duplicados
                        NoSeRepiten = false;
                    }
                }

                if (!NoSeRepiten)
                    Objetos.RemoveAt(Objetos.Count - 1);
            }
            while (CabezaSerpX == Objeto.x && CabezaSerpY == Objeto.y || !NoSeRepiten);
        }

        public void RemoverObjeto(Objetos Objeto)
        {
            for (int i = 0; i < Objetos.Count; i++)
            {
                if (Objetos[i].x == Objeto.x && Objetos[i].y == Objeto.y && Objetos[i].simbolo == Objeto.simbolo)
                {
                    Objetos.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
