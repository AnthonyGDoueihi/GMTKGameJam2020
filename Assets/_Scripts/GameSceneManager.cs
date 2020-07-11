using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    private void Awake()
    {
        GameSceneManager[] objs = FindObjectsOfType<GameSceneManager>();

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadMainMenu()
    {
        LoadLevel("0_MainMenu");
    }
}
