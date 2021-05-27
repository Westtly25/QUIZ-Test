using UnityEngine;
using QUIZ.EvetsSO;
using UnityEngine.UI;
using DG.Tweening;

public class RestartScreen : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private Image background;
    [SerializeField] private Canvas canvas;

    [Header("Custom Scriptable Events")]
    [SerializeField] private VoidEventSO OnRestartEventSO;
    [SerializeField] private VoidEventSO OnFadeOutEventSO;

    private void OnEnable()
    {
        OnRestartEventSO.OnEventRised += FadeIn;
        OnFadeOutEventSO.OnEventRised += FadeOut;
    }

    private void OnDisable()
    {
        OnRestartEventSO.OnEventRised -= FadeIn;
        OnFadeOutEventSO.OnEventRised -= FadeOut;
    }

    private void Awake()
    {
        background = GetComponent<Image>();
        canvas = GetComponent<Canvas>();
        
        canvas.enabled = false;
        background.raycastTarget = false;
    }

    private void FadeIn()
    {
        canvas.enabled = true;
        background.raycastTarget = true;

        background.DOFade(1f, fadeSpeed);
    }

    private void FadeOut()
    {
        canvas.enabled = false;
        background.raycastTarget = false;
    }
}
