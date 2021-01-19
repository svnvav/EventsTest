
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Plarium.VGO.Practice
{
    public class GameEventRaiser : MonoBehaviour
    {
        public GameEventSO GameEventSo;

        public int Iterations = 1000000;

        public Text _soEventTestLabel;
        public Text _unityEventTestLabel;
        public Text _csEventTestLabel;
        public Text _sendMessageTestLabel;
        
        private Stopwatch _stopwatch;

        private void Start()
        {
            _stopwatch = new Stopwatch();
        }

        public void RaiseAll()
        {
            RaiseSO();
            RaiseUnityEvent();
            RaiseCsEvent();
            RaiseSendMessage();
        }

        public void RaiseSO()
        {
            _stopwatch.Restart();
            for (int i = 0; i < Iterations; ++i)
            {
                GameEventSo.Raise();
            }
            _stopwatch.Stop();
            _soEventTestLabel.text = _stopwatch.Elapsed.ToString();
        }
        
        public void RaiseUnityEvent()
        {
            _stopwatch.Restart();
            for (int i = 0; i < Iterations; ++i)
            {
                GameEventSingleton.Instance.RaiseUnityEvent();
            }
            _stopwatch.Stop();
            _unityEventTestLabel.text = _stopwatch.Elapsed.ToString();
        }
        
        public void RaiseCsEvent()
        {
            _stopwatch.Restart();
            for (int i = 0; i < Iterations; ++i)
            {
                GameEventSingleton.Instance.RaiseCsEvent();
            }
            _stopwatch.Stop();
            _csEventTestLabel.text = _stopwatch.Elapsed.ToString();
        }
        
        public void RaiseSendMessage()
        {
            _stopwatch.Restart();
            for (int i = 0; i < Iterations; i++)
            {
                var listeners = FindObjectsOfType<GameEventListener>();
                for (int j = 0, jlen = listeners.Length; j < jlen; ++j)
                {
                    listeners[j].SendMessage("OnEventRaised");
                }
            }
            _stopwatch.Stop();
            _sendMessageTestLabel.text = _stopwatch.Elapsed.ToString();
        }
    }
}