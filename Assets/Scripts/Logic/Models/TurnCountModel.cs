using Assets.Scripts.Logic.Descriptions;
using System;

namespace Assets.Scripts.Logic.Models
{
    public class TurnCountModel
    {
        private int _turnCount;
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

        public TurnCountModel(LevelDescription levelDescription)
        {
            _turnCount = levelDescription.TurnCount;
        }

        public event Action<int> TurnCountChanged;
    }
}