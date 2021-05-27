using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace QUIZ.Tasks
{
    [CreateAssetMenu(fileName = "Tasks ContainerSO", menuName = "Quiz Test/Tasks/TasksContainerSO", order = 0)]
    public class TasksContainerSO : ScriptableObject
    {
        [SerializeField] private TaskCell[] tasksList;

        public List<TaskSO> GetTasksByTypeAndAmount(TaskTypeSO taskType, int amount)
        {
            for (var i = 0; i < tasksList.Length; i++)
            {
                if(tasksList[i].GetTaskTypeSO == taskType)
                {
                    return GetRandomTasks(tasksList[i].GetTaskSOList, amount);
                }
            }

            return null;
        }

        public List<TaskSO> GetRandomTasks(TaskSO[] tasks, int amount)
        {
            int i = 0;
            List<TaskSO> tempTasksList = new List<TaskSO>();

            while(amount > i)
            {
                int index = UnityEngine.Random.Range(0, tasks.Length - 1);

                tempTasksList.Add(tasks[index]);
                i++;
            }

            return tempTasksList;
        }
    }

    [Serializable]
    public class TaskCell
    {
        [SerializeField] private TaskTypeSO taskTypeSO;
        [SerializeField] private TaskSO[] taskSOList;

        public TaskTypeSO GetTaskTypeSO => taskTypeSO;

        public TaskSO[] GetTaskSOList => taskSOList;
    }
}