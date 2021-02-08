using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSize : MonoBehaviour
{
    private Transform planeObject;
    void Start()
    {
        planeObject = gameObject.transform;
        Vector3 newScale = planeObject.localScale;
        newScale.x = newScale.y * Camera.main.aspect;
        planeObject.localScale = newScale;
    }
}
