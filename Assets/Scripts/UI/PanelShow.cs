using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelShow : MonoBehaviour
{
    public GameObject panel; // Panel yang ingin ditampilkan saat tombol diklik

    private Button button; // Tombol yang akan digunakan

    private void Start()
    {
        panel.SetActive(false);
        button = GetComponent<Button>(); // Mendapatkan komponen Button pada game object ini
        button.onClick.AddListener(ShowPanel); // Menambahkan listener saat tombol diklik
    }

    public void ShowPanel()
    {
        panel.SetActive(true); // Menampilkan panel saat tombol diklik
    }
}
