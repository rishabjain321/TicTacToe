//Author: Rishab
//Helped by Cem Eden
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


namespace TicTacToe
{
        public partial class MainWindow : Window
        {
            Model _model;

            public MainWindow()
            {
                _model = new Model();
                InitializeComponent();
                this.ResizeMode = ResizeMode.NoResize;
                this.DataContext = _model;
            }
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                _model.InitModel((UInt32)gameField.ActualHeight, (UInt32)gameField.ActualWidth);

                // create observable collections. 
                gameField.ItemsSource = _model.gameFields;
            }

            private void RestartButton_Click(object sender, RoutedEventArgs e)
            {
                _model.ResetgameFields();
            }

            private void startbtn_Click(object sender, RoutedEventArgs e)
            {
                _model.resetGame();
            }

            private void gameField_Click(object sender, RoutedEventArgs e)
            {
                Button btn = sender as Button;
            _model.ButtonClicked(int.Parse(btn.Tag.ToString()));
            }
        }
    }