using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid03 : MonoBehaviour
{
    public PointsByVariousInputs points;

    public int typeOfKid;

    private bool canPlay = true;
    private bool caught = false;

    private Animator anim;

    private float waitTime = 4;

    public bool dumbing;
    public float animTimer;
    bool stopped = false;

    public bool canAnimate;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            if (!caught)
            {
                if (canAnimate)
                {
                    if (typeOfKid == 0 && (Input.GetAxisRaw("Mouse X") > 4 || (Input.GetAxisRaw("Mouse X") < -4)))
                    {
                        animTimer = 0.8f;
                    }
                    else if (typeOfKid == 1 && (Input.GetAxisRaw("Mouse Y") > 4 || (Input.GetAxisRaw("Mouse Y") < -4)))
                    {
                        animTimer = 0.8f;
                    }
                    else if (typeOfKid == 2 && Input.GetAxisRaw("Mouse ScrollWheel") > 0)
                    {
                        animTimer = 0.8f;
                    }
                    else if (typeOfKid == 3 && Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                    {
                        animTimer = 0.8f;
                    }              
                }

                if (animTimer > 0)
                {
                    animTimer -= Time.deltaTime;
                }

                if (animTimer <= 0)
                {
                    dumbing = false;
                }
            }
            else
            {
                points.canPlay = false;

                if (waitTime >= 0)
                {
                    waitTime -= Time.deltaTime;
                }
                else
                {
                    caught = false;
                    stopped = false;
                    points.canPlay = true;
                    waitTime = 4;
                }
            }

            if (!stopped) Animate();
        }

    }

    private void Animate()
    {
        anim.SetBool("dumbing", dumbing);
        anim.SetBool("caught", caught);
    }

    public void stopPlayer()
    {
        caught = true;
        waitTime = 3;
    }
}
