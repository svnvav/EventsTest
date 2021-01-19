using UnityEngine;

namespace Plarium.VGO.Practice
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEventSO _eventSo;

        private void OnEnable()
        {
            _eventSo.RegisterListener(this);
            GameEventSingleton.Instance.UnityEvent.AddListener(OnEventRaised);
            GameEventSingleton.Instance.CsEvent += OnEventRaised;
        }

        private void OnDisable()
        {
            _eventSo.UnregisterListener(this);
            GameEventSingleton.Instance.UnityEvent.RemoveListener(OnEventRaised);
            GameEventSingleton.Instance.CsEvent -= OnEventRaised;
        }

        public void OnEventRaised()
        {
        }
    }
}