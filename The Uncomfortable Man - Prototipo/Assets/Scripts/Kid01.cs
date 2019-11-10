using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid01 : MonoBehaviour
{
    Animator animator;
    AudioSource blah;

    public PointsByKeyboardBar keyboardPoints;
    public KeyboardBar bar;

    public bool caught = true;
    public bool talking;

    float animTimer;
    float waitTime = 4;
    public bool stopped = true;

    bool soundOn = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        blah = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!caught)
        {
            if (Input.anyKeyDown)
            {
                talking = true;
                animTimer = 1;
            }
            else if (animTimer > 0)
            {
                animTimer -= Time.deltaTime;
                if (!soundOn)
                {
                    blah.Play();
                    soundOn = true;
                }
                
            }

            if (animTimer <= 0)
            {
                talking = false;
                blah.Stop();
                soundOn = false;
            } 
        }
        else
        {
            keyboardPoints.canPlay = false;
            bar.canPlay = false;
            if (waitTime >= 0)
            {
                waitTime -= Time.deltaTime;
            } 
            else
            {
                caught = false; 
                stopped = false;
                keyboardPoints.canPlay = true;
                bar.canPlay = true;
                waitTime = 4;
            } 
        }

        if(!stopped) Animate();
    }

    public void stopPlayer()
    {
        caught = true;
        waitTime = 3;
    }

    void Animate()
    {
        animator.SetBool("talking", talking);
        animator.SetBool("caught", caught);
    }
}
