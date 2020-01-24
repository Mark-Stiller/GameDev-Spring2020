using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceBubbleController : MonoBehaviour
{
    public Vector3 force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.AddForce(force);
    }
}
