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
            case "Level1":
                manager.loadScene("School");
                break;
            case "MiniGame1":
                manager.loadScene("SchoolMiniGame01");
                break;
            case "MiniGame2":
                manager.loadScene("SchoolMiniGame02");
                break;
            case "MiniGame3":
                manager.loadScene("SchoolMiniGame03");
                break;
            default:
                break;
        }
    }
}
