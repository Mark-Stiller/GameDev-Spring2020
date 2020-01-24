using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove : MonoBehaviour
{
    public Vector3 step = new Vector3(1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += step * Time.deltaTime;

        float dist = 7;
        if (Mathf.Abs(transform.position.x) > dist || Mathf.Abs(transform.position.y) > dist || Mathf.Abs(transform.position.x) > dist)
        {
            step *= -1;
        }
    }
}
