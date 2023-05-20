using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    [Header("Panel Game Selesai")]
    public GameObject panelMenang;
    public GameObject panelKalah;

    [Header("Game Menu")]
    public GameObject panelMenu;

    [Header("Settings")]
    public GameObject panelSetting;

    [Header("PanelShow")]
    public GameObject creditsPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        AudioListener.pause = false;
        Time.timeScale = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (score == 3)
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
            panelMenang.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            score = 3;
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    void closePanel()
    {
        panelMenang.SetActive(false);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }

    public void goToAnotherScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void openSetting()
    {
        panelMenu.SetActive(false);
        panelSetting.SetActive(true);
    }

    public void closeSetting()
    {
        panelSetting.SetActive(false);
        panelMenu.SetActive(true);
    }

    public void retryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void timeOver()
    {
        AudioListener.pause = true;
        Time.timeScale = 0f;
        panelKalah.SetActive(true);
    }
}
