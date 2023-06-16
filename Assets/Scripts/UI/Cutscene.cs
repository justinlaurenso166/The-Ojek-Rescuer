using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("ChangeScene", 61f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Level_Selection");
    }
}
