using UnityEngine;
using System.Collections.Generic;
using System;
using QUIZ.EvetsSO;

namespace QUIZ.Game_Modes
{
    public class GameModeController : MonoBehaviour
    {
        [Header("Game Modes List")]
        [SerializeField] private ModeCell[] modeCells;

        [Header("Custom Scriptable Event")]
        [SerializeField] private ModeEventSO OnModeCompleted;
        [SerializeField] private ModeEventSO OnModeActivated;
        [SerializeField] private IntEventSO OnModeAmountCellsSet;
        [SerializeField] private VoidEventSO OnTaskCompleted;
        [SerializeField] private VoidEventSO OnGridClear;
        [SerializeField] private VoidEventSO OnRestarScreenOpen;

        private void OnEnable()
        {
            OnTaskCompleted.OnEventRised += ActivateNextMode;
        }

        private void OnDisable()
        {
            OnTaskCompleted.OnEventRised -= ActivateNextMode;
        }

        private void Start()
        {
            ActivateFirstMode();
        }

        private void ActivateFirstMode()
        {
            if(modeCells == null) { return; }

            modeCells[0].IsActive = true;

            Mode mode = modeCells[0].GetMode;
            OnModeAmountCellsSet.RisedEvent(mode.CellsAmount);
            OnModeActivated.RisedEvent(mode);
        }

        private void ResetAllModes()
        {
            foreach (ModeCell item in modeCells)
            {
                item.IsActive = false;
                item.IsCompleted = false;
            }
        }

        private void ActivateNextMode()
        {
            foreach (ModeCell item in modeCells)
            {
                if(item.IsActive)
                {
                    item.IsCompleted = true;

                    CheckCompleteAllTasks();
                }
                else if(item.IsActive == false)
                {
                    item.IsActive = true;

                    OnGridClear.RisedEvent();
                    OnModeAmountCellsSet.RisedEvent(item.GetMode.CellsAmount);
                    OnModeActivated.RisedEvent(item.GetMode);

                    break;
                }
            }
        }

        private bool CheckCompleteAllTasks()
        {
            foreach (ModeCell item in modeCells)
            {
                if(item.IsCompleted == false)
                {
                    return false;
                }
            }

            ResetAllModes();

            OnGridClear.RisedEvent();
            
            OnRestarScreenOpen.RisedEvent();
            
            return true;
        }
    }

    [Serializable]
    public class ModeCell
    {
        [SerializeField] private bool isActive = false;
        [SerializeField] private bool isCompleted = false;
        [SerializeField] private Mode mode;

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public bool IsCompleted
        {
            get { return isCompleted; }
            set { isCompleted = value; }
        }

        public Mode GetMode => mode;
    }
}