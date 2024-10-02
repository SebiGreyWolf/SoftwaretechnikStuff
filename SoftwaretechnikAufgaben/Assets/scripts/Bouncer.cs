using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    public float explosionForce = 500f;
    public float explosionRadius = 5f;
    public ForceMode forceMode = ForceMode.Impulse;  

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody objectRigidbody = other.attachedRigidbody;  

        if (objectRigidbody != null)
        {
            Vector3 explosionPosition = transform.position;

            objectRigidbody.AddExplosionForce(explosionForce, explosionPosition, explosionRadius, 0f, forceMode);
        }
    }
}
