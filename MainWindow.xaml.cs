﻿using System;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
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
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            string colortext = (string)(sender as RadioButton).Tag;
            Regex rgx = new Regex("^(?:[0-9a-fA-F]{3}){2}$");
            if (rgx.Match(colortext).Success)
            {
                SolidColorBrush color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + colortext));
                colorMarcado = color;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border borde = sender as Border;
            borde.Background = colorMarcado;
        }
    }
}
