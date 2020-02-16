using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //points forward at the player
        transform.LookAt(playerTransform.position);

        //code for aiming over mountains
        /*Vector3 temp = transform.forward;
        temp.y = 45;
        transform.forward = temp;*/
    }
}
