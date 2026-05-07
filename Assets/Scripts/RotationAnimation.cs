using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    public int speed = 10;

    void Update()
    {
        transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    }
}
