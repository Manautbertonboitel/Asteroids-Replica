using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForwardMove : MonoBehaviour
{
    public float moveSpeed;
    public float destroyTime;
    public ParticleSystem destructionParticles;
    //public ParticleSystem particles;

    private void Start()
    {
        //Instantiate(particles, transform.position, transform.rotation);
    }
    void Update()
    {
        Move();
        Destroy(gameObject, destroyTime);
    }

    void Move()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(destructionParticles, transform.position, transform.rotation);
    }
}
