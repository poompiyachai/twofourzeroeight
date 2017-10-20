using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace twozerofoureight
{
    class TwoZeroFourEightModel : Model
    {

        protected int boardSize,checknum,sum=0; // default is 4
        protected int[,] board;
        protected Random rand;
        protected bool up= true,down= true,left= true,right=true,move = false;
        public TwoZeroFourEightModel() : this(4)
        {
            // default board size is 4 
        }

        public int[,] GetBoard()
        {
            return board;
        }

        public TwoZeroFourEightModel(int size)
        {
            boardSize = size;
            board = new int[boardSize, boardSize];
            var range = Enumerable.Range(0, boardSize);
            foreach(int i in range) {
                foreach(int j in range) {
                    board[i,j] = 0;
                }
            }
            rand = new Random();
            board = Random(board);
            NotifyAll();
        }

        private int[,] Random(int[,] input)
        {
           
            int i = 0;
            while (true)
            {
                int x = rand.Next(boardSize);
                int y = rand.Next(boardSize);
                if (board[x, y] == 0)
                {
                    board[x, y] = 2;
                    break;
                }
                i++;
                if(i==16)
                {
                    break;
                }

            }
            return input;
        }

        public void PerformDown()
        {
            move = false;
            
            if (up == false && down == false && right == false && left == false)
            {
                
                    for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        board[i, j] = 0;
                    }
                }
                
            }
            checknum = 0;
            int[] buffer;
            int pos;
            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeY);
            foreach (int i in rangeX)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeX)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeY)
                {
                    if (board[j, i] != 0)
                    {
                       
                        buffer[pos] = board[j, i];
                        pos++;
                    
                    }
                }
                // check duplicate
                foreach (int j in rangeX)
                {
                    
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        sum += buffer[j - 1] * 2;
                        buffer[j] = 0;
                        move = true;
                    }
                    else if (board[i, j] != 0)
                    {
                        checknum++;
                    }
                   
                    
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeX)
                {
                    if (buffer[j] != 0)
                    {
                        if(board[pos, i]==0)
                        {
                            move = true;
                        }
                        board[pos, i] = buffer[j];
                        pos--;
                       
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[k, i] = 0;
                }
            }
            if (checknum >15)
            {
                down = false;
            }
            
            if(move == true)
            {
             board = Random(board);
            }
            
            NotifyAll();
        }

        public void PerformUp()
        {
            move = false;
            if (up == false && down == false && right == false && left == false)
            {
                
                
                    for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        board[i, j] = 0;
                    }
                }
               
            }
            checknum = 0;
            int[] buffer;
            int pos;

            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[j, i] != 0)
                    {
                        buffer[pos] = board[j, i];
                        pos++;
                       
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        sum += buffer[j - 1] * 2;
                        buffer[j] = 0;
                        move = true;
                    }
                    else if (board[i, j] != 0)
                    {
                        checknum++;
                    }
                    
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        if(board[pos, i]==0)
                        {
                            move = true;
                        }
                        board[pos, i] = buffer[j];
                        pos++;
                       
                    }
                }
                // copy back
                for (int k = pos; k != boardSize; k++)
                {
                    board[k, i] = 0;
                }
            }
            if (checknum >15)
            {
                up = false;
            }
           
            if (move == true)
            {
                board = Random(board);
            }
            NotifyAll();
        }

        public void PerformRight()
        {
            move = false;
            if (up == false && down == false && right == false && left == false)
            {
                 
                    for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        board[i, j] = 0;
                    }
                }
                 
            }
            checknum = 0;
            int[] buffer;
            int pos;

            int[] rangeX = Enumerable.Range(0, boardSize).ToArray();
            int[] rangeY = Enumerable.Range(0, boardSize).ToArray();
            Array.Reverse(rangeX);
            foreach (int i in rangeY)
            {
                pos = 0;
                buffer = new int[4];
                foreach (int k in rangeY)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in rangeX)
                {
                    if (board[i, j] != 0)
                    {
                        buffer[pos] = board[i, j];
                        pos++;
                        
                    }
                }
                // check duplicate
                foreach (int j in rangeY)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        sum += buffer[j - 1] * 2;
                        buffer[j] = 0;
                        move = true;
                    }
                    else if (board[i, j] != 0)
                    {
                        checknum++;
                    }
                    
                }
                // shift left again
                pos = 3;
                foreach (int j in rangeY)
                {
                    if (buffer[j] != 0)
                    {
                        if(board[i, pos]==0)
                        {
                            move = true;
                        }
                        board[i, pos] = buffer[j];
                        pos--;
                       
                    }
                }
                // copy back
                for (int k = pos; k != -1; k--)
                {
                    board[i, k] = 0;
                }
            }
            if (checknum > 15)
            {
                right = false;
            }
           
            if (move == true)
            {
                board = Random(board);
            }
            NotifyAll();
        }

        public void PerformLeft()
        {
            move = false;
            if (up == false && down == false && right == false && left == false)
            {
                
                    for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        board[i, j] = 0;
                    }
                }
                
            }
            checknum = 0;
            int[] buffer;
            int pos;
            int[] range = Enumerable.Range(0, boardSize).ToArray();
            foreach (int i in range)
            {
                pos = 0;
                buffer = new int[boardSize];
                foreach (int k in range)
                {
                    buffer[k] = 0;
                }
                //shift left
                foreach (int j in range)
                {
                    if (board[i, j] != 0)
                    {
                        
                        buffer[pos] = board[i, j];
                        pos++;
                        
                    }
                }
                // check duplicate
                foreach (int j in range)
                {
                    if (j > 0 && buffer[j] != 0 && buffer[j] == buffer[j - 1])
                    {
                        buffer[j - 1] *= 2;
                        sum += buffer[j - 1] * 2;
                        buffer[j] = 0;
                        move = true;
                    }
                    else if(board[i, j] != 0)
                    {
                        checknum++;
                    }
                    
                }
                // shift left again
                pos = 0;
                foreach (int j in range)
                {
                    if (buffer[j] != 0)
                    {
                        if(board[i, pos]==0)
                        {
                            move = true;
                        }
                        board[i, pos] = buffer[j];
                        pos++;
                        
                    }
                }
                for (int k = pos; k != boardSize; k++)
                {
                    board[i, k] = 0;
                }
            }
            
            if (checknum > 15)
            {
                left = false;
            }
            
            if (move == true)
            {
                board = Random(board);
                
            }
            NotifyAll();
            
        }
    }
}
