using UnityEngine;
using System;
using QUIZ.Tasks;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New Task Event SO", menuName = "Quiz Test/Scriptable Events/TaskEventSO", order = 0)]
    public class TaskEventSO : ScriptableObject, IEvent<TaskSO>
    {
        public event Action<TaskSO> OnEventRised;

        public void RisedEvent(TaskSO value)
        {
            if(OnEventRised != null)
            {
                OnEventRised.Invoke(value);
            }
        } 
    }
}