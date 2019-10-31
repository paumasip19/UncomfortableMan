using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;
    public Vector3 movement;
    public float moveSpeed;

    private float horizontal;
    private float vertical;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        movement = (cam.transform.forward * vertical + cam.transform.right * horizontal).normalized * moveSpeed;

        controller.SimpleMove(movement);
    }
}
