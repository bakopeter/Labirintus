using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LabirintusGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int oszlopokSzama;
        int sorokSzama;
        public int OszlopokSzama { get => oszlopokSzama; set => oszlopokSzama = value; }
        public int SorokSzama { get => sorokSzama; set => sorokSzama = value; }
        
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 5; i <= 20; i++)
            {
                SorokMaxSzama.Items.Add(i);
                OszlopokMaxSzama.Items.Add(i);
            }
            SorokMaxSzama.SelectedItem = 12;
            OszlopokMaxSzama.SelectedItem = 12;
            for (int i = 1; i <= 16; i++) { AllomanyIndex.Items.Add(i); }
            AllomanyIndex.SelectedItem = 3 ;
        }

        private void LetrehozLab_Click(object sender, RoutedEventArgs e)
        {
            LabTer.Children.Clear();

            SorokSzama = (int)SorokMaxSzama.SelectedItem;
            OszlopokSzama = (int)OszlopokMaxSzama.SelectedItem;
            for (int i = 1; i <= SorokSzama; i++)
            {
                for (int j = 1; j <= OszlopokSzama; j++)
                {
                    CheckBox labMezo = new CheckBox();
                    labMezo.Width = 18; labMezo.Height = 18;
                    LabTer.Children.Add(labMezo);
                    labMezo.Margin = new Thickness((j-1) * 18, (i-1) * 18, 0, 0);

                    if (i == 1 || i == SorokSzama || j == 1 || j == OszlopokSzama)
                    {
                        labMezo.IsEnabled = false;
                        if ((i != SorokSzama - 1 && j !=1) || (i != 2 && j != OszlopokSzama)) 
                        { 
                            labMezo.IsChecked = true; 
                        }
                    }
                }
            }
        }
    }
}