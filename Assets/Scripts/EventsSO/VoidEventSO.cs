using UnityEngine;
using System;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New Void Event SO", menuName = "Quiz Test/Scriptable Events/VoidEventSO", order = 0)]
    public class VoidEventSO : ScriptableObject
    {
        public event Action OnEventRised;

        public void RisedEvent()
        {
            if(OnEventRised != null)
            {
                OnEventRised.Invoke();
            }
        } 
    }
}
