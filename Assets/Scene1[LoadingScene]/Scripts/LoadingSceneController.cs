using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingSceneController : MonoBehaviour
{
    //static ���� �ʼ�
    //-Loading Scene���� �Ѿ���� �ʾƼ� LoadingSceneController�� ������ ���� ������Ʈ�� ���� ��Ȳ�ӿ��� LoadingSceneController�� Ŭ���������� ȣ���� ��� ����
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
        //Static���� ����� �Լ� ���ο��� Static���� ������� ���� �Ϲ� ���� or �Լ��� �ٷ� ȣ�� �Ұ���
        //Static���� ����� �Լ� ���ο��� Static���� ����� ���� or �Լ��� �ٷ� ȣ�� ����
        StartCoroutine(LoadSceneProcess());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadSceneProcess()
    {
        //SceneManager.LoadScene()�� ���������� ���� �� �ҷ����� ������ �ٸ� ���� �� �� ����
        //SceneManager.LoadSceneAsync(params)�� �񵿱������� ���� �� �ҷ����� ���� �ٸ� ���� �� �� ����
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        //���� �񵿱�� �ҷ����� ��, ���� �ε��� ������, �ڵ����� �ҷ��� ������ �̵��� ���� false�� ����
        //-���� 90%���� �ε� ����
        //�׳� true�� �ξ ������ false�� �ٲ� ���� �ΰ���
        //1. �������� Scene loading �ӵ��� ���� �� ����
        //-Scene Loading�� Object Loading���� ������ �÷��̾�� �̻��� ȭ���� ������ �� ����
        //-���� Fake Loading�� �־��ִ� ��
        //2. Loading ȭ�鿡�� �ҷ����� ���� Scene�� �ִ� ���� �ƴ�
        //-Volume�� ū ������ ����� asset bundle�� ���� ���带 �ϰ� asset bundle�� �дµ�, �̿��� ������ �߻� ������ false�� ����

        float timer = 0f;
        while (!op.isDone)//�� �ε��� ������ ���� ���
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
