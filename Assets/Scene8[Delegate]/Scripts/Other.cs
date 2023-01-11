using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    private void Start()
    {
        var p = FindObjectOfType<Practice>();
        p.OnInputSpace.AddListener(Space);//코드로 등록
    }
    public void Space()
    {
        Debug.Log("스페이스!");
    }
}
