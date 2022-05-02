using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using SQLite;

namespace Databaze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Database _data;
        private ObservableCollection<Avenger> avengers;
        public static Database Data
        {
            get
            {
                if(_data == null)
                {
                    _data = new Database("./Avenger.db3");
                }
                return _data;
            }
        }
        public MainWindow()
        {
            
            InitializeComponent();
            Data.DeleteAvengers();
            avengers = new ObservableCollection<Avenger>();
            loadAvengers();
            


            pes.ItemsSource = "";
            foreach (var item in avengers)
            {
                pes.ItemsSource += item.Name;
            }
            
            
            
        }

        private void loadAvengers()
        {
            var avengersDb = Data.GetAllAvengers().Result;
            //avengers.Add(avengersDb.);
            foreach (Avenger avenger in avengersDb)
            {
                avengers.Add(avenger);
            }
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {


            Avenger av = new Avenger()
            {
                Name = t1.Text,
                RealName = t2.Text,
                Gender = t3.Text,

            };
            Data.SaveAvengerAsync(av);
            t1.Text = "";
            t2.Text = "";
            t3.Text = "";
            loadAvengers();
            pes.ItemsSource = "";
            foreach (var item in avengers)
            {
                pes.ItemsSource += item.Name;
            }

        }
    }
}
