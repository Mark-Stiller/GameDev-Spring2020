using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    Transform playerTransform;
    NavMeshAgent myNavAgent;
    PlayerController playerC;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        playerC = GameObject.Find("Player").GetComponent<PlayerController>();
        myNavAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //points forward at the player
        /*transform.LookAt(playerTransform.position);
        transform.position += transform.forward * 5 * Time.deltaTime;*/

        myNavAgent.SetDestination(playerTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        playerC.hitMe(35, transform.position);
    }
}
