using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InitialCountdown : MonoBehaviour
{
    public float maxTime;
    public float time;
    public int intTime;

    public GameObject[] objects;

    TextMeshProUGUI text;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        time = maxTime;
        intTime = Mathf.FloorToInt(time);
        text.text = intTime.ToString();

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (intTime != -1)
        {
            time -= Time.deltaTime;
            intTime = Mathf.FloorToInt(time - 1);
            if (intTime == 0)
            {
                text.text = "GO!!!";
            }
            else if (intTime == -1)
            {
                Destroy(text);

                for (int i = 0; i < objects.Length; i++)
                {
                    objects[i].SetActive(true);
                }
            }
            else text.text = intTime.ToString();

        }
        
    }
}
