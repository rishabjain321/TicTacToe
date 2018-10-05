//Author: Rishab
//Helped by Cem Eden
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// INotifyPropertyChanged
using System.ComponentModel;

// Brush
using System.Windows.Media;

namespace TicTacToe
{
    public enum symbols { nought, cross, blank };

    public class gameField : INotifyPropertyChanged
    {

        public gameField(int id, double height, double width)
        {
            _id = id;
            _symbol = symbols.blank;
            _height = height;
            _width = width;
            _background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
        }

        public gameField(int id, double height, double width, symbols symbol)
        {
            _id = id;
            _symbol = symbol;
            _height = height;
            _width = width;
            _background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
        }

        //public int id { get; set; }
        //public symbols symbol { get; set; }

        // height and width definitions
        public double _height;
        public double _width;
        public double height { get { return (_height); } set { _height = value; OnPropertyChanged("height"); } }
        public double width { get { return (_width); } set { _width = value; OnPropertyChanged("width"); } }

        public Brush _background;
        public Brush background { get { return (_background); } set { _background = value; OnPropertyChanged("background"); } }

        public int _id;
        public string id { get { return (_id.ToString()); } set { _id = int.Parse(value); OnPropertyChanged("id"); } }

        public symbols _symbol;
        public string symbol
        {
            get
            {
                return (symbolToString(_symbol));
            }
            set
            {
                //_symbol = value;
                OnPropertyChanged("symbol");
            }
        }

        public void setSymbol(symbols symbol) // set symbol handle
        {
            _symbol = symbol;
            OnPropertyChanged("symbol");
        }

        public string symbolToString(symbols symbol)
        {
            switch (symbol)
            {
                case (symbols.nought):
                    return ("O");
                case (symbols.cross):
                    return ("X");
                case (symbols.blank):
                    return ("");
            }
            return ("");
        }

        #region Data Binding Stuff

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
