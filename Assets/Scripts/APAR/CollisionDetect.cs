using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.gameObject.name);
    }

}
