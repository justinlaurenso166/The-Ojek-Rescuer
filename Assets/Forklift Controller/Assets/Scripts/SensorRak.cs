using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorRak : MonoBehaviour
{
    public BoxCollider boxCollider;
    private HashSet<GameObject> palletsInside = new HashSet<GameObject>(); // HashSet to keep track of the pallets inside the collider

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pallet")
        {
            if (!palletsInside.Contains(other.gameObject))
            { // Only increment the score if the pallet is not already inside the collider
                palletsInside.Add(other.gameObject); // Add the pallet to the HashSet to keep track of it
                Debug.Log("Number of pallets inside: " + palletsInside.Count);
                GameManager.score += 1; // Increase the score by 1 for each new pallet that enters the collider
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Pallet")
        {
            if (palletsInside.Contains(other.gameObject))
            { // Only decrement the score if the pallet is already inside the collider
                palletsInside.Remove(other.gameObject); // Remove the pallet from the HashSet
                Debug.Log("Number of pallets inside: " + palletsInside.Count);
                GameManager.score -= 1; // Decrease the score by 1 for each pallet that exits the collider
            }
        }
    }
}

