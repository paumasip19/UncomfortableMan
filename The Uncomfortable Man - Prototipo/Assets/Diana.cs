using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diana : MonoBehaviour
{
    public GameObject dianaPrefab;

    public GameObject son;

    public Vector3 initialPos;
    
    public float instantiationTimer;
    public float disappearTimer;

    public float maxTimeInstantiate;
    public float maxTimeDisappear;

    public bool hasChild;

    private bool canPlay;


    void Start()
    {
        canPlay = true;

        hasChild = false;

        instantiationTimer = maxTimeInstantiate;
        disappearTimer = maxTimeDisappear;

        initialPos = new Vector3(-0.5f, -2.5f, 29f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canPlay)
        {
            if (hasChild)
            {
                if (disappearTimer > 0)
                {
                    disappearTimer -= Time.deltaTime;
                }
                else
                {
                    Destroy(son);
                    disappearTimer = maxTimeDisappear;
                    hasChild = false;
                }
            }
            else
            {
                if (instantiationTimer > 0)
                {
                    instantiationTimer -= Time.deltaTime;
                }
                else
                {
                    son = Instantiate(dianaPrefab, transform.position, transform.rotation);
                    float x = Random.Range(-3, 3);
                    float y = Random.Range(-2, 2);
                    son.transform.position = initialPos = new Vector3(-0.5f + x, -2.5f + y, 29f); ;

                    instantiationTimer = maxTimeInstantiate;
                    hasChild = true;
                }
            }
        }
    }
    public void killDiana()
    {
        Destroy(son);
        disappearTimer = maxTimeDisappear;
        hasChild = false;
    }

    public void stopDiana()
    {
        canPlay = false;
    }
}