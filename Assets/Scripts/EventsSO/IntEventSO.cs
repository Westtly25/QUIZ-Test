using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New Int Event SO", menuName = "Quiz Test/Scriptable Events/IntEventSO", order = 0)]
    public class IntEventSO : ScriptableObject, IEvent<int>
    {
        public event Action<int> OnEventRised;

        public void RisedEvent(int value)
        {
            if(OnEventRised != null)
            {
                OnEventRised.Invoke(value);
            }
        } 
    }
}
