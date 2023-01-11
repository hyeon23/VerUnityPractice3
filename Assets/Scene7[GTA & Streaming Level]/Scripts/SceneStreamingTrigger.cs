using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneStreamingTrigger : MonoBehaviour
{
    [SerializeField]
    private string streamTargetScene;
    [SerializeField]
    private string triggerOwnScene;
    private IEnumerator LoadStreamingTargetScene()
    {
        var targetScene = SceneManager.GetSceneByName(streamTargetScene);
        if (!targetScene.isLoaded)
        {
            var op = SceneManager.LoadSceneAsync(streamTargetScene, LoadSceneMode.Additive);

            while (!op.isDone)
            {
                yield return null;
            }
        }
    }

    private IEnumerator UnloadStreamingTargetScene()
    {
        var targetScene = SceneManager.GetSceneByName(streamTargetScene);
        if (targetScene.isLoaded)
        {
            var currentScene = SceneManager.GetSceneByName(triggerOwnScene);
            SceneManager.MoveGameObjectToScene(GameObject.FindGameObjectWithTag("GameController"), currentScene);

            var op = SceneManager.UnloadSceneAsync(streamTargetScene);
            while (!op.isDone)
            {
                yield return null;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var dir = Vector3.Angle(transform.forward, other.transform.position - transform.position);
            
            if(dir < 90f)//플레이어 이동방향 & Scene Streaming Trigger방향이 90도보다 작으면 Load
            {
                StartCoroutine(LoadStreamingTargetScene());
                
            }
            else//플레이어 이동방향 & Scene Streaming Trigger방향이 90도보다 크면 Unload
            {
                StartCoroutine(UnloadStreamingTargetScene());
            }
            

        }
    }
}
