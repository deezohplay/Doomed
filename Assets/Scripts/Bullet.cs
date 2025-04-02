using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public float lifeTime = 1f;

    void Start()
    {
        Destroy(gameObject, lifeTime); // Destroy bullet after a set time
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Destroy bullet on impact
        Destroy(gameObject);
    }
}
