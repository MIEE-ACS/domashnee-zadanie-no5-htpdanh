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

namespace DZ5
{
    public class Shoes
    {
        public int code;
        public int size;
        public int cost;
        public int Code
        {set { code = value; }
            get { return code; }
        }
        public int Size
        {
            set { size = value; }
            get { return size; }
        }
        public int Cost
        {
            set { cost = value; }
            get { return cost; }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Shoes> items = new List<Shoes>();
        int click = 0;
        Shoes[] S = new Shoes[100];
        public MainWindow()
        {
            InitializeComponent();
        }
        public void delete()
        {
                for (int i = 0; i < click; i++)
                {
                    if (S[i].Code == S[click].Code && S[i].Size == S[click].Size && S[i].Cost == S[click].Cost)
                    {
                    items.RemoveAt(click);
                    click = click - 1;
                    break;
                    }
                }
        }
        private void input_Click(object sender, RoutedEventArgs e)
        {
            int a1, b1, c1;
            bool a = int.TryParse(code1.Text, out a1);
            bool b = int.TryParse(size.Text, out b1);
            bool c = int.TryParse(cost.Text, out c1);
            if ((a == true && b == true && c == true) && (a1 > 0 && b1 > 0 && b1 < 60 && c1 > 0))
            {
                S[click] = new Shoes();
                S[click].Code = a1;
                S[click].Size = b1;
                S[click].Cost = c1;
                items.Add(new Shoes { Code = S[click].Code, Size = S[click].Size, Cost = S[click].Cost });
                if (click >= 1)
                    delete();
                click++;
                List12.ItemsSource = items;
                List12.Items.Refresh();
            }
            else
            {
                MessageBox.Show("fail, please try to input again");
            }

        }
        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void code1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        int d = 0;
        private void find_Click(object sender, RoutedEventArgs e)
        {
            List<Shoes> category = new List<Shoes>();
            int a = int.Parse(sizecategory.Text);
            int choose = findcb.SelectedIndex;
            switch (choose)
            {
                case 0:
                    {
                        for (int i = 0; i < click; i++)
                        {
                            if (a == S[i].Code)
                            {
                                category.Add(new Shoes { Code = S[i].Code, Size = S[i].Size, Cost = S[i].Cost });
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < click; i++)
                        {
                            if (a == S[i].Size)
                            {
                                category.Add(new Shoes { Code = S[i].Code, Size = S[i].Size, Cost = S[i].Cost });                            
                            }
                        }
                        break;
                    }
            }
            List12.ItemsSource = category;
            List12.Items.Refresh();
        }
    }
}
