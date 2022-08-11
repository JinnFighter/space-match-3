using System;

namespace Assets.Scripts.Logic.Models
{
    public class TurnCountModel
    {
        private int _turnCount = 20;

        public int TurnCount
        {
            get => _turnCount;
            set
            {
                if(_turnCount != value)
                {
                    _turnCount = value;
                    TurnCountChanged?.Invoke(_turnCount);
                }
            }
        }

        public event Action<int> TurnCountChanged;
    }
}