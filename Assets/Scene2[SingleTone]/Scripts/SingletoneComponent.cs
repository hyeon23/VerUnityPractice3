using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SingletoneComponent : MonoBehaviour
{
    //AddComponent<SingletoneComponent>()를 통해 해당 컴포넌트를 부착해야 함
    //이미 생성되었거나 Instantiate()를 통해 생성될 경우가 존재해 일단 C#처럼 생성자를 private 선언하는 것 만으론 외부에서 중복된 객체 생성 불가

    private static SingletoneComponent instance;
    //static 선언 변수는 SingletoneComponent 객체가 몇개든 모든 객체가 공유
    //instance가 비어있다면, 정식으로 생성된 객체가 없다는 의미 --> 객체 생성
    //instance가 존재한다면, 부정한 방법으로 생성된 객체라는 의미 --> 기존 객체 파괴
    //해당 instance를 private으로 선언함으로써 외부에서 함부로 수정할 수 없게 해 유일성을 확보

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

    //Singletone 패턴 장단점
    //장점: 매우 편리
    //단점: Singletone 패턴을 가진 클래스가 기형적으로 커져, 코드 복잡성이 증가함
}
