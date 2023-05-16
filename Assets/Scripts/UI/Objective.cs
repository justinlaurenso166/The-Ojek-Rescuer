using UnityEngine;
using TMPro;
using System.Collections;

public class Objective : MonoBehaviour
{
    public TMP_Text displayText;
    public float displayTime = 5.0f;
    public string text;
    IEnumerator Start()
    {
        displayText.text = text;
        yield return new WaitForSeconds(displayTime);
        displayText.text = "";
    }
}
