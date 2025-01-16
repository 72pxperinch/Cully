using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void LoadSceneClassic()
    {
        Debug.Log("Loading Classic scene...");
        SceneManager.LoadScene(1);
        Debug.Log("Classic scene loaded.");
    }

    public void LoadSceneArcade()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadSceneAdventure()
    {
        SceneManager.LoadScene(3);
    }

};

