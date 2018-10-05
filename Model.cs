//Author: Rishab
//Helped by Cem Eden
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

using System.Windows.Media;

namespace TicTacToe
{
    public partial class Model : INotifyPropertyChanged
    {
        // provide an observable collections for shapes
        public ObservableCollection<gameField> gameFields;
        public event PropertyChangedEventHandler PropertyChanged;

        public enum Player { noughts, crosses };
        public enum state { playing, stopped };
        private Player PlayersTurn;
        private state gamestate;
        private int movesMade;


        private UInt32 _drawingAreaHeight = 100;
        private UInt32 _drawingAreaWidth = 100;


        public void InitModel(UInt32 height, UInt32 width)
        {

            _drawingAreaHeight = height;
            _drawingAreaWidth = width;

            // place them manually at the top of the item collection in the view
            gameFields = new ObservableCollection<gameField>();

            resetGame();
        }

        public void resetGame()
        {
            ResetgameFields();
            statusMessage = "It's the Crosses (X) turn";
            PlayersTurn = Player.crosses;
            gamestate = state.playing; // activate game state
            movesMade = 0; // reset play count
            startButtonContent = "Start!";
            
        }

        public void ResetgameFields()
        {
            gameFields.Clear();
            for (int i = 0; i < 9; i++)
            {
                gameField temp = new gameField(i, _drawingAreaHeight / 3, _drawingAreaWidth / 3);
                gameFields.Add(temp);
            }
        }

        public void ButtonClicked(int btnID)
        {
            if (gamestate == state.stopped)
            {
                statusMessage = "Game Over, Restart to play again!";
                return;
            }
            if (gameFields[btnID]._symbol != symbols.blank)
            {
                statusMessage = "Please pick an empty field!";
                return;
            }
            movesMade++;

            if (PlayersTurn == Player.crosses) // set clicked field to current players symbol
            {
                gameFields[btnID].setSymbol(symbols.cross);
                PlayersTurn = Player.noughts;
                statusMessage = "It's the Noughtses (O) turn";
                startButtonContent = "Reset!";
            }
            else
            {
                gameFields[btnID].setSymbol(symbols.nought);
                PlayersTurn = Player.crosses;
                statusMessage = "It's the Crosses (X) turn";
                startButtonContent = "Reset!";
            }

            if (checkForWinCondition(symbols.nought))
            {
                statusMessage = "Noughts (O) Win!";
                gamestate = state.stopped; // stop game state
                startButtonContent = "Restart!";
                return;
            }
            if (checkForWinCondition(symbols.cross))
            {
                statusMessage = "Noughts (X) Win!";
                gamestate = state.stopped; // stop game state
                startButtonContent = "Restart!";
                return;
            }

            if (movesMade == 9)
            {
                statusMessage = "Draw!";
                gamestate = state.stopped; // stop game state
                startButtonContent = "Restart!";
                return;
            }
        }

        private bool checkForWinCondition(symbols winningSymbol)
        {
            if (checkRows(winningSymbol))
                return (true);
            if (checkColumns(winningSymbol))
                return (true);

            // check diagonals
            if (gameFields[0]._symbol == winningSymbol && gameFields[4]._symbol == winningSymbol && gameFields[8]._symbol == winningSymbol)
            {
                gameFields[0].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                gameFields[4].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                gameFields[8].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                return (true);
            }
            if (gameFields[2]._symbol == winningSymbol && gameFields[4]._symbol == winningSymbol && gameFields[6]._symbol == winningSymbol)
            {
                gameFields[2].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                gameFields[4].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                gameFields[6].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                return (true);
            }

            return (false);
        }

        private bool checkRows(symbols winningSymbol)
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (gameFields[i]._symbol == winningSymbol && gameFields[i + 1]._symbol == winningSymbol && gameFields[i + 2]._symbol == winningSymbol)
                {
                    gameFields[i].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                    gameFields[i + 1].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                    gameFields[i + 2].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                    return (true);
                }
            }
            return (false);
        }

        private bool checkColumns(symbols winningSymbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (gameFields[i]._symbol == winningSymbol && gameFields[i + 3]._symbol == winningSymbol && gameFields[i + 6]._symbol == winningSymbol)
                {
                    gameFields[i].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                    gameFields[i + 3].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                    gameFields[i + 6].background = new SolidColorBrush(Color.FromRgb(255, 0, 0)); // color buttons
                    return (true);
                }
            }
            return (false);
        }

        public string _statusMessage;
        public string statusMessage
        { // message box handle
            get { return (_statusMessage); }
            set { _statusMessage = value; OnPropertyChanged("statusMessage"); }
        }

        public string _startButtonContent;
        public string startButtonContent
        { // start button handle
            get { return (_startButtonContent); }
            set { _startButtonContent = value; OnPropertyChanged("startButtonContent"); }
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}



