using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Animator myAnim;
    GameObject mainCamera;
    CannonController cannonC;
    Image crosshair;
    Rigidbody cannonBall;
    int shootPower = 65;

    int mode = 0; //0 for movement, 1 for cannon
    float rotateSpeed = 15;

    Text gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        mainCamera = GameObject.Find("Main Camera");
        cannonC = null;
        cannonBall = null;
        crosshair = GameObject.Find("Crosshair").GetComponent<Image>();
        crosshair.enabled = false;

        gameEnd = GameObject.Find("Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //do end of game check for cannons here
        if (GameObject.Find("FriendLeft") == null && GameObject.Find("FriendCenter") == null && GameObject.Find("FriendRight") == null)
        {
            gameEnd.text = "Game Over!";
            Time.timeScale = 0;
        }
        else if (GameObject.Find("EnemyLeft") == null && GameObject.Find("EnemyCenter") == null && GameObject.Find("EnemyRight") == null)
        {
            gameEnd.text = "You Win!";
            Time.timeScale = 0;
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        myAnim.SetFloat("HAXIS", 0);
        myAnim.SetFloat("VAXIS", 0);

        if (mode == 0)
        {
            myAnim.SetFloat("HAXIS", h);
            myAnim.SetFloat("VAXIS", v);

            mainCamera.transform.position = transform.position - 5 * transform.forward + 2 * Vector3.up;
            mainCamera.transform.LookAt(transform.position);
        }
        else if (mode == 1)
        {
            //exit when cannon is destroyed (rare, not sure how to test)
            if (cannonC == null)
            {
                startMoving();
            }
            cannonC.transform.Rotate(Vector3.up, h * rotateSpeed * Time.deltaTime, Space.World);
            cannonC.transform.Rotate(cannonC.transform.right, v * rotateSpeed * Time.deltaTime, Space.World);

            //set camera pos
            mainCamera.transform.position = cannonC.spawnPoint.transform.position;
            mainCamera.transform.forward = cannonC.transform.forward;

            //shoot
            if (Input.GetButtonDown("Fire1"))
            {
                cannonBall = cannonC.Shoot(shootPower);
                mode = -1;
                Invoke("startFollowing", 0.2f);
            }
            else if (Input.GetButtonDown("Fire2"))
            {
                startMoving();
            }

        }
        else if (mode == 2)//shot follow mode
        {
            if (cannonBall != null)
            {
                mainCamera.transform.position = cannonBall.transform.position - cannonBall.velocity * 0.25f;
                mainCamera.transform.LookAt(cannonBall.position);
            }

            else
            {
                mode = -1; //do nothing
                Invoke("startAiming", 2);
            }
        }
        else //null mode
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Friendly Cannon" && mode == 0 && Input.GetButton("Jump"))
        {
            cannonC = other.transform.Find("Cannon").GetComponent<CannonController>();
            startAiming();
        }
    }

    void startMoving()
    {
        mode = 0;
        crosshair.enabled = false;
    }

    void startAiming()
    {
        mode = 1;
        crosshair.enabled = true;
    }

    void startFollowing()
    {
        mode = 2;
        crosshair.enabled = false;
    }
}
