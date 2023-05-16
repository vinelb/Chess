using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    //GameState, de olika staterna som alla rutor kan befinna sig i
    public class GameState
    {
        public int Rows { get; }
        public int Cols { get; }
        public Gridvalue[,] Grid { get; }
        public Direction Dir { get; private set; }

        private readonly LinkedList<Position> piecePosition = new LinkedList<Position>();
        //Anropar Add till gridet, gör så att bilderna läggs till på brädan
        public GameState(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new Gridvalue[rows, cols];

            EmptyPositions();
            AddEmpty();

            AddSvartBonde();
            AddSvartTorn();
            AddSvartHäst();
            AddSvartLöpare();
            AddSvartDam();
            AddSvartKung();

            AddVitBonde();
            AddVitTorn();
            AddVitHäst();
            AddVitLöpare();
            AddVitDam();
            AddVitKung();

        }

        //Lägger till empty och ger oss en 8x8 stort grid
        private void AddEmpty()
        {
            for(int r = 0; r <=7; r++)
            {
                for(int c = 0; c <=7; c++)
                {
                    Grid[r, c] = Gridvalue.Empty;
                }
            }
        }
        //Lägger ut svarta bönder på rad 1 ch sen en for loop för att lägga ut bönderna på hela columnen
        private void AddSvartBonde()
        {
            int r = 1;

            for ( int c = 0; c <=7; c++)
            {
                Grid[r, c] = Gridvalue.SvartBonde;
            }
        }
        //Lägger ut svarta torn på två positioner
        private void AddSvartTorn()
        {
            Grid[0, 0] = Gridvalue.SvartTorn;
            Grid[0, 7] = Gridvalue.SvartTorn;

        }
        //Lägger ut svarta hästar på två positioner
        private void AddSvartHäst()
        {
            Grid[0, 1] = Gridvalue.SvartHäst;
            Grid[0, 6] = Gridvalue.SvartHäst;

        }
        //Lägger ut svarta löpare på två positioner
        private void AddSvartLöpare()
        {
            Grid[0, 2] = Gridvalue.SvartLöpare;
            Grid[0, 5] = Gridvalue.SvartLöpare;
        }
        //Lägger ut svarta dam på två positioner
        private void AddSvartDam()
        {
            Grid[0, 3] = Gridvalue.SvartDam;
        }
        //Lägger ut svarta kung på två positioner
        private void AddSvartKung()
        {
            Grid[0, 4] = Gridvalue.SvartKung;
        }


        //Lägger ut vita bönder på rad 1 ch sen en for loop för att lägga ut bönderna på hela columnen

        private void AddVitBonde()
        {
            int r = 6;

            for (int c = 0; c <= 7; c++)
            {
                Grid[r, c] = Gridvalue.VitBonde;
            }
        }
        //Sätter ut vita torn på två positioner
        private void AddVitTorn()
        {
            Grid[7, 0] = Gridvalue.VitTorn;
            Grid[7, 7] = Gridvalue.VitTorn;

        }
        //Sätter ut vita hästar på två positioner
        private void AddVitHäst()
        {
            Grid[7, 1] = Gridvalue.VitHäst;
            Grid[7, 6] = Gridvalue.VitHäst;

        }
        //Sätter ut vita löpare på två positioner
        private void AddVitLöpare()
        {
            Grid[7, 2] = Gridvalue.VitLöpare;
            Grid[7, 5] = Gridvalue.VitLöpare;
        }
        //Sätter ut vita dam på två positioner
        private void AddVitDam()
        {
            Grid[7, 3] = Gridvalue.VitDam;
        }
        //Sätter ut vita kung på två positioner
        private void AddVitKung()
        {
            Grid[7, 4] = Gridvalue.VitKung;
        }
        //Skapar en lista med alla positioner och dess gridvalue.
        private IEnumerable<Position> EmptyPositions()
        {
            for (int r = 0; r < Rows; r++)
            {
                for (int c = 0; c < Cols; c++)
                {
                    if (Grid[r, c] == Gridvalue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }



    }


} 
