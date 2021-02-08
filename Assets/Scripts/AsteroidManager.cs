using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    public Rigidbody rb;

    public float speedRange;
    public float rotationSpeedRange;

    public ParticleSystem particles;


    private float speed;
    private float horizontalSpeed;
    private float verticalSpeed;

    private float rotationSpeed;

    void Start()
    {
        speed = Random.Range(-speedRange, speedRange);
        horizontalSpeed = Random.Range(-speedRange, speedRange);
        verticalSpeed = Random.Range(-speedRange, speedRange);
        rotationSpeed = Random.Range(30, rotationSpeedRange);

        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();

    }

    void Move()
    {
        rb.transform.Translate(Vector3.right * horizontalSpeed * speed * Time.deltaTime, Space.World);
        rb.transform.Translate(Vector3.up * verticalSpeed * speed * Time.deltaTime, Space.World);
    }

    void Rotate()
    {
        rb.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        Instantiate(particles, transform.position, transform.rotation);
        GameObject.FindWithTag("Plane").GetComponent<AsteroidInstantiationManager>().asteroidOnScreen--;
    }
}
