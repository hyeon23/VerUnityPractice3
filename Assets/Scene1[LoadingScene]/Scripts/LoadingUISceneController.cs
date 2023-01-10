using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LoadingUISceneController : MonoBehaviour
{
    private static LoadingUISceneController instance;
    public static LoadingUISceneController Instance
    {
        get
        {
            if(instance == null)
            {
                var obj = FindObjectOfType<LoadingUISceneController>();
                if(obj != null)
                {
                    instance = obj;
                }
                else
                {
                    instance = Create();
                }
            }
            return Instance;
        }
    }

    private static LoadingUISceneController Create()
    {
        return Instantiate(Resources.Load<LoadingUISceneController>("LoadingUI"));
    }

    private void Awake()
    {
        if(Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField]
    private CanvasGroup canvasGroup;

    [SerializeField]
    private Image progressBar;

    private string loadSceneName;

    public void LoadScene(string sceneName)
    {
        gameObject.SetActive(true);
        //Scene 로딩이 끝나는 순간

        //씬 로딩 완료 콜백함수 등록
        //Crtl + . = 
        SceneManager.sceneLoaded += OnSceneLoaded;
        loadSceneName = sceneName;
        StartCoroutine(loadSceneProcess());
    }

    private IEnumerator loadSceneProcess()
    {
        progressBar.fillAmount = 0f;
        yield return StartCoroutine(Fade(true));

        AsyncOperation op = SceneManager.LoadSceneAsync(loadSceneName);
        op.allowSceneActivation = false;

        float timer = 0f;
        while (!op.isDone)
        {
            yield return null;
            if(op.progress < 0.9f)
            {
                progressBar.fillAmount = op.progress;
            }
            else
            {
                timer += Time.unscaledDeltaTime;
                progressBar.fillAmount = Mathf.Lerp(0.9f, 1f, timer);
                if(progressBar.fillAmount >= 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }

    private IEnumerator Fade(bool isFade)
    {
        float timer = 0f;
        while(timer <= 1f)
        {
            yield return null;
            timer += Time.unscaledDeltaTime * 3f;
            canvasGroup.alpha = isFade ? Mathf.Lerp(0f, 1f, timer) : Mathf.Lerp(1f, 0f, timer);//Fade In & Fade Out 구현
        }

        if (!isFade)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnSceneLoaded(Scene LoadedScene, LoadSceneMode arg1)
    {
        if(LoadedScene.name == loadSceneName)
        {
            StartCoroutine(Fade(false));
            //씬 로딩 완료 콜백함수 제거
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}
