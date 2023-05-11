using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private void Awake()
    {

        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            DestroyMusic();
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void DestroyMusic()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Tutorial")
        {
            DestroyMusic();
        }
    }

}
