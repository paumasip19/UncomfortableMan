using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedBar : MonoBehaviour
{
    public float timeBar = 0;
    void Update()
    {
        transform.localScale = new Vector3(timeBar, 1, 0);

        if (Input.GetKey(KeyCode.E) && transform.localScale.x <= 1)
        {
            timeBar += 0.0053f;
        }
        else if (transform.localScale.x >= 1)
        {
            timeBar = 0;
        }
        else
        {
            timeBar = 0;
        }

    }
}
