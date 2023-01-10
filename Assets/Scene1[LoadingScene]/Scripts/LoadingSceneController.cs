using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    //static 선언 필수
    //-Loading Scene으로 넘어오지 않아서 LoadingSceneController가 부착된 게임 오브젝트가 없는 상황임에도 LoadingSceneController의 클래스명으로 호출해 사용 가능
    static string nextScene;

    [SerializeField]
    Image progressBar;

    public static void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
    
    void Start()
    {
        //Static으로 선언된 함수 내부에선 Static으로 선언되지 않은 일반 변수 or 함수는 바로 호출 불가능
        //Static으로 선언된 함수 내부에선 Static으로 선언된 변수 or 함수만 바로 호출 가능
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSceneProcess()
    {
        //SceneManager.LoadScene()은 동기방식으로 씬을 다 불러오기 전까지 다른 일을 할 수 없음
        //SceneManager.LoadSceneAsync(params)은 비동기방식으로 씬을 다 불러오기 전에 다른 일을 할 수 있음
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        //씬을 비동기로 불러들일 때, 씬의 로딩이 끝나면, 자동으로 불러온 씬으로 이동할 것을 false로 설정
        //-씬을 90%까지 로딩 수행
        //그냥 true로 두어도 되지만 false로 바꾼 이유 두가지
        //1. 생각보다 Scene loading 속도가 빠를 수 있음
        //-Scene Loading이 Object Loading보다 빠르면 플레이어에게 이상한 화면이 보여질 수 있음
        //-따라서 Fake Loading을 넣어주는 것
        //2. Loading 화면에서 불러오는 것이 Scene만 있는 것이 아님
        //-Volume이 큰 게임을 만들면 asset bundle로 나눠 빌드를 하고 asset bundle로 읽는데, 이에서 문제가 발생 가능해 false로 설정

        float timer = 0f;
        while (!op.isDone)//씬 로딩이 끝나지 않은 경우
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
                if(progressBar.fillAmount >= 1)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }

    }
}
