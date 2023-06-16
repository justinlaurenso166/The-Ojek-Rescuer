using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public GameObject skipButton;
    public static bool alreadyWatchCutscene = false;
    void Start()
    {
        Invoke("ChangeScene", 61f);
        if(alreadyWatchCutscene)
        {
            skipButton.SetActive(true);
        }
    }

    public void ChangeScene()
    {
        alreadyWatchCutscene = true;
        SceneManager.LoadScene("Level_Selection");
    }
}
