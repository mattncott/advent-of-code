namespace AdventOfCode.DayTwo
{
    public class Game
    {
        private readonly TheirChoice _opponentChose;
        private readonly YourChoice? _youChose;
        private readonly DesiredOutcome? _desiredOutcome;

        public Game(TheirChoice opponentChose, DesiredOutcome outcome)
        {
            this._desiredOutcome = outcome;
            this._opponentChose = opponentChose;
        }

        public Game(TheirChoice opponentChose, YourChoice youChose)
        {
            this._opponentChose = opponentChose;
            this._youChose = youChose;
        }

        public TheirChoice OpponentChose { get { return _opponentChose; } }

        public YourChoice GetWhatIShouldPick()
        {
            if (this._desiredOutcome == null)
            {
                throw new ArgumentException("Desired outcome cannot be null");
            }

            if (this._desiredOutcome == DesiredOutcome.Win) return this.GetWinningMove();
            if (this._desiredOutcome == DesiredOutcome.Lose) return this.GetLosingMove();
            return this.GetDrawingMove();
        }

        public int GetPointsForGame()
        {
            if (this._youChose == null)
            {
                throw new ArgumentException("YouChose cannot be null");
            }

            var points = 0;

            points += this.GetPointsForWhatYouChose();
            points += this.GetPointsForOutcome();

            return points;
        }

        private int GetPointsForOutcome()
        {
            if (this.CalculateIfMatchWasADraw()) return (int)Points.Draw;
            if (this.CalculateIfMatchWasALoss()) return (int)Points.Loss;
            return (int)Points.Win;
        }

        private YourChoice GetWinningMove()
        {
            if (this._opponentChose == TheirChoice.Paper) return YourChoice.Scissors;
            if (this._opponentChose == TheirChoice.Scissors) return YourChoice.Rock;
            return YourChoice.Paper;
        }

        private YourChoice GetDrawingMove()
        {
            if (this._opponentChose == TheirChoice.Paper) return YourChoice.Paper;
            if (this._opponentChose == TheirChoice.Scissors) return YourChoice.Scissors;
            return YourChoice.Rock;
        }

        private YourChoice GetLosingMove()
        {
            if (this._opponentChose == TheirChoice.Paper) return YourChoice.Rock;
            if (this._opponentChose == TheirChoice.Scissors) return YourChoice.Paper;
            return YourChoice.Scissors;
        }

        private bool CalculateIfMatchWasADraw()
            => (this._youChose == YourChoice.Rock && this._opponentChose == TheirChoice.Rock) ||
                (this._youChose == YourChoice.Paper && this._opponentChose == TheirChoice.Paper) ||
                (this._youChose == YourChoice.Scissors && this._opponentChose == TheirChoice.Scissors);

        private bool CalculateIfMatchWasALoss()
            => (this._youChose == YourChoice.Rock && this._opponentChose == TheirChoice.Paper) ||
                (this._youChose == YourChoice.Paper && this._opponentChose == TheirChoice.Scissors) ||
                (this._youChose == YourChoice.Scissors && this._opponentChose == TheirChoice.Rock);

        private int GetPointsForWhatYouChose()
        {
            if (this._youChose == YourChoice.Rock)
            {
                return 1;
            }
            else if (this._youChose == YourChoice.Paper)
            {
                return 2;
            }

            return 3;
        }
    }
}
