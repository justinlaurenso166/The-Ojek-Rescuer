using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    // void Start()
    // {
    //     particleSystem = GetComponent<ParticleSystem>();
    //     var collisionModule = particleSystem.collision;
    //     collisionModule.enabled = true;
    //     collisionModule.type = ParticleSystemCollisionType.World;
    //     collisionModule.SetPlane(0, GameObject.FindWithTag("Ground").transform);

    //     particleSystem.collision.SetCollisionEventCallback(OnParticleCollision);
    // }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.gameObject.name);
    }

}
