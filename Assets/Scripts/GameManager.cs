using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject panelMenang;

    [Header("Game Menu")]
    public GameObject panelMenu;

    [Header("Settings")]
    public GameObject panelSetting;

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
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {  
        if(scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if(score == 3)
        {
            Time.timeScale = 0;
            panelMenang.SetActive(true);
        }
    }

    void closePanel()
    {
        panelMenang.SetActive(false);
    }

    public void goToAnotherScene(string scene){
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
}
