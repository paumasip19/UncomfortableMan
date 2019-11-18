using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsByVariousInputs : MonoBehaviour
{
    [System.Serializable]
    public struct mechanic
    {
        public bool isActive;
        public GameObject UIelement;
        public int typeOfKid;
        public int pointsAmount;

        public float disapearingTimer;
        public float disapearingMaxTime;

        public float initialAparitionPercentage;
        public float aparitionPercentage;
       
        public int randomNum;

        public Countdown countdown;
        public int lastTime;

        public bool isCaught;

        public Kid03 kid;

        public void checkActivation()
        {           
            if (countdown.intTime != lastTime)
            {
                randomNum = Random.Range(0, 100);
                if (randomNum >= aparitionPercentage)
                {
                    disapearingTimer = disapearingMaxTime;
                    isActive = true;
                }
                else
                {
                    aparitionPercentage--;
                }
            }
            
            lastTime = countdown.intTime;
        }

        public void activeTime(ref int score)
        {
            UIelement.SetActive(true);
            if (disapearingTimer > 0)
            {
                disapearingTimer -= Time.deltaTime;

                if (!isCaught)
                {
                    switch (typeOfKid)
                    {
                        case 0:
                            //Dancer
                            if (Input.GetAxisRaw("Mouse X") > 4 || (Input.GetAxisRaw("Mouse X") < -4))
                            {
                                score += pointsAmount;
                                kid.dumbing = true;
                                kid.canAnimate = true;
                            }
                            else
                            {
                                kid.canAnimate = true;
                            }
                            break;

                        case 1:
                            //Jump
                            if (Input.GetAxisRaw("Mouse Y") > 4 || (Input.GetAxisRaw("Mouse Y") < -4))
                            {
                                score += pointsAmount;
                                kid.dumbing = true;
                                kid.canAnimate = true;
                            }
                            else
                            {
                                kid.canAnimate = true;
                            }
                            break;

                        case 2:
                            //Capoeira
                            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
                            {
                                score += pointsAmount;
                                kid.dumbing = true;
                                kid.canAnimate = true;
                            }
                            else
                            {
                                kid.canAnimate = true;
                            }
                            break;

                        case 3:
                            //Dancer 2
                            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
                            {
                                score += pointsAmount;
                                kid.dumbing = true;
                                kid.canAnimate = true;
                            }
                            else
                            {
                                kid.canAnimate = true;
                            }
                            break;

                        default:
                            kid.canAnimate = false;
                            break;
                    }
                }
                else
                {
                    kid.canAnimate = false;
                }
            }
            else
            {
                kid.canAnimate = false;
                aparitionPercentage = initialAparitionPercentage;
                UIelement.SetActive(false);
                isActive = false;                
            }
        }

    }

    public mechanic[] mechanics;

    public bool canPlay;
    
    public int points;
    public TextMeshProUGUI pointsText;

    public GameObject subPoints;

    public float downMove;


    void Start()
    {
        for (int i = 0; i < mechanics.Length; i++)
        {
            mechanics[i].disapearingTimer = mechanics[i].disapearingMaxTime;
            mechanics[i].aparitionPercentage = mechanics[i].initialAparitionPercentage;
        }
    }

    void Update()
    {
        if (canPlay)
        {
            for (int i = 0; i < mechanics.Length; i++)
            {
                if (!mechanics[i].isActive)
                {
                    mechanics[i].checkActivation();
                }
                else
                {
                    mechanics[i].activeTime(ref points);
                }
            }

            pointsText.text = points.ToString();
        }
    }

    public void subtractPoints(int amount)
    {
        int temp = int.Parse(pointsText.text);
        if (temp - amount < 0)
        {
            points = 0;
        }
        else points -= amount;
        subPoints.GetComponent<RectTransform>().position = new Vector3(downMove, 0, 0);
        subPoints.GetComponent<Animation>().Play();
    }
}
