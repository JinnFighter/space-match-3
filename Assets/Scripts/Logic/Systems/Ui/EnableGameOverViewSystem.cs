using Assets.Scripts.Logic.Components.Gameplay;
using Assets.Scripts.Logic.Views;
using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Systems.Ui
{
    public class EnableGameOverViewSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameOverEvent> _filter = null;
        private readonly GameOverView _gameOverView = null;

        public void Run()
        {
            if(!_filter.IsEmpty())
            {
                _gameOverView.gameObject.SetActive(true);
            }
        }
    }
}