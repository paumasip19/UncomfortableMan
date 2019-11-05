using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInstructions : MonoBehaviour
{
    public Rigidbody[] letters;

    void Start()
    {
        letters = GetComponentsInChildren<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i].isKinematic = false;
                letters[i].velocity = new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(100, 200));
            }
        }
    }
}
