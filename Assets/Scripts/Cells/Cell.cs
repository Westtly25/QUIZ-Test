using UnityEngine;
using UnityEngine.UI;
using QUIZ.Tasks;
using UnityEngine.EventSystems;
using System;
using DG.Tweening;

namespace QUIZ.Cells
{
    public class Cell : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, ICell
    {
        [SerializeField] private Image icon;
        [SerializeField] private Image cellBacground;
        [SerializeField] private TaskSO task;
        [SerializeField] public event Action<ICell> OnCellTaskSelected;

        private void Start()
        {
            Initialize();
            BounceCellOnAppear();
        }

        private void Initialize()
        {
            icon = this.GetComponentInChildren<Image>();
            cellBacground = this.GetComponent<Image>();
        }

        public void SetCellData(TaskSO taskSO)
        {
            task = taskSO;
            icon.sprite = taskSO.Icon;
        }

        public TaskSO GetTask()
        {
            return task;
        }

        public void EaseInBounce()
        {
            icon.transform.DOShakePosition(2f, 5f, 10);
        }

        public void Bounce()
        {
            icon.transform.DOShakePosition(2.0f, strength: new Vector3(0, 5, 0), vibrato: 2, randomness: 1, snapping: false, fadeOut: true);
        }

        public void BounceCellOnAppear()
        {
            cellBacground.DOFade(1f, 1f).SetEase(Ease.InOutExpo);
        }

        public void OnPointerClick(PointerEventData pointerEventData)
        {
            OnCellTaskSelected.Invoke(this);
        }

        public void OnPointerDown( PointerEventData eventData )
        {
        }
    
        public void OnPointerUp( PointerEventData eventData )
        {
        }
    }
}