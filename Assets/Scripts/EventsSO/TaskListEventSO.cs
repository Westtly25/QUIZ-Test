using UnityEngine;
using System.Collections.Generic;
using System;
using QUIZ.Tasks;

namespace QUIZ.EvetsSO
{
    [CreateAssetMenu(fileName = "New Task List Event SO", menuName = "Quiz Test/Scriptable Events/TaskListEventSO", order = 0)]
    public class TaskListEventSO : ScriptableObject
    {
        public event Action<List<TaskSO>> OnEventRised;

        public void RisedEvent(List<TaskSO> value)
        {
            if(OnEventRised != null)
            {
                Debug.Log($"Task List EventSO triggered {value.Count}");
                OnEventRised.Invoke(value);
            }
        } 
    }
}