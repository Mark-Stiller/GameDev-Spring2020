using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloneBubbleController : MonoBehaviour
{
    int ballCounter = 1;
    Text countText;

    // Start is called before the first frame update
    void Start()
    {
        countText = GameObject.Find("BallCountText").GetComponent<Text>();
        countText.text = "(☞ﾟヮﾟ)☞ Ball Count: " + ballCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && Time.timeScale > 0)
        {
            Time.timeScale = 0;
        }
        else if (Input.GetButtonDown("Jump") && Time.timeScale <= 0)
        {
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Random.Range(1, 10) == 1)
        {
            GameObject copy = Instantiate(other.gameObject);
            copy.transform.position = new Vector3(Random.Range(-7, 7), Random.Range(-5, 5), 0);
            ballCounter++;
            countText.text = "(☞ﾟヮﾟ)☞ Ball Count: " + ballCounter;
        }
    }
}
