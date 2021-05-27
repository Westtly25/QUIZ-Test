using UnityEngine;

namespace QUIZ.Tasks
{
    [CreateAssetMenu(fileName = "New TaskSO", menuName = "Quiz Test/Tasks/TaskSO", order = 0)]
    public class TaskSO : ScriptableObject
    {
        [SerializeField] private string taskText;
        [SerializeField] private Sprite icon;

        public string TaskText => taskText;

        public Sprite Icon => icon;
    }
}