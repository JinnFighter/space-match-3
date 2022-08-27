using System.Collections.Generic;
using Logic.Models;
using UnityEngine;

namespace Logic.MatchCheckers
{
    public class MatchChecker : IMatchChecker
    {
        public bool CheckMatches(GameFieldModel gameFieldModel, Vector2Int startPosition, IEnumerable<Vector2Int> directions, Color matchColor)
        {
            return GetMatchesCount(gameFieldModel, startPosition, directions, matchColor) >= 2;
        }
        
        private int GetMatchesCount(GameFieldModel gameFieldModel, Vector2Int startPosition, IEnumerable<Vector2Int> directions, Color matchColor)
        {
            var matchesCount = 0;

            foreach(var direction in directions)
            {
                var currentPosition = startPosition + direction;
                while (gameFieldModel.IsInside(currentPosition))
                {
                    if (gameFieldModel[currentPosition].Color == matchColor)
                    {
                        matchesCount++;
                        currentPosition += direction;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return matchesCount;
        }
    }
}
