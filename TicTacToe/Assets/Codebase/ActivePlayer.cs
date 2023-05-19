namespace Codebase
{
    public class ActivePlayer
    {
        public bool isCross;
        private bool isActiveFirstPlayer;
        private int moveCounter;

        public ActivePlayer()
        {
            isCross = true;
            isActiveFirstPlayer = true;
            moveCounter = 0;
        }

        public void EndMove()
        {
            isCross = !isCross;
            isActiveFirstPlayer = !isActiveFirstPlayer;
            moveCounter++;
        }
    }
}