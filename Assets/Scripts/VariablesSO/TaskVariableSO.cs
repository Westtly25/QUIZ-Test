using UnityEngine;
using QUIZ.Tasks;

[CreateAssetMenu(fileName = "New Task VariableSO", menuName = "Quiz Test/VariablesSO/TaskVariableSO", order = 0)]
public class TaskVariableSO : ScriptableObject
{
    [SerializeField] private TaskSO activeTaskSO;

    public TaskSO ActiveTaskSO
    { 
        get { return activeTaskSO; }
        set { activeTaskSO = value; }
    }
}