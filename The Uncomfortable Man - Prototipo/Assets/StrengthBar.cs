using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBar : MonoBehaviour
{
    Animation anim;
    public bool canPlay;
    public float forcePercentage;

    float timer = 3;
    void Start()
    {
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canPlay)
        {
            forcePercentage = transform.localPosition.x * 100;
            forcePercentage /= 7.38f;

            if (Input.GetButton("Fire2"))
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    stopBar();
                }

            }

            if (!anim.isPlaying)
            {
                if (timer <= 0)
                {
                    resumeBar();
                    timer = 4;
                }
                else
                {
                    timer -= Time.deltaTime;
                }

            }
        }        
    }

    public void stopBar()
    {
        anim.Stop();
    }

    public void resumeBar()
    {
        anim.Play();
    }

    public void stopWorking()
    {
        canPlay = false;
    }

    public void keepWorking()
    {
        canPlay = true;
    }
}
