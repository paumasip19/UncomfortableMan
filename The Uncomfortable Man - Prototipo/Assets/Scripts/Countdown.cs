using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float maxTime;
    public float time;
    public int intTime;
    public TextMeshProUGUI text;
    public TextMeshProUGUI timeOut;
    void Start()
    {
        time = maxTime;
        intTime = Mathf.FloorToInt(time);
        text.text = time.ToString();
        timeOut.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (intTime != 0)
        {
            time -= Time.deltaTime;
            intTime = Mathf.FloorToInt(time);
            text.text = intTime.ToString();
        }

        if (intTime <= 15) text.color = Color.red;
        
        if(intTime == 0) timeOut.gameObject.SetActive(true);
    }

    void StopObjectProcess()
    { 
    
    }
}
