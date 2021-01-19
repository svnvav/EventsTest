
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Plarium.VGO.Practice
{
    public class GameEventSingleton : MonoBehaviour
    {
        public static GameEventSingleton Instance => _instance;
        private static GameEventSingleton _instance;

        public UnityEvent UnityEvent;
        public event Action CsEvent;

        private void Awake()
        {
            _instance = this;
            UnityEvent = new UnityEvent();
        }

        public void RaiseUnityEvent()
        {
            UnityEvent.Invoke();
        }

        public void RaiseCsEvent()
        {
            CsEvent?.Invoke();
        }
    }
}