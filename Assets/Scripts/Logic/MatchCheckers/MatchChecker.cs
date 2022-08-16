using UnityEngine;

namespace Logic.MatchCheckers
{
    public class MatchChecker : IMatchChecker
    {
        private readonly Vector2Int[] _horizontalDirections = { Vector2Int.left, Vector2Int.right, };
        private readonly Vector2Int[] _verticalDirections = { Vector2Int.up, Vector2Int.down, };
        
        public bool CheckMatches(GameFieldModel gameFieldModel, Vector2Int startPosition, int matchState)
        {
            var hasMatches = false;
            if (GetMatchesCount(gameFieldModel, startPosition, _horizontalDirections, matchState) >= 3)
            {
                hasMatches = true;
            }
            else if (GetMatchesCount(gameFieldModel, startPosition, _verticalDirections, matchState) >= 3)
            {
                hasMatches = true;
            }

            return hasMatches;
        }
        
        private int GetMatchesCount(GameFieldModel gameFieldModel, Vector2Int startPosition, Vector2Int[] directions, int matchState)
        {
            var matchesCount = 1;

            foreach(var direction in directions)
            {
                var currentPosition = startPosition + direction;
                while (gameFieldModel.IsInside(currentPosition))
                {
                    if (gameFieldModel[currentPosition].State == matchState)
                    {
                        matchesCount++;
                    }
                    
                    currentPosition += direction;
                }
            }

            return matchesCount;
        }
    }
}
