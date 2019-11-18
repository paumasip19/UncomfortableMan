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
    public float previewTimer;

    public int caughtProbabilityPercentage;

    public int loseAmount;

    public int randomNum;

    public bool yell;

    public bool hasToRotate;
    public int angleRot;

    public GameObject exclamation;
    public GameObject interrogation;
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
                exclamation.SetActive(false);
                interrogation.SetActive(false);
                /*hasToRotate = true;
                angleRot = 0;*/

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
                    exclamation.SetActive(true);
                    /*hasToRotate = true;
                    angleRot = 0;
                    StartCoroutine(Rotate());*/
                }
                if (previewTimer <= 0.6 && Input.anyKeyDown)
                {
                    yell = true;
                    interrogation.SetActive(false);
                    exclamation.SetActive(true);
                    /*hasToRotate = true;
                    angleRot = 0;
                    StartCoroutine(Rotate());*/
                }
            }

            lastTime = countdown.intTime;
        }

        /*if (hasToRotate && angleRot == 0)
        {
            if (transform.rotation.y >= angleRot) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), 0.01f * Time.deltaTime);
            else hasToRotate = false;
            
        }
        else if (hasToRotate && angleRot == 180)
        {
            if (transform.rotation.y <= angleRot) transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime);
            else hasToRotate = false;
        }*/


        if (notCaught || caught)
        {
            transform.Rotate(Vector3.up * (10 * Time.deltaTime));
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Caught"))
            {
                interrogation.SetActive(false);
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
                interrogation.SetActive(false);
                exclamation.SetActive(false);
            }

            caughtProbabilityPercentage = 10;
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

    /*IEnumerator Rotate()
    {
        float moveSpeed = 0.1f;
        if(transform.rotation.y < 180)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.rotation = Quaternion.Euler(0, 180, 0);
        yield return null;
    }*/
}
