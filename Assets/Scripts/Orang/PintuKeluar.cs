using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintuKeluar : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Orang"))
        {
            Destroy(collision.gameObject);
            GameManager.score++;
        }      
    }
}
