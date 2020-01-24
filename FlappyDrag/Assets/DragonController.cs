using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DragonController : MonoBehaviour
{

    Rigidbody myBod;
    AudioSource myAudioSource;
    public AudioClip crashSound;
    public AudioClip flapSound;
    public AudioClip pointSound;
    int score;
    Text scoreText;
    Text gameOverText;
    Animator flapAnim;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody>();
        myBod.velocity = new Vector3(10, 0, 0);

        myAudioSource = GetComponent<AudioSource>();

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        score = 0;
        scoreText.text = "Score: " + score;

        gameOverText = GameObject.Find("GameOver").GetComponent<Text>();

        flapAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //score
        scoreText.text = "Score: " + score;

        //if paused (game over)
        if (Time.timeScale <= 0)
        {
            if (Input.GetButtonDown("Jump"))
            {
                //reload scene
                SceneManager.LoadScene(0);
                Time.timeScale = 1;
            }
        }
        //if playing
        else if (Time.timeScale > 0)
        {
            //if not rising and jump pressed, jump
            if(myBod.velocity.y <= 0 && Input.GetButtonDown("Jump"))
            {
                //play animation
                flapAnim.SetBool("Flap", true);
                //play sound
                myAudioSource.PlayOneShot(flapSound);
                //change velocity
                myBod.velocity = new Vector3(10, 15, 0);
            }
            else
            {
                //idle anim
                flapAnim.SetBool("Flap", false);
            }
        }
    }

    //collision = crash
    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 0;
        myAudioSource.PlayOneShot(crashSound);
        gameOverText.text = "Game Over";
    }

    //trigger = point
    private void OnTriggerEnter(Collider other)
    {
        myAudioSource.PlayOneShot(pointSound);
        score++;
    }
}