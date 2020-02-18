using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionController : MonoBehaviour
{
    //should be impossible for it to hit more than 2 things (cannon and player)
    Collider[] inRadius;
    Text gameEnd;

    int layermask = 1<<9;
    // Start is called before the first frame update
    void Start()
    {
        layermask = ~layermask;
        //was anything near enough to be destroyed
        inRadius = Physics.OverlapSphere(transform.position, 10, layermask);
        //GameObject.FindGameObjectsWithTag("Player");
        gameEnd = GameObject.Find("Text").GetComponent<Text>();

        for(int i = 0; i < inRadius.Length; i++)
        {
            //destroy player, end game
            if (inRadius[i].tag == "Player")
            {
                gameEnd.text = "Game Over!";
                Time.timeScale = 0;
            }
            Destroy(inRadius[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
