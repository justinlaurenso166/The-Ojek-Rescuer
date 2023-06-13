using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

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

    // Start is called before the first frame update
    void Start()
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
        Time.timeScale = 0;
        Cursor.visible = true;
        guidePanel.SetActive(true);
    }

    public void CloseGuide()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
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
            stringTitle = "Character Movement";
            stringPage = "1 / 4";
            stringText = "Ini adalah Teks untuk page 1";
        }
        else if (currentPage == 2)
        {
            stringTitle = "Forklift";
            stringPage = "2 / 4";
            stringText = "Ini adalah Teks untuk page 2";
        }
        else if (currentPage == 3)
        {
            stringTitle = "Using Fork";
            stringPage = "3 / 4";
            stringText = "Ini adalah Teks untuk page 3";
        }
        else if (currentPage == 4)
        {
            stringTitle = "Fire Extinguisher";
            stringPage = "4 / 4";
            stringText = "Ini adalah Teks untuk page 4";
        }
    }
}
