using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Logic.Views
{
    public class GameFieldView : MonoBehaviour
    {
        [field: SerializeField] public FlexibleGridLayout Layout{ get; private set; }

        public void SetWidth(int width) => Layout.constrainChildrenSizeToSizeAtCount = width;
    }
}