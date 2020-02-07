using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator myAnim;
    SpriteRenderer myRend;
    Rigidbody2D myBod;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        myRend = GetComponent<SpriteRenderer>();
        myBod = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        if (h > 0)
        {
            myAnim.SetBool("Run", true);
            Vector2 v = myBod.velocity;
            v.x = h * 5;
            myBod.velocity = v;
            myRend.flipX = false;
            myAnim.speed = 3;
        }
        else if (h < 0)
        {
            myAnim.SetBool("Run", true);
            Vector2 v = myBod.velocity;
            v.x = h * 5;
            myBod.velocity = v;
            myRend.flipX = true;
            myAnim.speed = 3;
        }
        else
        {
            myAnim.SetBool("Run", false);
        }
    }
}
