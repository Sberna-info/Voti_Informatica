using System;
using Calcoli;
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

namespace Wpf_Voti_Informatica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalcola_Click(object sender, RoutedEventArgs e)
        {
            double voto1, voto2 , voto3, voto4;
            double media;
            if (txtC1.Text != "" && txtC2.Text != "" && txtC3.Text != "" && txtC4.Text != "" )
            {
                try
                {
                    voto1 = double.Parse(txtC1.Text);
                    voto2 = double.Parse(txtC2.Text);
                    voto3 = double.Parse(txtC3.Text);
                    voto4 = double.Parse(txtC4.Text);
                    if (voto1 > 10 || voto1 < 2 || voto2 > 10 || voto2 < 2 || voto3 > 10 || voto3 < 2 || voto4 > 10 || voto4 < 2)
                        MessageBox.Show("i voti devono essere compresi tra 2 e 10", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Information);
                    else
                    {
                        double min1 = Math.Min(voto1,voto2);
                        double min2 = Math.Min(min1, Math.Min(voto3, voto4));
                        double max1 = Math.Max(voto1, voto2);
                        double max2 = Math.Max(max1, Math.Max(voto3, voto4));
                        lblStampaMin.Content = min2;
                        lblStampaMax.Content = max2;
                        double tot = voto1 + voto2 + voto3 + voto4;
                        double IncV1 = Gestione.Incidenza(voto1, tot);
                        double IncV2 = Gestione.Incidenza(voto2, tot);
                        double IncV3 = Gestione.Incidenza(voto3, tot);
                        double IncV4 = Gestione.Incidenza(voto4, tot);
                        lblIncV1.Content = IncV1;
                        lblIncV2.Content = IncV2;
                        lblIncV3.Content = IncV3;
                        lblIncV4.Content = IncV4;
                        media = tot / 4;
                        lblStampaMedia.Content = media;
                        if (media >= 6)
                        {
                            lblStampa.Content = "Studente promosso";
                        }
                        else
                        {
                            lblStampa.Content = "Studente bocciato";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Attenzione", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Inserisci tutti i dati", "Attenzione", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
