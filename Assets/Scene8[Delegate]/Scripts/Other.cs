using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    private void Start()
    {
        var p = FindObjectOfType<Practice>();
        p.OnInputSpace.AddListener(Space);//�ڵ�� ���
    }
    public void Space()
    {
        Debug.Log("�����̽�!");
    }
}
