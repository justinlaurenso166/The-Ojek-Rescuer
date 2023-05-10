using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRak : MonoBehaviour
{
    public BoxCollider boxCollider;
    private bool adaTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        // boxCollider = GetComponent<BoxCollider>();
        adaTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Pallet" && !adaTarget)
        {
            Debug.Log("Ada pallet");
            GameManager.score += 1;
            adaTarget = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Pallet" && adaTarget)
        {
            adaTarget = false;
            GameManager.score -= 1;
        }
    }
}
