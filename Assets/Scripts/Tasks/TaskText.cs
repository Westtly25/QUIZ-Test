using UnityEngine;
using UnityEngine.UI;
using QUIZ.EvetsSO;
using DG.Tweening;
using System.Collections;

namespace QUIZ.Tasks
{
    public class TaskText : MonoBehaviour
    {
        [Header("Text Variable")]
        [SerializeField] private Text text;

        [Header("Custom Scriptable Event")]
        [SerializeField] private StringEventSO OnTextSet;

        private void OnEnable()
        {
            OnTextSet.OnEventRised += SetTaskText;
        }

        private void OnDisable()
        {
            OnTextSet.OnEventRised -= SetTaskText;
        }

        private void Awake()
        {
            text = GetComponent<Text>();

            FadeText();
        }

        private void SetTaskText(string text)
        {
            this.text.text = $"Find {text}";
        }

        private void FadeText()
        {
            text.DOFade(1f, 1f).SetEase(Ease.InOutExpo);
        }
    }
}