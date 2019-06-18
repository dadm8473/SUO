using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCamera : MonoBehaviour
{
    float updtaeRotate;

    // Update is called once per frame
    void Update()
    {
        updtaeRotate += 10 * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, updtaeRotate, 0);
    }
}
