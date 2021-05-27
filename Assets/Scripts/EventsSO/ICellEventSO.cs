using UnityEngine;
using System;
using QUIZ.Tasks;
using QUIZ.Cells;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New ICell Event SO", menuName = "Quiz Test/Scriptable Events/ICellEventSO", order = 0)]
    public class ICellEventSO : ScriptableObject, IEvent<ICell>
    {
        public event Action<ICell> OnEventRised;

        public void RisedEvent(ICell value)
        {
            if(OnEventRised != null)
            {
                OnEventRised.Invoke(value);
            }
        } 
    }
}