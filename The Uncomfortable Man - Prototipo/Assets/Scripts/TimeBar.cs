using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    public float maxTime;
    public float timeLeft = 0;
    public SpriteRenderer sprite;

    private void Start()
    {
        timeLeft = maxTime;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            sprite.color = Color.grey;
        }

        if (timeLeft <= maxTime / 4) sprite.color = Color.red;

        transform.localScale = new Vector3(timeLeft / maxTime, 1); 
    }
}
