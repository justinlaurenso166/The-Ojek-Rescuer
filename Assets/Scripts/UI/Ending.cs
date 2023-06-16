using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    private void Start() {
        Time.timeScale = 1f;    
    }

    public  void ChangeScene()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
