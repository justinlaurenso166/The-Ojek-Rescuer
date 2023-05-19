using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    public GameObject pauseMenu;
    // Method untuk menonaktifkan panel pause dan melanjutkan waktu
    public void ResumeGame()
    {
        PausePanel.objectivee.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1f; // Waktu dilanjutkan
        pauseMenu.SetActive(false); // Panel pause dinonaktifkan
    }
}
