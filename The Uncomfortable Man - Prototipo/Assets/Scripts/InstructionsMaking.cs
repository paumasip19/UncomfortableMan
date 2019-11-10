﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsMaking : MonoBehaviour
{
    public SimpleHelvetica instructions;
    public SceneManagement manager;
    public Rigidbody[] letters;

    private string message;
    private string sceneToLoad;
    private string lastScene;
    float timer = 4;
    bool count;

    // Start is called before the first frame update
    void Start()
    {
        instructions.Text = message;       
        instructions.AddRigidbody();
        instructions.Mass = 10;
        instructions.IsKinematic = true;
        instructions.UseGravity = true;

        
        Debug.Log(instructions.Text);
        Debug.Log(instructions.Text.Length);
    }

    // Update is called once per frame
    void Update()
    {

        /*if(Input.GetKeyDown(KeyCode.A))*/letters = GetComponentsInChildren<Rigidbody>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i].isKinematic = false;
                letters[i].velocity = new Vector3(Random.Range(-200, 200), Random.Range(-200, 200), Random.Range(100, 200));
            }
            count = true;
        }

        if (count)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) manager.loadScene(sceneToLoad);
        }

        if(Input.GetKeyDown(KeyCode.Escape)) manager.loadScene(lastScene);
    }

    public void setMiniGameScene(string _message, string _scene, string _lastScene)
    {
        message = _message;
        sceneToLoad = _scene;
        lastScene = _lastScene;
    }
}