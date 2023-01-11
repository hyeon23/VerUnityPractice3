using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonUtilityExample : MonoBehaviour
{
    //JsonUtility ����: �ſ� ����
    //JsonUtility ����: �⺻ ��������, List, Array�� ����
    //-Dictionary, Vector, ���� ������ Ŭ���� ���� Ÿ�� ���� X
    //-���� ������ Ŭ������ ���� ����ϱ� ���ؼ� [System.Serializable]�� �ٿ���� ��� ����
    //-Dictionary�� Serialize�ϱ� ���ؼ� �ܺ� ���̺귯���� ���
    private void Start()
    {
        JsonTestClass jTest1 = new JsonTestClass();
        string jsonData1 = JsonUtility.ToJson(jTest1);//Jsonȭ = ����ȭ = ������Ʈ -> �ؽ�Ʈ
        Debug.Log(jsonData1);

        JsonTestClass jTest2 = JsonUtility.FromJson<JsonTestClass>(jsonData1);//��Jsonȭ = ������ȭ = �ؽ�Ʈ -> ������Ʈ
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

        //���� �߻�
        //JsonUtility.FromJson<TestMono>(jsonData3);
        //�����ذ�
        GameObject obj2 = new GameObject();
        JsonUtility.FromJsonOverwrite(jsonData3, obj2.AddComponent<TestMono>());
    }
}
