using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorGameObject : MonoBehaviour
{
    private bool isCursorHidden = true; // Menandakan apakah kursor disembunyikan atau tidak

    private void Awake()
    {
        HideCursor();
    }

    private void Start()
    {
        HideCursor(); // Menyembunyikan kursor saat permainan dimulai
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)) // Mengecek apakah tombol Left Alt ditekan
        {
            if (isCursorHidden)
            {
                ShowCursor(); // Jika kursor disembunyikan, maka tampilkan
            }
            else
            {
                HideCursor(); // Jika kursor ditampilkan, maka sembunyikan
            }
        }
    }

    private void HideCursor()
    {
        Debug.Log("Hide");
        Cursor.visible = false; // Menyembunyikan tampilan kursor mouse
        Cursor.lockState = CursorLockMode.Locked; // Mengunci posisi kursor mouse di tengah layar
        isCursorHidden = true; // Menandakan bahwa kursor disembunyikan
    }

    private void ShowCursor()
    {
        Debug.Log("Show");
        Cursor.visible = true; // Menampilkan tampilan kursor mouse
        Cursor.lockState = CursorLockMode.None; // Membebaskan posisi kursor mouse
        isCursorHidden = false; // Menandakan bahwa kursor ditampilkan
    }
}
