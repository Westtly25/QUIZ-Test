using UnityEngine;
using System;
using QUIZ.Game_Modes;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New Mode Event SO", menuName = "Quiz Test/Scriptable Events/ModeEventSO", order = 0)]
    public class ModeEventSO : ScriptableObject, IEvent<Mode>
    {
        public event Action<Mode> OnEventRised;

        public void RisedEvent(Mode value)
        {
            if(OnEventRised != null)
            {
                OnEventRised.Invoke(value);
            }
        } 
    }
}
