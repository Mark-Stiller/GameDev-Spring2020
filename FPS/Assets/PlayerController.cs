using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //rotation based on mouse movement
    Vector3 myRot;

    public GameObject bulletPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //obtains horizontal and vertical as floats in the case of analog input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Vector3 step = new Vector3(h, 0, v); //equivalent to line 21
        //Vector3 step = Vector3.right * h + Vector3.forward * v; //this is world-aligned movement, camera-aligned is below
        Vector3 step = transform.right * h + transform.forward * v;
        //constrain to no vertical movement
        step.y = 0;
        //moves 5 units per second
        transform.position += step * 5 * Time.deltaTime;


        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        
        Vector3 rotStep = Vector3.up * mx + Vector3.left * my;
        //get total rotation
        myRot += rotStep * 360 * Time.deltaTime;
        //limit rotation around x
        myRot.x = Mathf.Clamp(myRot.x , - 15, 15);
        //apply to camera
        transform.eulerAngles = myRot;

        //shoot
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject g = Instantiate(bulletPrefab);
            g.transform.position = transform.position;
            Rigidbody r = g.GetComponent<Rigidbody>();
            r.velocity = transform.forward * 40 + Vector3.up * 5;
        }
    }
}
