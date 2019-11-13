using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PaperBall : MonoBehaviour
{
    public PointsByHit points;

    private Diana diana;

    public int headPoints;
    public int bodyPoints;
    public int legPoints;
    void Start()
    {
        points = (PointsByHit)GameObject.FindObjectOfType(typeof(PointsByHit));

        diana = (Diana)GameObject.FindObjectOfType(typeof(Diana));
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
            Debug.Log("HeadShot");
        }
        else if (collision.gameObject.tag == "Body")
        {
            points.addPoints(bodyPoints);
            Debug.Log("BodyShot");
        }
        else if (collision.gameObject.tag == "Legs")
        {
            points.addPoints(legPoints);
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
