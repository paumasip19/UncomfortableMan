using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class Kid02 : MonoBehaviour
{
    public Animator anim;

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

    public bool isAiming;
    public bool isCharging;

    public int ballCounter;
    public TextMeshProUGUI textBallCounter;

    public float animTimer;

    private void Start()
    {
        canPlay = true;
        timer = maxTime;
        animTimer = 2.25f;

        anim = GetComponent<Animator>();
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

                isAiming = true;

                if (!Input.GetButtonDown("Fire1")) transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);
                else if (Input.GetButtonDown("Fire1") && canShoot && ballCounter > 0)
                {
                    ballCounter--;
                    anim.SetTrigger("shoot");
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

                if (Input.GetKey(KeyCode.E))
                {
                    isCharging = true;
                    if (animTimer <= 0)
                    {
                        ballCounter++;
                        animTimer = 2.25f;
                    }
                    else animTimer -= Time.deltaTime;
                }
                else
                {
                    isCharging = false;
                    animTimer = 2.25f;
                }

                isAiming = false;
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
            updateBallCounter();
            Animate();
        }
    }

    public void stopPlayer()
    {
        canPlay = false;
    }

    public void updateBallCounter()
    {
        textBallCounter.text = "Balls: " + ballCounter.ToString();
    }

    void Animate()
    {
        anim.SetBool("isAiming", isAiming);
        anim.SetBool("isCharging", isCharging);
    }
}
