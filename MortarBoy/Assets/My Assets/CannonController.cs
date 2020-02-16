using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject CBallPF;
    public GameObject spawnPoint;

    public Rigidbody Shoot(float power)
    {
        spawnPoint = transform.Find("BallSpawnPoint").gameObject;

        GameObject g = Instantiate(CBallPF, spawnPoint.transform.position, transform.rotation) as GameObject;
        Rigidbody gRB = g.GetComponent<Rigidbody>();
        gRB.AddForce(transform.forward.normalized * power, ForceMode.Impulse);
        return gRB;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Shoot(30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
