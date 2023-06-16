using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeBtn : MonoBehaviour
{
    public GameObject pauseMenu;
    // Method untuk menonaktifkan panel pause dan melanjutkan waktu
    public void ResumeGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1f; // Waktu dilanjutkan
        AudioListener.pause = false;
        // PausePanel.objectivee.SetActive(true);
        pauseMenu.SetActive(false); // Panel pause dinonaktifkan
    }
}
