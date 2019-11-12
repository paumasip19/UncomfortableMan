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

    void Start()
    {
        composer = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineComposer>();
        normalComposer = composer.m_TrackedObjectOffset;
    }

    void Update()
    {
        if (!caught)
        {
            if (Input.GetButton("Fire2"))
            {
                isAiming = true;

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
            
        }
        
        Animate();

    }

    void Animate()
    {
        anim.SetBool("isAiming", isAiming);
        anim.SetBool("caught", caught);
    }
}
