using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    MeshRenderer myMeshRend;
    MeshRenderer bubbleMeshRend;

    // Start is called before the first frame update
    void Start()
    {
        myMeshRend = GetComponent<MeshRenderer>();
        bubbleMeshRend = GameObject.Find("ForceBubble").GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        myMeshRend.material.color = Random.ColorHSV();
        bubbleMeshRend.material.color = Random.ColorHSV();
    }
}
