using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelamatinOrang : MonoBehaviour
{
    public float destroyDistance = 1f; // jarak maksimum dari pemain
    public string playerTag = "Player"; // tag game object pemain

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

            if (playerObject != null && Vector3.Distance(playerObject.transform.position, transform.position) <= destroyDistance)
            {
                Destroy(gameObject);
                GameManager.score++;
            }
        }
    }
}
