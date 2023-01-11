using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonVector
{
    public Vector3 vector3 = new Vector3(3, 3, 3);
}

public class JsonTestClass
{
    public int i;
    public float f;
    public bool b;
    public string str;
    public int[] iArray;
    public List<int> iList = new List<int>();
    public Dictionary<string, float> fDictionary = new Dictionary<string, float>();
    public IntVector2 iVector2;

    public JsonTestClass()
    {
        i = 10;
        f = 99.9f;
        b = true;
        str = "JSON Test String";
        iArray = new int[] { 1, 3, 5, 7, 9 };

        for (int index = 0; index < 5; index++)
        {
            iList.Add(2 * index);
        }

        fDictionary.Add("PIE", Mathf.PI);
        fDictionary.Add("Epsilon", Mathf.Epsilon);
        fDictionary.Add("Sqrt(2)", Mathf.Sqrt(2));

        iVector2 = new IntVector2(3, 2);
    }

    public void Print()
    {
        Debug.Log(i);
        Debug.Log(f);
        Debug.Log(b);
        Debug.Log(str);

        for (int i = 0; i < iArray.Length; i++)
        {
            Debug.Log(iArray[i]);
        }
        for (int i = 0; i < iList.Count; i++)
        {
            Debug.Log(iList[i]);
        }
        foreach (var data in fDictionary)
        {
            Debug.Log(data.Key + " " + data.Value);
        }
        Debug.Log(iVector2.x + " " + iVector2.y);
    }

    public class IntVector2
    {
        public int x;
        public int y;

        public IntVector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}

public class NewtonsoftJsonExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //1. NewtonsoftJsonExample
        //JsonTestClass jTest1 = new JsonTestClass();
        //string jsonData = JsonConvert.SerializeObject(jTest1);//직렬화: 오브젝트 -> 텍스트
        //Debug.Log(jsonData);

        //JsonTestClass jTest2 = JsonConvert.DeserializeObject<JsonTestClass>(jsonData);//역 직렬화: 테스트 -> 오브젝트
        //jTest2.Print();

        //GameObject obj = new GameObject();
        //obj.AddComponent<TestMono>();
        //Debug.Log(JsonConvert.SerializeObject(obj.GetComponent<TestMono>()));

        //JsonVector jVector = new JsonVector();
        //JsonSerializerSettings settings = new JsonSerializerSettings();
        //settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        //Debug.Log(JsonConvert.SerializeObject(jVector, settings));

        //JSON 길이나 용량이 늘어남 & 자가 루프 참조로 자가 참조
        //매우 불편해서 해당 방식으로 사용 X

        //2. Unity Json Utility 방식 애용

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
