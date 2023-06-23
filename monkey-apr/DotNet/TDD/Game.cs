namespace TDD;

internal class Game : IGame
{
    public int Score { get; private set; } = 0;

    private Frame _frame = new Frame();

    public void roll(int count)
    {
        _frame.score += count;
        _frame.bonus += _carryOver switch
        {
            CarryOver.Spare => count,
            CarryOver.Strike => count,
            _ => 0
        };

        if (_carryOver == CarryOver.Spare)
        {
            _carryOver = CarryOver.None;
        }

        if (_frame.score == 10)
        {
            _carryOver = _frame.roll == 0 ? CarryOver.Strike : CarryOver.Spare;
        }

        if (_frame.roll == 1 || _frame.score == 10)
        {
            Score += _frame.score + _frame.bonus;
            _frame = (++_frame.round, 0, 0, 0);
        }
        else
        {
            _frame.roll++;
        }
    }

    public int score()
    {
        return Score;
    }

    private enum CarryOver
    {
        None = 0,
        Spare,
        Strike
    }

    private class Frame
    {
        public int Round { get; private set; } = 0;
        public int Roll { get; set; } = 0;
        public int Score { get; set; } = 0;
        public int Bonus { get; set; } = 0;
        public List<(CarryOver carryOver, int remainingRolls)> CarryOver { get; init; }

        public Frame()
        {
            CarryOver = new List<(CarryOver carryOver, int remainingRolls)>();
        }

        public Frame(Frame lastFrame)
        {
            Round = ++lastFrame.Round;
            this.CarryOver = lastFrame.CarryOver.Where(co => co.remainingRolls > 0).ToList();
        }
    }
}
