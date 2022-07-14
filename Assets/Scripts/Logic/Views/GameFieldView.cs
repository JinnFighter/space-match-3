using Assets.Scripts.Common;
using UnityEngine;

namespace Assets.Scripts.Logic.Views
{
    public class GameFieldView : MonoBehaviour
    {
        [SerializeField] private FlexibleGridLayout _layout;

        public void SetWidth(int width) => _layout.constrainChildrenSizeToSizeAtCount = width;
    }
}