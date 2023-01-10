using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoadTester : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadingSceneController.LoadScene("Scene2");
        }
    }
}
