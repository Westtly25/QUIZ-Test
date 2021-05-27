using UnityEngine;
using QUIZ.EvetsSO;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private float fadeSpeed = 2f;
    [SerializeField] private Image background;
    [SerializeField] private Canvas canvas;

    [Header("Custom Scriptable Events")]
    [SerializeField] private VoidEventSO OnLoadingEventSO;
    
    private void OnEnable()
    {
        OnLoadingEventSO.OnEventRised += Show;
    }
   
    private void OnDisable()
    {
        OnLoadingEventSO.OnEventRised -= Show;
    }

    private void Awake()
    {
        background = GetComponent<Image>();
        canvas = GetComponent<Canvas>();
        
        canvas.enabled = false;
        background.raycastTarget = false;
    }

    private void Show()
    {
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        canvas.enabled = true;
        background.raycastTarget = true;

        background.DOFade(1f, fadeSpeed).From().SetEase(Ease.InOutBack);

        yield return new WaitForSeconds(fadeSpeed);
        
        canvas.enabled = false;
        background.raycastTarget = false;


        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(0);
    }
}
