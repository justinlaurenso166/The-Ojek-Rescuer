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
            stringTitle = "KARAKTER";
            stringPage = "1 / 4";
            stringText = "Anda dapat berjalan menggunakan tombol WASD dan gerakkan mouse Anda untuk menggerakkan kamera.";
        }
        else if (currentPage == 2)
        {
            stringTitle = "FORKLIFT";
            stringPage = "2 / 4";
            stringText = "Anda dapat menggunakan forklift dengan menekan tombol F. Anda dapat menaikkan gigi forklift dengan menekan tombol E, dan tombol Q untuk menurunkan gigi. Saat menggunakan forklift, gigi 1 berarti Anda bisa berjalan maju, gigi -1 berarti Anda bisa berjalan mundur, dan gigi 0 forklift tidak dapat bergerak.";
        }
        else if (currentPage == 3)
        {
            stringTitle = "GARPU FORKLIFT";
            stringPage = "3 / 4";
            stringText = "Anda dapat menaikkan garpu forklift menggunakan tombol tombol R, dan menurunkan garpu forklift menggunakan tombol tombol F. Untuk keluar dari forklift menggunakan tombol C.";
        }
        else if (currentPage == 4)
        {
            stringTitle = "ALAT PEMADAM API";
            stringPage = "4 / 4";
            stringText = "Anda dapat menggunakan alat pemadam api dengan menekan tombol tombol F. Untuk menyemprot alat pemadam api dengan menekan tombol klik kiri mouse. Kegunaan seluruh tombol Anda dapat lihat pada keybinds dalam menu option.";
        }
    }
}
