using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour {

    public int angleSpeed;

    public void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, angleSpeed * Time.deltaTime);
    }
}
