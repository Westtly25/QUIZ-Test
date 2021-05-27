using UnityEngine;

namespace QUIZ.Game_Modes
{
    [CreateAssetMenu(fileName = "New Game Mode", menuName = "Quiz Test/Modes/Mode", order = 0)]
    public class Mode : ScriptableObject
    {
        [Header("Amount Cells Per Game Mode")]
        [SerializeField] private int cellsAmount = 3;

        public int CellsAmount => cellsAmount;
    }
}