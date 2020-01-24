using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 step;

    // Start is called before the first frame update
    void Start()
    {
        step = new Vector3(10, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += step * Time.deltaTime;
    }
}
