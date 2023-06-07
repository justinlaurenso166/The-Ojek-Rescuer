using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;

    private void Awake()
    {
        tutorialPanel.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tutorialPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
    }

    public void OpenGuide()
    {
        Time.timeScale = 0;
        tutorialPanel.SetActive(true);
    }

    public void CloseGuide()
    {
        Time.timeScale = 1;
        tutorialPanel.SetActive(false);
    }
}
