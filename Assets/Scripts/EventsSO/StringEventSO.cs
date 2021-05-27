using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New String Event SO", menuName = "Quiz Test/Scriptable Events/StringEventSO", order = 0)]
    public class StringEventSO : ScriptableObject, IEvent<string>
    {
        public event Action<string> OnEventRised;

        public void RisedEvent(string value)
        {
            if(OnEventRised != null)
            {
                OnEventRised.Invoke(value);
            }
        } 
    }
}
