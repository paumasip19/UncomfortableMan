using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardBar : MonoBehaviour
{
    public float maxTime;
    public float timeLeft = 0;

    public bool canPlay = true;

    public Countdown countdown;

    void Update()
    {
        if(timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        if (countdown.intTime != 0)
        {
            if (canPlay)
            {
                if (Input.anyKeyDown && transform.localScale.x <= 1) timeLeft += 0.07f;
            }          
            transform.localScale = new Vector3(timeLeft / maxTime, 1);
        }       
    }
}
