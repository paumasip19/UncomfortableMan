﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperBall : MonoBehaviour
{
    public PointsByHit points;

    private Diana diana;
    private Teacher02 teacher;

    public int headPoints;
    public int bodyPoints;
    public int legPoints;
    void Start()
    {
        points = (PointsByHit)GameObject.FindObjectOfType(typeof(PointsByHit));

        diana = (Diana)GameObject.FindObjectOfType(typeof(Diana));
        teacher = (Teacher02)GameObject.FindObjectOfType(typeof(Teacher02));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Head")
        {
            points.addPoints(headPoints);
            teacher.getHurt();
            Debug.Log("HeadShot");
        }
        else if (collision.gameObject.tag == "Body")
        {
            points.addPoints(bodyPoints);
            teacher.getHurt();
            Debug.Log("BodyShot");
        }
        else if (collision.gameObject.tag == "Legs")
        {
            points.addPoints(legPoints);
            teacher.getHurt();
            Debug.Log("LegShot");
        }
        else if (collision.gameObject.tag == "Floor")
        {
            Destroy(this);
        }
        else if (collision.gameObject.tag == "Diana")
        {
            points.addPoints(100);
            Debug.Log("Diana");
            diana.killDiana();
        }
    }
}