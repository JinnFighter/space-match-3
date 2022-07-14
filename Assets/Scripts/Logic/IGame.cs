using Assets.Scripts.Logic.Content;

namespace Assets.Scripts.Common
{
    public interface IGame
    {
        ControllerContainer ControllerContainer { get; }
        PrefabsContent PrefabsContent { get; }
        DescriptionsContent DescriptionContent { get; }
    }
}