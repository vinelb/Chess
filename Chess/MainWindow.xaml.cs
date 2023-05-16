using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        //Lista med alla bilder som används i spelet
        private readonly Dictionary<Gridvalue, ImageSource> gridValToImage = new()
        {
            {Gridvalue.Empty, Images.Empty },
            {Gridvalue.SvartBonde, Images.SvartBonde },
            {Gridvalue.SvartTorn, Images.SvartTorn },
            {Gridvalue.SvartHäst, Images.SvartHäst },
            {Gridvalue.SvartLöpare, Images.SvartLöpare },
            {Gridvalue.SvartDam, Images.SvartDam },
            {Gridvalue.SvartKung, Images.SvartKung },
            {Gridvalue.VitBonde, Images.VitBonde },
            {Gridvalue.VitTorn, Images.VitTorn },
            {Gridvalue.VitHäst, Images.VitHäst },
            {Gridvalue.VitLöpare, Images.VitLöpare },
            {Gridvalue.VitDam, Images.VitDam },
            {Gridvalue.VitKung, Images.VitKung },


        };

        private readonly int rows = 8, cols = 8;
        private readonly Image[,] gridImages;
        private GameState gameState;

        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();
            gameState = new GameState(rows, cols);             
        }
        //När Window laddas upp anropas Draw och gridet ritas 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Draw();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

        }
        //Sätter ut alla Empty rutor till Gridet
        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;

            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    Image image = new Image
                    {
                        Source = Images.Empty
                    };

                    images[r, c] = image;
                    GameGrid.Children.Add(image);

                }
                      
            }

            return images;
        }
        //Anropar "DrawGrid"
        private void Draw()
        {
            DrawGrid();
        }
        //Ritar upp gridet
        private void DrawGrid()
        {
            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    Gridvalue gridVal = gameState.Grid[r, c];
                    gridImages[r, c].Source = gridValToImage[gridVal];
                }
            }
        }
    }
}
