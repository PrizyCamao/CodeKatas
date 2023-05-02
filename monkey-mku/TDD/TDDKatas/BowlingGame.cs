namespace TDDKatas
{
    internal class BowlingGame
    {
        private List<Frame> _frames;
        private bool _isSecondRoll;

        public BowlingGame()
        {
            _frames = new List<Frame> ();
        }

        public void Roll(int pinsRolled)
        {
            if (pinsRolled < 0 || pinsRolled > 10) return;

            if (!_isSecondRoll && pinsRolled == 10)
            {
                _frames.Add(new Frame(10, 0));
                _isSecondRoll = false;
                return;
            }

            if (!_isSecondRoll)
                _frames.Add(new Frame(pinsRolled, 0));

            var currentFrame = _frames.Last();

            if (_isSecondRoll)
                currentFrame.SecondRoll = pinsRolled;

            _isSecondRoll = !_isSecondRoll;
        }

        public int Score()
        {
            var returnValue = 0;
            var lastFrameStrike = false;
            var lastFrameSpare = false;

            foreach (var frame in _frames)
            {
                var firstRoll = frame.FirstRoll;
                var secondRoll = frame.SecondRoll;

                if (lastFrameStrike)
                    returnValue += (firstRoll * 2 + secondRoll * 2);
                else if (lastFrameSpare)
                    returnValue += firstRoll * 2 + secondRoll;
                else returnValue += firstRoll + secondRoll;

                lastFrameStrike = firstRoll == 10;
                lastFrameSpare = firstRoll != 10 && firstRoll + secondRoll == 10;
            }

            return returnValue;
        }
    }

    internal class Frame
    {
        public int FirstRoll { get; set; }
        public int SecondRoll { get; set; }

        public Frame(int firstRoll, int secondRoll)
        {
            FirstRoll = firstRoll;
            SecondRoll = secondRoll;
        }
    }
}