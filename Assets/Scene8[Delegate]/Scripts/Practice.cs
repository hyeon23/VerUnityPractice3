using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//2020 �̻� �������� �̷� �ʿ� ������
//[System.Serializable]
//public class UnityEventInt : UnityEvent<int>
//{

//}

public class Practice : MonoBehaviour
{
    //Action = Event
    //������ ������ �̺�Ʈ�̴�.
    //Addlistener ���� X = += or -=���� ��������ؾ� ��
    //���� ��ũ��Ʈ ���ο����� ���Ǵ� �׼����� ���

    public UnityEvent OnInputSpace;

    public UnityEvent unityEvent;
    public UnityEvent unityEventInt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnInputSpace.Invoke();
        }
    }
}
