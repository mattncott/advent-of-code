namespace AdventOfCode.DayTwo
{
    enum Points
    {
        Loss = 0,
        Draw = 3,
        Win = 6,
    }

    public class Game
    {
        /*
         * X, A = Rock
         * Y, B = Scissors
         * Z, C = Paper
         */
        public char OpponentChose { get; set; }
        public char YouChose { get; set; }

        public Game(char opponentChose, char youChose)
        {
            OpponentChose = opponentChose;
            YouChose = youChose;
        }

        public int GetPointsForGame()
        {
            var points = 0;

            points += GetPointsForWhatYouChose();
            points += GetPointsForOutcome();

            return points;
        }

        private int GetPointsForOutcome()
        {
            if (CalculateIfMatchWasADraw()) return (int)Points.Draw;
            if (CalculateIfMatchWasALoss()) return (int)Points.Loss;
            if (CalculateIfMatchWasAWin()) return (int)Points.Win;

            throw new Exception("Won't get here");
        }

        private bool CalculateIfMatchWasADraw()
            => (YouChose == 'X' && OpponentChose == 'A') || (YouChose == 'Y' && OpponentChose == 'B') ||
                (YouChose == 'Z' && OpponentChose == 'C');

        private bool CalculateIfMatchWasALoss()
            => (YouChose == 'X' && OpponentChose == 'C') || (YouChose == 'Y' && OpponentChose == 'A') ||
                (YouChose == 'Z' && OpponentChose == 'B');

        private bool CalculateIfMatchWasAWin()
            => (YouChose == 'X' && OpponentChose == 'B') || (YouChose == 'Y' && OpponentChose == 'C') ||
                (YouChose == 'Z' && OpponentChose == 'A');

        private int GetPointsForWhatYouChose()
        {
            if (YouChose == 'X')
            {
                return 1;
            }
            else if (YouChose == 'Y')
            {
                return 2;
            }
            return 3;
        }
    }
}
