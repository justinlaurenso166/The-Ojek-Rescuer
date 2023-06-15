using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;
using UnityEngine.SceneManagement;

public class Guide : MonoBehaviour
{
    [SerializeField] GameObject guidePanel;

    private int currentPage;
    private string stringTitle;
    private string stringText;
    private string stringPage;

    [Header("Page Content")]
    [SerializeField] TextMeshProUGUI titlePage;
    [SerializeField] TextMeshProUGUI textPage;
    [SerializeField] TextMeshProUGUI page;
    [SerializeField] GameObject nextButton;
    [SerializeField] GameObject previousButton;
    [SerializeField] VideoPlayer videoGuide;
    [SerializeField] VideoClip[] videoClip;

    private void Awake()
    {
        currentPage = 1;
        CheckCurrentPage();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (guidePanel.activeInHierarchy)
        {
            Time.timeScale = 0;
            if (Input.GetKey(KeyCode.Escape))
            {
                CloseGuide();
            }

            if (currentPage == 1)
            {

                titlePage.text = stringTitle;
                page.text = stringPage;
                textPage.text = stringText;

                previousButton.SetActive(false);
                nextButton.SetActive(true);

                videoGuide.enabled = true;
                videoGuide.clip = videoClip[currentPage - 1];

            }
            else if (currentPage == 2)
            {

                titlePage.text = stringTitle;
                page.text = stringPage;
                textPage.text = stringText;

                previousButton.SetActive(true);
                nextButton.SetActive(true);

                videoGuide.enabled = true;
                videoGuide.clip = videoClip[currentPage - 1];

            }
            else if (currentPage == 3)
            {

                titlePage.text = stringTitle;
                page.text = stringPage;
                textPage.text = stringText;

                previousButton.SetActive(true);
                nextButton.SetActive(true);

                videoGuide.enabled = true;
                videoGuide.clip = videoClip[currentPage - 1];

            }
            else if (currentPage == 4)
            {

                titlePage.text = stringTitle;
                page.text = stringPage;
                textPage.text = stringText;

                previousButton.SetActive(true);
                nextButton.SetActive(false);

                videoGuide.enabled = true;
                videoGuide.clip = videoClip[currentPage - 1];

            }
        }
    }

    public void OpenGuide()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        guidePanel.SetActive(true);
    }

    public void CloseGuide()
    {
        Cursor.visible = false;
        Time.timeScale = 1;
        guidePanel.SetActive(false);
    }

    public void NextPage()
    {
        currentPage++;
        CheckCurrentPage();
    }

    public void PreviousPage()
    {
        currentPage--;
        CheckCurrentPage();
    }

    private void CheckCurrentPage()
    {
        if (currentPage == 1)
        {
            stringTitle = "CHARACTER";
            stringPage = "1 / 4";
            stringText = "You can walk using WASD key button and move your mouse to look around.";
        }
        else if (currentPage == 2)
        {
            stringTitle = "FORKLIFT";
            stringPage = "2 / 4";
            stringText = "You can use the forklift by pressing F key button. You can upshift the forklift by pressing E key button, and the Q key button to downshift. When using a forklift, gear 1 indicates you can move forward, gear -1 indicates you can move backward, and gear 0 forklift cannot be moved.";
        }
        else if (currentPage == 3)
        {
            stringTitle = "FORKLIFT FORK";
            stringPage = "3 / 4";
            stringText = "You can raise the fork using R key button, and lower the fork using F key button. To get off the forklift using C key button.";
        }
        else if (currentPage == 4)
        {
            stringTitle = "FIRE EXTINGUISHER";
            stringPage = "4 / 4";
            stringText = "You can use the fire extinguisher by pressing F key button. To spray the fire extinguisher by pressing left click mouse button.";
        }
    }
}
