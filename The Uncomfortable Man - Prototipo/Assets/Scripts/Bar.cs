using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public float maxTime;
    float timeLeft = 0;
    
    void Start()
    {
        //transform.localScale = new Vector3(0f, 1f);
        //timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        if (Input.anyKeyDown && transform.localScale.x < 1) timeLeft += 0.07f;
        transform.localScale = new Vector3(timeLeft / maxTime, 1);
    }
}
