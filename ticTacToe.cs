using System;

namespace TicTacToe
{
    class GamePlay
    {
        static void Main()
        {
            bool gameOver = false;
            Board board = new Board();
            while(!gameOver)
            {
                Console.Clear();
                board.PrintBoard();
                board.Play();
                gameOver = board.CheckWin();
            }
            board.PrintBoard();
            if(!board.draw)
                board.DetermineWinner();
            else   
                Console.WriteLine("Draw! Nobody wins!");

        }
    }
    class Board
    {
        private char[] plays = new char[9];
        private int turnsPlayed;
        public bool draw;
        
        public Board()
        {
            for(int i = 0; i <= 8; ++i)
            {
                plays[i] = Convert.ToChar(i+48);
            }
            turnsPlayed = 0;
            draw = false;
        }
        public void PrintBoard()
        {
            Console.WriteLine(" {0}|{1}|{2}", plays[0], plays[1], plays[2]);
            Console.WriteLine(" -----");
            Console.WriteLine(" {0}|{1}|{2}", plays[3], plays[4], plays[5]);
            Console.WriteLine(" -----");
            Console.WriteLine(" {0}|{1}|{2}", plays[6], plays[7], plays[8]);
        }

        public void Play()
        {
            bool successfulPlay = false;
            int player = turnsPlayed % 2;
            while(!successfulPlay){
                int boardSelection = GetInput(player+1);
                successfulPlay = PushToArray(boardSelection, player);
            }
            ++turnsPlayed;
        }
        private int GetInput(int player)
        {
            Console.Write("Player {0}, pick a board position to play: ", player);
            return Convert.ToInt32(Console.ReadLine());
        }

        private bool PushToArray(int boardSelection, int player)
        {
            if(plays[boardSelection] != 'x' && plays[boardSelection] != 'o')
            {
                plays[boardSelection] = (player == 0) ? 'x' : 'o';
                return true;
            } 
            else
            {
                Console.WriteLine("Illegal move! Pick again!");
                return false;
            }
        }
        public int DetermineWinner()
        {
            if(turnsPlayed % 2 != 0)
            {
                Console.WriteLine("Player 1 wins!");
                return 0;
            } 
            else 
            {
                Console.WriteLine("Player 2 wins!");
                return 0;
            }
        }
        public bool CheckDraw()
        {
            if(turnsPlayed == 9) 
            {
                draw = true;
                return true;
            }
            else return false;
        }
        public bool CheckWin()
        //Assumes board has winning play, checks for negation
        //Row by row, column by column
        { 
            bool win = true;
            //first row
            for(int i = 0; i < 2; ++i)
            {
                if(plays[i] != plays[i+1])
                    win = false;
            }
            if(win) return win;
            //second row
            win = true;
            for(int i = 3; i < 5; ++i)
            {
                if(plays[i] != plays[i+1])
                    win = false;
            }
            if(win) return win;
            //third row
            win = true;
            for(int i = 6; i < 8; ++i)
            {
                if(plays[i] != plays[i+1])
                    win = false;
            }
            if(win) return win;
            //first column
            win = true;
            for(int i = 0; i < 6; i += 3)
            {
                if(plays[i] != plays[i+3])
                    win = false;
            }
            if(win) return win;
            //second column
            win = true;
            for(int i = 1; i < 7; i += 3)
            {
                if(plays[i] != plays[i+3])
                    win = false;
            }
            if(win) return win;
            //third column
            win = true;
            for(int i = 2; i < 8; i += 3)
            {
                if(plays[i] != plays[i+3])
                    win = false;
            }
            if(win) return win;
            //right diagonal
            win = true;
            for(int i = 0; i < 8; i += 4)
            {
                if(plays[i] != plays[i+4])
                    win = false;
            }
            if(win) return win;
            //left diagonal
            win = true;
            for(int i = 2; i < 6; i += 2)
            {
                if(plays[i] != plays[i+2])
                    win = false;
            }
            win = CheckDraw();
            return win;
        }
    }
}