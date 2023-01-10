using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SingletoneComponent : MonoBehaviour
{
    //AddComponent<SingletoneComponent>()�� ���� �ش� ������Ʈ�� �����ؾ� ��
    //�̹� �����Ǿ��ų� Instantiate()�� ���� ������ ��찡 ������ �ϴ� C#ó�� �����ڸ� private �����ϴ� �� ������ �ܺο��� �ߺ��� ��ü ���� �Ұ�

    private static SingletoneComponent instance;
    //static ���� ������ SingletoneComponent ��ü�� ��� ��� ��ü�� ����
    //instance�� ����ִٸ�, �������� ������ ��ü�� ���ٴ� �ǹ� --> ��ü ����
    //instance�� �����Ѵٸ�, ������ ������� ������ ��ü��� �ǹ� --> ���� ��ü �ı�
    //�ش� instance�� private���� ���������ν� �ܺο��� �Ժη� ������ �� ���� �� ���ϼ��� Ȯ��

    public static SingletoneComponent Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SingletoneComponent>();
                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    var newObj = new GameObject().AddComponent<SingletoneComponent>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        var objs = FindObjectsOfType<SingletoneComponent>();
        if(objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    //Singletone ���� �����
    //����: �ſ� ��
    //����: Singletone ������ ���� Ŭ������ ���������� Ŀ��, �ڵ� ���⼺�� ������
}
