using UnityEngine;
using System;
using QUIZ.Tasks;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New Task Type Event SO", menuName = "Quiz Test/Scriptable Events/TaskTypeEventSO", order = 0)]
    public class TaskTypeEventSO : ScriptableObject, IEvent<TaskTypeSO>
    {
        public event Action<TaskTypeSO> OnEventRised;

        public void RisedEvent(TaskTypeSO value)
        {
            if(OnEventRised != null)
            {
                OnEventRised.Invoke(value);
            }
        } 
    }
}