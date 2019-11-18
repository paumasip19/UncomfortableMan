using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher03 : MonoBehaviour
{
    Animator animator;

    bool isIdle;
    bool preview;
    bool caught;
    bool notCaught;

    public Kid03[] kids;

    public PointsByVariousInputs points;
    public Countdown countdown;

    public int timesToCatch;
    int lastTime;
    int timeTryCatch;

    public float maxPreviewTime;
    public float previewTimer;

    public int caughtProbabilityPercentage;

    public int loseAmount;

    public int randomNum;

    public bool yell;

    public bool canPlay = true;

    public GameObject exclamation;
    public GameObject interrogation;

    void Start()
    {
        animator = GetComponent<Animator>();

        isIdle = true;
        preview = false;
        caught = false;
        notCaught = false;
    }

    void Update()
    {
        if (canPlay)
        {
            if (countdown.intTime != lastTime && !preview && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                exclamation.SetActive(false);
                interrogation.SetActive(false);
                randomNum = Random.Range(0, 100);
                if (randomNum <= caughtProbabilityPercentage)
                {
                    preview = true;
                    interrogation.SetActive(true);
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
                if (previewTimer <= 0.6 &&
                    (Input.GetAxisRaw("Mouse X") != 0 ||
                     Input.GetAxisRaw("Mouse Y") != 0 ||
                     Input.GetAxisRaw("Mouse ScrollWheel") > 0 ||
                     Input.GetAxisRaw("Mouse ScrollWheel") > 0))
                {
                    yell = true;
                    interrogation.SetActive(false);
                    exclamation.SetActive(true);
                }
            }

            lastTime = countdown.intTime;

            if (notCaught || caught)
            {
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Caught"))
                {
                    interrogation.SetActive(false);
                    caught = false;
                    points.subtractPoints(loseAmount);
                    //player stop anim
                    for (int i = 0; i < kids.Length; i++)
                    {
                        kids[i].stopPlayer();
                    }
                }
                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("NotCaught"))
                {
                    notCaught = false;
                    interrogation.SetActive(false);
                    exclamation.SetActive(false);
                }

                caughtProbabilityPercentage = 10;
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
