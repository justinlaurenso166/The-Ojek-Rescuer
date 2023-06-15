using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float maxTime = 180f;
    public float timeLeft;
    private Image uiImage;

    public static Timer instance;


    // Start is called before the first frame update
    void Start()
    {
        uiImage = GetComponent<Image>();
        timeLeft = maxTime;

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static Timer GetInstance()
    {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            uiImage.fillAmount = timeLeft / maxTime;
            // timeLeftStatic = timeLeft;
        }
        else
        {
            Time.timeScale = 0f;
            GameManager.GetInstance().timeOver();
        }
    }
}
