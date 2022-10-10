using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Core
{
    public class GameLogic
    {
        class Move
        {
            int row = -1;
            int col = -1;

            public int Get()
            {
                return row * 3 + col;
            }

            public void Set(int i, int j)
            {
                row = i;
                col = j;
            }
        }

        char[,] board;
        char player;
        char opponent;
        public GameLogic(string board, char player)
        {
            this.board = new char[3, 3];
            int k = 0;
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    this.board[i, j] = board[k++];
                }
            }

            this.player = player;
            opponent = player == 'X' ? 'O' : 'X';
        }

        private bool IsMovesLeft()
        {
            for(int i = 0; i < 3; i++)
                for(int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                        return true;
                }
            return false;
        }

        private int Evaluate()
        {
            // Checking for Rows for X or O victory.
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == board[row, 1] &&
                    board[row, 1] == board[row, 2])
                {
                    if (board[row, 0] == player)
                        return +10;
                    else if (board[row, 0] == opponent)
                        return -10;
                }
            }

            // Checking for Columns for X or O victory.
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == board[1, col] &&
                    board[1, col] == board[2, col])
                {
                    if (board[0, col] == player)
                        return +10;

                    else if (board[0, col] == opponent)
                        return -10;
                }
            }

            // Checking for Diagonals for X or O victory.
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                if (board[0, 0] == player)
                    return +10;
                else if (board[0, 0] == opponent)
                    return -10;
            }

            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                if (board[0, 2] == player)
                    return +10;
                else if (board[0, 2] == opponent)
                    return -10;
            }

            // Else if none of them have won then return 0
            return 0;
        }

        private int MiniMax(int depth, bool isMax)
        {
            int score = Evaluate();

            if (score == 10 || score == -10)
                return score;

            if (!IsMovesLeft())
                return 0;

            if(isMax)
            {
                int best = -1000;

                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == '-')
                        {
                            board[i, j] = player;

                            best = Math.Max(best, MiniMax(depth + 1, !isMax));

                            board[i, j] = '-';
                        }
                    }
                }

                return best;
            }
            else
            {
                int best = 1000;

                for(int i = 0; i < 3; i++)
                {
                    for(int j = 0; j < 3; j++)
                    {
                        if (board[i, j] == '-')
                        {
                            board[i, j] = opponent;

                            best = Math.Min(best, MiniMax(depth + 1, !isMax));

                            board[i, j] = '-';
                        }
                    }
                }

                return best;
            }
        }

        public int FindBestMove()
        {
            int bestVal = -1000;
            Move bestMove = new Move();

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (board[i, j] == '-')
                    {
                        board[i, j] = player;

                        int moveVal = MiniMax(0, false);

                        board[i, j] = '-';

                        if(moveVal > bestVal)
                        {
                            bestMove.Set(i, j);
                            bestVal = moveVal;
                        }
                    }
                }
            }

            return bestMove.Get();
        }
    }
}
