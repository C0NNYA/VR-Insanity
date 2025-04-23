using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PistolBehaviour : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // where the bullet spawns (like the gun barrel)
    public float bulletSpeed = 30f;

    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor interactor; // optional for haptics

    void Start()
    {
        if (firePoint == null)
        {
            Debug.LogError("FirePoint not set on PistolBehaviour.");
        }
    }

    public void Fire()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed;
            }

            // Optional: Add haptics
            if (interactor != null)
                interactor.SendHapticImpulse(0.5f, 0.1f);
        }
    }
}