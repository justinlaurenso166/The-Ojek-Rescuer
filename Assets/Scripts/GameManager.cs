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
    public GameObject panelMenangBintang1;
    public GameObject panelMenangBintang2;
    public GameObject panelMenangBintang3;
    public GameObject panelKalah;

    [Header("Game Menu")]
    public GameObject panelMenu;

    [Header("Settings")]
    public GameObject panelSetting;

    [Header("PanelShow")]
    public GameObject creditsPanel;

    [Header("PanelKeyBindings")]
    public GameObject keyBindingsPanel;

    public static bool doneLevel1 = false;
    public static bool doneLevel2 = false;

    [Header("Level 2")]
    public Button level2Button;
    public Button level2Panel;

    [Header("Level 3")]
    public Button level3Button;
    public Button level3Panel;

    private Color interactableColor = Color.white;
    public int Target;

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
        Time.timeScale = 1f;
        AudioListener.pause = false;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (score == Target)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            panelMenangBintang3.SetActive(true);

            if (SceneManager.GetActiveScene().name == "Level_1")
            {
                doneLevel1 = true;
            }
            if (SceneManager.GetActiveScene().name == "Level_2")
            {
                doneLevel2 = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            score = 3;
        }

        if (level2Button != null && level2Panel != null)
        {
            if (doneLevel1 == false)
            {
                level2Button.interactable = false;
                Image buttonImage = level2Panel.GetComponent<Image>();
                Color color;
                if (ColorUtility.TryParseHtmlString("#9A9A9A", out color))
                {
                    buttonImage.color = color;
                }
            }

            if (doneLevel1 == true)
            {
                level2Button.interactable = true;
                Image buttonImage = level2Panel.GetComponent<Image>();
                buttonImage.color = interactableColor;
            }

        }

        if (level3Button != null && level3Panel != null)
        {
            if (doneLevel2 == false)
            {

                level3Button.interactable = false;
                Image buttonImage = level3Panel.GetComponent<Image>();
                Color color;
                if (ColorUtility.TryParseHtmlString("#9A9A9A", out color))
                {
                    buttonImage.color = color;
                }
            }

            if (doneLevel2 == true)
            {
                level3Button.interactable = true;
                Image buttonImage = level3Panel.GetComponent<Image>();
                buttonImage.color = interactableColor;
            }
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

    void closePanel()
    {
        panelMenangBintang1.SetActive(false);
        panelMenangBintang2.SetActive(false);
        panelMenangBintang3.SetActive(false);
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
        if (panelMenu != null) panelMenu.SetActive(false);
        panelSetting.SetActive(true);
    }

    public void closeSetting()
    {
        panelSetting.SetActive(false);
        if (panelMenu != null) panelMenu.SetActive(true);
    }

    public void retryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void timeOver()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;

        if (score == 1)
        {
            panelMenangBintang1.SetActive(true);
        }
        else if (score == 2)
        {
            panelMenangBintang2.SetActive(true);
        }
        else if (score == 0)
        {
            panelKalah.SetActive(true);

        }
    }

    public void openKeyBindings()
    {
        panelSetting.SetActive(false);
        keyBindingsPanel.SetActive(true);
    }

    public void closeKeyBindings()
    {
        keyBindingsPanel.SetActive(false);
        panelSetting.SetActive(true);
    }

    public void exitGame()
    {
        Application.Quit();
    }

}
