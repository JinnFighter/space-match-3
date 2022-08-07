using Leopotam.Ecs;

namespace Assets.Scripts.Logic.Extensions
{
    public static class EcsExtensions
    {
        public static void SendMessage<T>(this EcsWorld world) where T : struct
        {
            var entity = world.NewEntity();
            entity.Get<T>();
        }
    }
}