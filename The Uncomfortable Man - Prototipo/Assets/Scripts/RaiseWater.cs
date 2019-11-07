using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseWater : MonoBehaviour
{
    public KeyboardBar bar;

    public float percentage;
    public float reductor;
    public float total;

    private float initialPos;

    private void Start()
    {
        initialPos = transform.position.y;
    }
    
    void Update()
    {
        percentage = bar.transform.lossyScale.x;
        total = percentage / reductor;

        transform.position = new Vector3(transform.position.x, initialPos + total, transform.position.z);
    }
}
