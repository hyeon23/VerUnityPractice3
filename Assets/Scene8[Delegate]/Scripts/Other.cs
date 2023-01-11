using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    private void Start()
    {
        ////코드로 등록
        //var p = FindObjectOfType<Practice>();
        //p.OnInputSpace.AddListener(Space);
    }
    public void Space()
    {
        Debug.Log("스페이스!");
    }

    public void SpaceInt(int integer)
    {
        Debug.Log("스페이스!" + integer);
    }
}
