﻿using System;
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

namespace BogeyCount
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

        private void viewScores_Click(object sender, RoutedEventArgs e)
        {
            scores.Text = "98 101 98";
        }

        private void enterScores_Click(object sender, RoutedEventArgs e)
        {
            enterPanel.Visibility = Visibility.Visible;
        }
    }
}
