using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class JsonSaveLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Json Data File 생성 & 저장
        FileStream streamWrite = new FileStream(Application.dataPath + "/test.json", FileMode.OpenOrCreate);
        JsonTestClass jTest1 = new JsonTestClass();
        string jsonData1 = JsonConvert.SerializeObject(jTest1);
        byte[] data1 = Encoding.UTF8.GetBytes(jsonData1);
        streamWrite.Write(data1, 0, data1.Length);
        streamWrite.Close();

        //Json File에서 읽어들이기
        FileStream streamRead = new FileStream(Application.dataPath + "/test.json", FileMode.Open);
        byte[] data2 = new byte[streamRead.Length];
        streamRead.Read(data2, 0, data2.Length);
        streamRead.Close();
        string jsonData2 = Encoding.UTF8.GetString(data2);
        JsonTestClass jTest2 = JsonConvert.DeserializeObject<JsonTestClass>(jsonData2);
        jTest2.Print();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
