using System.Collections.Generic;
using Logic.Models;
using UnityEngine;

namespace Logic.MatchCheckers
{
    public interface IMatchChecker
    {
        bool CheckMatches(GameFieldModel gameFieldModel, Vector2Int startPosition, IEnumerable<Vector2Int> directions, Color matchColor);
    }
}