using System;

class Program
{
    enum Player
    {
        None,
        Cross,
        Circle
    }

    class Move
    {
        public int x;
        public int y;

        public Move(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Game
    {
        Player[,] board = new Player[3, 3];
        int moves = 0;
        
        public Player Turn = Player.Cross;

        public Game Clone()
        {
            var g = (Game)MemberwiseClone()
            //MemberwiseClone();//shallow copy, meaning only by referece, so if we need a deep copy we have to deal with it ourselves
        }
    }
}