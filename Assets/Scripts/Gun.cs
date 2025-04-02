using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; 
    public float fireRate = 0.2f;
    public AudioClip gunShotSound; // Drag a gunshot sound here

    private float nextFireTime = 0f;
    private AudioSource audioSource;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        /*
        if (audioSource && gunShotSound)
        {
            audioSource.PlayOneShot(gunShotSound);
        }
        */
    }
}
