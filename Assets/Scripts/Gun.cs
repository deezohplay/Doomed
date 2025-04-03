using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; 
    public float fireRate = 0.2f;
    public AudioClip gunShotSound;
    
    private float nextFireTime = 0f;
    private AudioSource audioSource;
    
    // Recoil settings
    private Vector3 recoilKickback;
    public float recoilRecoverySpeed = 8f;
    
    private Vector3 originalPosition;

    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        originalPosition = transform.localPosition;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }

        // Smoothly move gun back to original position after recoil
        transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * recoilRecoverySpeed);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Vector3 recoilKickback = new Vector3(Random.Range(-0.02f, 0.02f),Random.Range(-0.02f, 0.02f),-0.1f);
        /*
            if (audioSource && gunShotSound)
            {
                audioSource.PlayOneShot(gunShotSound);
            }
        */
        // Apply recoil
        transform.localPosition += recoilKickback;
        Camera.main.transform.localPosition += new Vector3(Random.Range(-0.05f, 0.05f),Random.Range(-0.05f, 0.05f),0f);
    }
}
