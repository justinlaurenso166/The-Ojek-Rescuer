using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public GameObject pauseMenu; // Panel yang berisi menu pause
    public GameObject objective;
    public static GameObject objectivee;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        objectivee = objective;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            PauseGame();
        }
    }

    // Method untuk mengaktifkan panel pause dan menghentikan waktu
    public void PauseGame()
    {
        objective.SetActive(false);
        AudioListener.pause = true;
        Time.timeScale = 0f; // Waktu dihentikan
        pauseMenu.SetActive(true); // Panel pause aktif
    }
}
