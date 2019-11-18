using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraController : MonoBehaviour
{
    public float sensitivity;

    public float yTop;
    public float yBottom;

    private CinemachineComposer composer;
    private Vector3 normalComposer;

    public GameObject aimingCam;
    public GameObject normalCam;

    private float timer = 4;

    public GameObject target;
    public GameObject bar;

    public Kid02 kid;

    bool canPlay = true;

    public GameObject pressedBar;

    void Start()
    {
        composer = GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<Cinemachine.CinemachineComposer>();
        normalComposer = composer.m_TrackedObjectOffset;
    }

    void Update()
    {
        if(canPlay)
        {
            if (Input.GetButton("Fire2"))
            {
                pressedBar.SetActive(false);
                if(kid.ballCounter > 0) bar.SetActive(true);
                else bar.SetActive(false);

                target.SetActive(true);

                float vertical = 0;
                if (!Input.GetButton("Fire1"))
                {
                    vertical = Input.GetAxis("Mouse Y") * sensitivity;
                }

                composer.m_TrackedObjectOffset.y += vertical;
                composer.m_TrackedObjectOffset.y = Mathf.Clamp(composer.m_TrackedObjectOffset.y, yBottom, yTop);
            }
            else
            {
                pressedBar.SetActive(true);
                bar.SetActive(false);
                target.SetActive(false);
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
    }

    public void stopPlaying()
    {
        canPlay = false;
    }
}
