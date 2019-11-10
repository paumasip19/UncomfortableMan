using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teacher01 : MonoBehaviour
{
    Animator animator;

    bool isIdle;
    bool preview;
    bool caught;
    bool notCaught;

    public Kid01[] kids;

    public PointsByKeyboardBar keyboardPoints;
    public Countdown countdown;
    //public GameObject losePoints;

    public int timesToCatch;
    int totalTime;
    int lastTime;
    int timeTryCatch;

    public float maxPreviewTime;
    float previewTimer;

    public int caughtProbabilityPercentage;

    public int loseAmount;

    public int randomNum;

    public bool yell;

    void Start()
    {
        animator = GetComponent<Animator>();

        totalTime = (int)countdown.maxTime;

        timeTryCatch = totalTime / timesToCatch;

        isIdle = true;
        preview = false;
        caught = false;
        notCaught = false;

    }

    void Update()
    {
        if (timesToCatch != 0)
        {
            if (countdown.intTime != lastTime && !preview && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                randomNum = Random.Range(0, 100);
                if (randomNum <= caughtProbabilityPercentage)
                {
                    preview = true;
                    previewTimer = maxPreviewTime;
                }
                else
                {
                    caughtProbabilityPercentage++;
                }
            }

            if (preview)
            {
                previewTimer -= Time.deltaTime;
                if (previewTimer <= 0.0)
                {
                    preview = false;
                    CheckCaught();
                }
                if (previewTimer <= 0.6 && Input.anyKeyDown)
                {
                    yell = true;
                }
            }

            lastTime = countdown.intTime;
        }

        if (notCaught || caught)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Caught"))
            {
                caught = false;
                keyboardPoints.subtractPoints(loseAmount);
                //player stop anim
                for (int i = 0; i < kids.Length; i++)
                {
                    kids[i].stopPlayer();
                }
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).IsName("NotCaught"))
            {
                notCaught = false;
            }
        }

        Animate();     
    }

    void CheckCaught()
    {
        if (yell)
        {
            //teacher anim
            yell = false;
            caught = true;
            timesToCatch--;

            //Instantiate losing Points anim
            //sound
            
            
            //stop controls
        }
        else
        {
            notCaught = true;
            timesToCatch--;
        }
    }

    void Animate()
    {
        animator.SetBool("isIdle", isIdle);
        animator.SetBool("preview", preview);
        animator.SetBool("caught", caught);
        animator.SetBool("notCaught", notCaught);

    }
}
