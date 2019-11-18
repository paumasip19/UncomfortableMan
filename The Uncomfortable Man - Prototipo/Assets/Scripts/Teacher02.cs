using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Teacher02 : MonoBehaviour
{
    private Animator anim;
    private BehaviorExecutor behaviour;

    private bool canPlay;
    private bool walking;

    private float timer;

    void Start()
    {
        anim = GetComponent<Animator>();
        behaviour = GetComponent<BehaviorExecutor>();

        walking = true;
        canPlay = true;
    }

    void Update()
    {
        if (canPlay)
        {
            if (!walking)
            {
                if (timer > 0) timer -= Time.deltaTime;
                else
                {
                    walking = true;
                    behaviour.paused = false;
                }
            }
        }
        
        anim.SetBool("walking", walking);
        anim.SetBool("isWorking", canPlay);
    }

    public void getHurt()
    {
        anim.SetTrigger("hurt");        
        walking = false;
        behaviour.paused = true;
    }

    public void stopTeacher()
    {
        canPlay = false;
    }

}
