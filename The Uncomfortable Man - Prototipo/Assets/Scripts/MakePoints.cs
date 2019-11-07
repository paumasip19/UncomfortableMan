using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MakePoints : MonoBehaviour
{
    public TextMeshProUGUI puctuation;
    int temp;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Ray ray = new Ray(transform.position, -transform.forward);

        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 100))
        {
            if (hitInfo.collider.gameObject.tag == "Person")
            {
                switch (hitInfo.collider.gameObject.GetComponent<MovePerson>().person.type)
                {
                    case MovePerson.typeOfPerson.Blue:
                        if (Input.GetKeyDown(KeyCode.K))
                        {
                            addPoints(hitInfo);
                        }
                        break;

                    case MovePerson.typeOfPerson.Red:
                        if (Input.GetKeyDown(KeyCode.K))
                        {
                            addPoints(hitInfo);
                        }
                        break;

                    case MovePerson.typeOfPerson.Green:
                        if (Input.GetKeyDown(KeyCode.K))
                        {
                            addPoints(hitInfo);
                        }
                        break;

                    case MovePerson.typeOfPerson.Yellow:
                        if (Input.GetKeyDown(KeyCode.K))
                        {
                            addPoints(hitInfo);
                        }
                        break;

                    case MovePerson.typeOfPerson.Purple:
                        if (Input.GetKeyDown(KeyCode.K))
                        {
                            addPoints(hitInfo);
                        }
                        break;

                    default: 
                        break;
                }   
            }
        }
    }

    void addPoints(RaycastHit hitInfo)
    {
        int.TryParse(puctuation.text, out temp);
        temp += hitInfo.collider.gameObject.GetComponent<MovePerson>().person.points;
        puctuation.text = temp.ToString();
        hitInfo.collider.gameObject.tag = "Done";
    }
}
