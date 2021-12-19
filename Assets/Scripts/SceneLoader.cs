using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void SceneLoad(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void SceneLoad(int time, string name)
    {
        StartCoroutine(WaitSceneLoad(time, name));
    }

    IEnumerator WaitSceneLoad(int time, string name)
    {
        yield return new WaitForSeconds(time);
        SceneLoad(name);
    }
}
