using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Pixel_Art
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush colorMarcado;
        private bool comprobarHecho = false;
        public MainWindow()
        {
            InitializeComponent();
            NegroRadioButton.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object preguntaResultado;
            if (comprobarHecho)
            {
                preguntaResultado = MessageBox.Show("Esta seguro de crear otra plantilla", "Atencion",MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            if(preguntaResultado == MessageBoxResult.Yes)
            {

            }

            DibujoGrid.RowDefinitions.Clear();
            DibujoGrid.ColumnDefinitions.Clear();
            DibujoGrid.Children.Clear();
            int tamaño = int.Parse((string)(sender as Button).Tag);
            for(int i = 1; i < tamaño; i++)
            {
                DibujoGrid.RowDefinitions.Add(new RowDefinition());
                DibujoGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            
            for (int i = 1; i < tamaño; i++)
            {
                for (int j = 1; j < tamaño; j++)
                {
                    Border a = new Border();
                    a.Style = (Style)this.Resources["Dibujo"];
                    Grid.SetColumn(a, i);
                    Grid.SetRow(a, j);
                    DibujoGrid.Children.Add(a);
                }
            }
            comprobarHecho = false;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string colortext = (string)(sender as RadioButton).Tag;
            Regex rgx = new Regex("^(?:[0-9a-fA-F]{3}){2}$");
            if (rgx.Match(colortext).Success)
            {
                SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + colortext));
                colorMarcado = color;
                ColorMosTextBlock.Background = colorMarcado;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border borde = sender as Border;
            borde.Background = colorMarcado;
            comprobarHecho = true;
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Border border = sender as Border;
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                border.Background = colorMarcado;
                comprobarHecho = true;
            }
            
        }

        private void ColorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          PerRadioButton.Tag = ColorTextBox.Text;
        }
    }
}
