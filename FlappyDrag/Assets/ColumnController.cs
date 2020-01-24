using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //dupe
        GameObject copy = Instantiate(this.gameObject);
        //40 x and between 0-10 y
        copy.transform.position = new Vector3(this.transform.position.x+40, Random.Range(0, 10), 0);
    }
}
