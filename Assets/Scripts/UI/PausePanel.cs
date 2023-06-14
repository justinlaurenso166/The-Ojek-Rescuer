using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private Guide guide;
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
        if (Input.GetKeyDown(KeyCode.Escape) && !guide.gameObject.activeInHierarchy)
        {
            PauseGame();
        }

        if (Input.GetKey(KeyCode.H))
        {
            guide.OpenGuide();
        }

        if (SceneManager.GetActiveScene().name == "Tutorial" || SceneManager.GetActiveScene().name == "TutorialAPAR")
        {
            guide.OpenGuide();
        }
    }

    // Method untuk mengaktifkan panel pause dan menghentikan waktu
    public void PauseGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f; // Waktu dihentikan
        objective.SetActive(false);
        AudioListener.pause = true;
        pauseMenu.SetActive(true); // Panel pause aktif
    }
}
