using UnityEngine;
using TMPro;
using System.Collections;

public class Objective : MonoBehaviour
{
    public TMP_Text displayText;
    public float displayTime = 5.0f;

    IEnumerator Start()
    {
        displayText.text = "Selamatkan 3 orang yang terperangkap!";
        yield return new WaitForSeconds(displayTime);
        displayText.text = "";
    }
}
