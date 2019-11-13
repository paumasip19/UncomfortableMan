using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public float sensitivity;
    public Animator anim;

    public bool isAiming;
    public bool caught;

    public float yTop;
    public float yBottom;

    private CinemachineComposer composer;
    private Vector3 normalComposer;

    public GameObject aimingCam;
    public GameObject normalCam;

    private float timer = 4;

    public GameObject target;
    public GameObject bar;

    bool canPlay = true;

    void Start()
    {
        composer = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineComposer>();
        normalComposer = composer.m_TrackedObjectOffset;
    }

    void Update()
    {
        if(canPlay)
        {
            if (!caught)
            {
                if (Input.GetButton("Fire2"))
                {
                    bar.SetActive(true);

                    isAiming = true;
                    target.SetActive(true);

                    float vertical = 0;
                    if (!Input.GetButton("Fire1"))
                    {
                        vertical = Input.GetAxis("Mouse Y") * sensitivity;
                    }
                    else
                    {
                        anim.SetTrigger("shoot");
                    }

                    composer.m_TrackedObjectOffset.y += vertical;
                    composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, yBottom, yTop);
                }
                else
                {
                    bar.SetActive(false);
                    target.SetActive(false);
                    isAiming = false;
                    composer.m_TrackedObjectOffset = normalComposer;
                }

                if (aimingCam.activeSelf)
                {
                    normalCam.transform.position = aimingCam.transform.position;
                }

                if (normalCam.activeSelf)
                {
                    aimingCam.transform.position = normalCam.transform.position;
                    aimingCam.transform.rotation = normalCam.transform.rotation;
                }
            }
            else
            {
                target.SetActive(false);
                if (timer <= 0)
                {
                    caught = false;
                    timer = 4;
                    target.SetActive(true);
                }
                else
                {
                    timer -= Time.deltaTime;
                }
            }
        }
            
        Animate();

    }

    void Animate()
    {
        anim.SetBool("isAiming", isAiming);
        anim.SetBool("caught", caught);
    }

    public void stopPlaying()
    {
        canPlay = false;
    }
}
