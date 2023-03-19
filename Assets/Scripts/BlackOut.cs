using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackOut : MonoBehaviour
{
    public static BlackOut instance;
    public int scene = 1;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void LoadNextLevel()
    {
        SceneManager.UnloadSceneAsync(scene);
        scene++;
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        StartCoroutine(Set(scene));
        Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = false;
    }

    public void LoadMainLevel()
    {
        if (scene != 1)
        {
            SceneManager.UnloadSceneAsync(scene);
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
            StartCoroutine(Set(1));
            Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = false;
            scene = 1;
        }      
    }

    public void ReloadScene()
    {
        Camera.main.gameObject.GetComponent<GrayscalePostprocess>().enabled = false;
        SceneManager.UnloadSceneAsync(scene);
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        StartCoroutine(Set(scene));
    }

    public IEnumerator Set(int sceneIndex)
    {
        if(sceneIndex != 0)
        {
            yield return new WaitForSeconds(.1f);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
        }
    }
}
