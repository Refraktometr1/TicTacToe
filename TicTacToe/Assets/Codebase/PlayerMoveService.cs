namespace Codebase
{
    public class PlayerMoveService
    {
        public bool isCross;
        private bool isActiveFirstPlayer;
        private int moveCounter;

        public PlayerMoveService()
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
            if (moveCounter == 9)
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            throw new System.NotImplementedException();
        }
    }
}