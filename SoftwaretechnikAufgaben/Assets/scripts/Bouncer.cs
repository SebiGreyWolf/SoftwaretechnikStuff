using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField] float explosionForce = 50f;
    [SerializeField] float explosionRadius = 5f;
    [SerializeField] int pointsPerHit = 100;

    private ForceMode forceMode = ForceMode.Impulse;
    private GameManager gm;
    private float explosionForceFactor = 10f;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerStay(Collider other)
    {
        gm.AddPoints(pointsPerHit);

        Rigidbody objectRigidbody = other.attachedRigidbody;
        ExplosionHandle(objectRigidbody);
    }
    private void ExplosionHandle(Rigidbody objectRigidbody)
    {
        

        if (objectRigidbody != null)
        {
            Vector3 explosionPosition = transform.position;

            objectRigidbody.AddExplosionForce(explosionForce * explosionForceFactor, explosionPosition, explosionRadius, 0f, forceMode);

        }

    }
}
