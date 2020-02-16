using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallController : MonoBehaviour
{

    public GameObject explosionPF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //in case of OOB shot
        if (transform.position.y < -2)
        {
            Instantiate(explosionPF, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(explosionPF, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
