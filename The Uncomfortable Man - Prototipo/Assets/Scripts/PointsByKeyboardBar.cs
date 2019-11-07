﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsByKeyboardBar : MonoBehaviour
{
    public KeyboardBar keyboardBar;
    public Countdown countdown;
    public TextMeshProUGUI text;

    public float percentage;
    public float reductor;
    public float total;
    public int points;

    private float initialPos;
    private bool canPlay;

    void Start()
    {
        initialPos = transform.position.y;
        text.text = points.ToString();
    }

    void Update()
    {
        if (countdown.intTime > 0 || canPlay)
        {
            percentage = keyboardBar.transform.lossyScale.x;
            total = percentage / reductor;

            if (percentage > 0 && Input.anyKeyDown) points += Mathf.FloorToInt(total) / 2;

            text.text = points.ToString();
        }     
    }

    public void stopInputForSeconds(int timeStopped)
    {
        if(timeStopped == 0) canPlay = true;
        else canPlay = false;
    }
}
