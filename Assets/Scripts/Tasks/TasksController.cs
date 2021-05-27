using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QUIZ.Game_Modes;
using QUIZ.EvetsSO;
using QUIZ.Cells;

namespace QUIZ.Tasks
{
    public class TasksController : MonoBehaviour
    {
        [SerializeField] private TasksContainerSO tasksContainer;

        [Header("Current Active Task")]
        [SerializeField] private TaskVariableSO activeTaskVariableSO;

        [Header("List Saved Activated Tasks")]
        [SerializeField] private List<TaskSO> savedActiveTaskSO;

        [Header("Current List Selected Tasks")]
        [SerializeField] private List<TaskSO> tasksList;

        [Header("List Of All Tasks Types")]
        [SerializeField] private TaskTypeSO[] taskTypeSOList;

        [Header("Custom Scriptable Events")]
        [SerializeField] private ModeEventSO OnModeActivated;
        [SerializeField] private StringEventSO OnTaskTitleSet;
        [SerializeField] private VoidEventSO OnTaskCompleted;
        [SerializeField] private VoidEventSO OnRestartGame;
        [SerializeField] private TaskListEventSO OnTaskListSet;
        [SerializeField] private VoidEventSO StartNewGameEventSO;

        private void OnEnable()
        {
            OnModeActivated.OnEventRised += Initialize;
            OnRestartGame.OnEventRised += ResetAllData;
            StartNewGameEventSO.OnEventRised += ResetAllData;
        }

        private void OnDisable()
        {
            OnModeActivated.OnEventRised -= Initialize;
            OnRestartGame.OnEventRised -= ResetAllData;
            StartNewGameEventSO.OnEventRised -= ResetAllData;
        }

        private void Awake()
        {
            tasksList = new List<TaskSO>();
            savedActiveTaskSO = new List<TaskSO>();
        }

        private void Initialize(Mode mode)
        {
            ActivateRandomTasksByMode(SetRandomTaskType(), mode.CellsAmount);

            SetRandomActiveTask();
        }

        private TaskTypeSO SetRandomTaskType()
        {
            int index = Random.Range(0, taskTypeSOList.Length);

            return taskTypeSOList[index];
        }

        private void ActivateRandomTasksByMode(TaskTypeSO taskType, int amount)
        {
            tasksList = tasksContainer.GetTasksByTypeAndAmount(taskType, amount);

            OnTaskListSet.RisedEvent(tasksList);
        }

        private void SetRandomActiveTask()
        {
            int index = Random.Range(0, tasksList.Count);

            if(CheckIfSelectedRandomTaskWasActive(tasksList[index]) && CheckIfSelectedRandomTaskMoreThenOne(tasksList[index]))
            {
                SetRandomActiveTask();
            }

            activeTaskVariableSO.ActiveTaskSO = tasksList[index];

            OnTaskTitleSet.RisedEvent(tasksList[index].TaskText);

            SaveActiveTaskToCache(activeTaskVariableSO.ActiveTaskSO);
        }

        private void SaveActiveTaskToCache(TaskSO task)
        {
            savedActiveTaskSO.Add(task);
        }

        private void ClearActiveTasksFromCache()
        {
            savedActiveTaskSO = new List<TaskSO>();
        }

        private void ClearActiveTasksList()
        {
            tasksList = new List<TaskSO>();
        }

        private void ResetAllData()
        {
            activeTaskVariableSO.ActiveTaskSO = null;
            ClearActiveTasksList();
            ClearActiveTasksFromCache();
        }

        private bool CheckIfSelectedRandomTaskWasActive(TaskSO task)
        {
            if(savedActiveTaskSO.Exists(item => item == task))
            {
                return true;
            }

            return false;
        }

        private bool CheckIfSelectedRandomTaskMoreThenOne(TaskSO task)
        {
            var list = tasksList.FindAll(item => item == task);

            Debug.Log($"Same Tasks is : {list.Count}");

            if(list.Count > 1)
            {
                return true;
            }

            return false;
        }
    }
}