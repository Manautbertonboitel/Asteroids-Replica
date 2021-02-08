using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovements : MonoBehaviour
{
    private Rigidbody rb;

    public ParticleSystem onDestroyParticleSystem;
    public float moveSpeed;
    public float rotationSpeed;

    public GameObject[] gameLights;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();        
    }


    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float verticalInputValue;

        verticalInputValue = Input.GetAxisRaw("Vertical");

        /*rb.transform.Translate(Vector3.right * horizontalMoveSpeed * speed * Time.deltaTime);
        rb.transform.Translate(Vector3.up * verticalMoveSpeed * speed * Time.deltaTime);*/

        rb.AddForce(transform.up * verticalInputValue * moveSpeed * Time.deltaTime, ForceMode.Force);
    }

    void Rotate()
    {
        float horizontalInputValue;

        horizontalInputValue = Input.GetAxisRaw("Horizontal");

        /*if (Input.GetKey(KeyCode.A))
        {
            rb.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            rb.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }*/

        rb.AddTorque(new Vector3(0, 0, 1) * -horizontalInputValue * rotationSpeed * Time.deltaTime, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Instantiate(onDestroyParticleSystem, transform.position, transform.rotation);
        for (int i = 0; i < gameLights.Length; i++)
        {
            gameLights[i].GetComponent<Flash>().FlashRed();
        }
    }
}
