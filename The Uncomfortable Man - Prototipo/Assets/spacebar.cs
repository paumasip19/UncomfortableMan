using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spacebar : MonoBehaviour
{
    public SceneManagement manager;
    void Start()
    {
        if (manager == null) manager = (SceneManagement)GameObject.FindObjectOfType(typeof(SceneManagement));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            manager.loadScene("School");
        }
    }
}
