using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtilityExample : MonoBehaviour
{
    //JsonUtility 장점: 매우 간단
    //JsonUtility 단점: 기본 데이터형, List, Array만 지원
    //-Dictionary, Vector, 직접 생성한 클래스 등의 타입 지원 X
    //-직접 생성한 클래스에 대해 사용하기 위해선 [System.Serializable]을 붙여줘야 사용 가능
    //-Dictionary를 Serialize하기 위해선 외부 라이브러리를 사용
    private void Start()
    {
        JsonTestClass jTest1 = new JsonTestClass();
        string jsonData1 = JsonUtility.ToJson(jTest1);//Json화 = 직렬화 = 오브젝트 -> 텍스트
        Debug.Log(jsonData1);

        JsonTestClass jTest2 = JsonUtility.FromJson<JsonTestClass>(jsonData1);//역Json화 = 역직렬화 = 텍스트 -> 오브젝트
        jTest2.Print();

        JsonVector jVector = new JsonVector();
        string jsonData2 = JsonUtility.ToJson(jVector);
        Debug.Log(jsonData2);

        GameObject obj = new GameObject();
        var test1 = obj.AddComponent<TestMono>();
        test1.i = 100;
        test1.v3 /= 10;
        obj.AddComponent<TestMono>();
        string jsonData3 = JsonUtility.ToJson(obj.GetComponent<TestMono>());
        Debug.Log(jsonData3);

        //문제 발생
        //JsonUtility.FromJson<TestMono>(jsonData3);
        //문제해결
        GameObject obj2 = new GameObject();
        JsonUtility.FromJsonOverwrite(jsonData3, obj2.AddComponent<TestMono>());
    }
}
