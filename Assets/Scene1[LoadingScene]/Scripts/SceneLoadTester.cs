using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Method1("Loading Scene")
            //LoadingSceneController.LoadScene("Scene2");

            //Method2("Loading Panel = Fadein & Fadeout")
            LoadingUISceneController.Instance.LoadScene("Scene2");
        }
    }
}
