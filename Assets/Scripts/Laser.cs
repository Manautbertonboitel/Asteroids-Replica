using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject belettePrefab;
    public CameraShake cameraShake;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(belettePrefab, transform.position, transform.rotation);
            StartCoroutine(cameraShake.Shake(.15f, .4f));
        }
    }
}
