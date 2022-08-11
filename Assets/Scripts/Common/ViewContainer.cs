using UnityEngine;

namespace Assets.Scripts.Common
{
    public class ViewContainer : MonoBehaviour
    {
        [field: SerializeField] public Canvas GameplayCanvas { get; private set; }
        [field: SerializeField] public Canvas UiCanvas { get; private set; }
        [field: SerializeField] public Canvas PopupCanvas { get; private set; }
    }
}