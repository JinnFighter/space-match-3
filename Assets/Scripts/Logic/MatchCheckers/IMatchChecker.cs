using Logic.Models;
using UnityEngine;

namespace Logic.MatchCheckers
{
    public interface IMatchChecker
    {
        bool CheckMatches(GameFieldModel gameFieldModel, Vector2Int startPosition, Color matchColor);
    }
}