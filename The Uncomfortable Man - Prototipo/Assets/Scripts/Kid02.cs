using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Kid02 : MonoBehaviour
{
    public Camera cam;
    public CinemachineVirtualCamera normalCam;
    public CinemachineVirtualCamera aimingCam;

    public GameObject paperBall;
    public Transform shootingPoint;

    public StrengthBar strength;

    public float force;
    public float forceExtra;

    public float turnSpeed;
    public float horizontal;

    private GameObject b;

    public bool canShoot;

    private float timer;
    public float maxTime;
    public Vector3 F;

    bool canPlay;

    private void Start()
    {
        canPlay = true;
        timer = maxTime;
    }

    void Update()
    {
        if (canPlay)
        {
            horizontal = Input.GetAxis("Mouse X") * 0.3f;
            Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);


            F = (new Vector3(ray.direction.x, ray.direction.y, ray.direction.z));

            if (Input.GetButton("Fire2"))
            {
                normalCam.m_Priority = 0;
                aimingCam.m_Priority = 10;

                if (!Input.GetButtonDown("Fire1")) transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
                else if (Input.GetButtonDown("Fire1") && canShoot)
                {
                    b = Instantiate(paperBall, shootingPoint.position, shootingPoint.rotation);

                    if (force >= 900) F *= (force + forceExtra);
                    else F *= force;

                    b.GetComponent<Rigidbody>().AddForce(F);
                    canShoot = false;
                }
            }
            else
            {
                normalCam.m_Priority = 10;
                aimingCam.m_Priority = 0;
            }

            if (!canShoot)
            {
                if (timer <= 0)
                {
                    canShoot = true;
                    timer = maxTime;
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }

            force = strength.forcePercentage * 10;

        }
    }

    public void stopPlayer()
    {
        canPlay = false;
    }
}
