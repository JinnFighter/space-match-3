using System;

namespace Assets.Scripts.Logic.Models
{
    public class ScoreModel
    {
        private int _score;
        public int Score 
        {
            get => _score;
            set
            {
                if(_score != value)
                {
                    _score = value;
                    ScoreChanged?.Invoke(_score);
                }
            }
        }

        public event Action<int> ScoreChanged;
    }
}