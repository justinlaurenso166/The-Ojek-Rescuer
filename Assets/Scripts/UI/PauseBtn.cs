using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBtn : MonoBehaviour
{
    public Button pauseButton; // Tombol pause yang akan digunakan
    public GameObject pausePanel; // Panel pause yang akan ditampilkan saat tombol pause diklik

    private bool isPaused = false; // Status pause

    private void Start()
    {
        pauseButton.onClick.AddListener(TogglePause); // Menambahkan listener saat tombol pause diklik
    }

    private void TogglePause()
    {
        isPaused = !isPaused; // Mengubah status pause

        if (isPaused)
        {
            Debug.Log("Pause");
            Time.timeScale = 0f; // Menghentikan waktu (pause game)
            pausePanel.SetActive(true); // Menampilkan panel pause
        }
        else
        {
            Time.timeScale = 1f; // Mengembalikan waktu ke kecepatan normal (resume game)
            pausePanel.SetActive(false); // Menyembunyikan panel pause
        }
    }
}
