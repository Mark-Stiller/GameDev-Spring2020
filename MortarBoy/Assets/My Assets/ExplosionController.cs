using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionController : MonoBehaviour
{
    //should be impossible for it to hit more than 2 things (cannon and player)
    Collider[] inRadius;
    Text gameEnd;

    // Start is called before the first frame update
    void Start()
    {
        //was anything near enough to be destroyed
        inRadius = Physics.OverlapSphere(this.transform.position, 10);
        GameObject.FindGameObjectsWithTag("Player");
        gameEnd = GameObject.Find("Text").GetComponent<Text>();

        for(int i = 0; i < inRadius.Length; i++)
        {
            //destroy player, end game
            if (inRadius[i].tag == "Player")
            {
                Destroy(inRadius[i].gameObject);
                gameEnd.text = "Game Over!";
                Time.timeScale = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
