using Assets.Scripts.Logic.Content;

namespace Assets.Scripts.Common
{
    public class Game : IGame
    {
        public ControllerContainer ControllerContainer { get; set; }
        public PrefabsContent PrefabsContent { get; set; }
        public DescriptionsContent DescriptionContent { get; set; }
    }
}