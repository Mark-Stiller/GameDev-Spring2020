using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CannonController cannonC;
    GameObject player;
    float power;
    public int delay;
    // Start is called before the first frame update
    void Start()
    {
        cannonC = GetComponent<CannonController>();
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("shootPlayer", delay, 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void shootPlayer()
    {
        this.transform.LookAt(player.transform);
        this.transform.Rotate(Random.Range(-30, -80), 0, 0);
        power = Random.Range(30,70);
        cannonC.Shoot(power);
    }
}
