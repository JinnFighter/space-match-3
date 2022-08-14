using Assets.Scripts.Logic.Components.Tiles;
using Assets.Scripts.Logic.Extensions;
using Assets.Scripts.Logic.Models;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Tiles
{
    public class CheckTileClickSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly TileClickInputModel _tileClickInputModel = null;
        private readonly TurnCountModel _turnCountModel = null;

        public void Run()
        {
            if(_turnCountModel.TurnCount > 0 && _tileClickInputModel.HasNewInput)
            {
                _world.SendMessage(new TileClicked { TilePosition = _tileClickInputModel.ClickedTilePosition });
            }
        }
    }
}