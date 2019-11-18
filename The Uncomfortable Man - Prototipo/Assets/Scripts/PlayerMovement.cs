using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public SceneManagement manager;
    public Camera cam;
    public Vector3 movement;
    public float moveSpeed;

    private float horizontal;
    private float vertical;

    void Start()
    {
        if (manager == null)
        { 
            manager = (SceneManagement)GameObject.FindObjectOfType(typeof(SceneManagement));
        }
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement = (cam.transform.forward * vertical + cam.transform.right * horizontal).normalized * moveSpeed;

        transform.Translate(movement * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Lobby":
                manager.loadScene("Lobby");
                break;
            case "Level1":
                manager.loadScene("School");
                break;
            case "MiniGame1":
                manager.nextScene = "SchoolMiniGame01";
                manager.loadScene("Instructions01");
                break;
            case "MiniGame2":
                manager.nextScene = "SchoolMiniGame02";
                manager.loadScene("Instructions02");
                break;
            case "MiniGame3":
                manager.nextScene = "SchoolMiniGame03";
                manager.loadScene("Instructions03");
                break;
            default:
                break;
        }
    }
}
