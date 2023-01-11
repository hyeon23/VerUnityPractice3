using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//2020 이상 버전에선 이럴 필요 없어짐
//[System.Serializable]
//public class UnityEventInt : UnityEvent<int>
//{

//}

public class Practice : MonoBehaviour
{
    //Action = Event
    //엑션은 불편한 이벤트이다.
    //Addlistener 지원 X = += or -=으로 직접등록해야 함
    //보통 스크립트 내부에서만 사용되는 액션으로 사용

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
