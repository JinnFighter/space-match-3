using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic.Views
{
    public class TileView : MonoBehaviour, IPointerClickHandler
    {
        [field: SerializeField] public BallView BallView { get; private set; }

        public void OnPointerClick(PointerEventData eventData) 
        {
            ClickedEvent?.Invoke();
        }

        public event Action ClickedEvent;
    }
}