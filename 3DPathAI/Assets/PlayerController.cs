using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Renderer myRend;
    CharacterController myCC;
    int life;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<Renderer>();
        myCC = GetComponent<CharacterController>();
        InvokeRepeating("ChangeColor", 1, 1);

        life = 100;
        score = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 step = transform.forward * v + transform.right * h;
        //transform.position += step * 5 * Time.deltaTime;
        myCC.Move(step * 5 * Time.deltaTime);
        score.text = "Life: " + life;
    }

    void ChangeColor()
    {
        myRend.material.color = Random.ColorHSV();
    }

    public void hitMe(int dmg, Vector3 sourcePos)
    {
        Vector3 v = transform.position - sourcePos;
        v.y = 0;
        myCC.Move(v * 4);

        life -= dmg;
        if (life < 0)
        {
            Time.timeScale = 0;

            score.text = "You have deceased";
        }
    }
}
