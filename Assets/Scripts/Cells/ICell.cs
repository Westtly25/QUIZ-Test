using QUIZ.Tasks;

namespace QUIZ.Cells
{
    public interface ICell
    {
        TaskSO GetTask();
        void EaseInBounce();
        void Bounce();
    }
}