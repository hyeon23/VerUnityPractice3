using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    private void Start()
    {
        ////�ڵ�� ���
        //var p = FindObjectOfType<Practice>();
        //p.OnInputSpace.AddListener(Space);
    }
    public void Space()
    {
        Debug.Log("�����̽�!");
    }

    public void SpaceInt(int integer)
    {
        Debug.Log("�����̽�!" + integer);
    }
}
