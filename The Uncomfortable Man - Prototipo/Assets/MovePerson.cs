using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MovePerson : MonoBehaviour
{
    public enum typeOfPerson { Blue, Red, Green, Yellow, Purple  };

    public struct Person
    {
        public typeOfPerson type;
        public float speed;
        public int points;
        public Material material;
    }

    public TextMeshProUGUI puctuation;

    public Material b;
    public Material r;
    public Material g;
    public Material y;
    public Material p;

    public Person person;

    float timer;
    void Start()
    {
        InitializePerson();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * person.speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            puctuation.text = "0";
        }
    }

    void InitializePerson()
    {
        int randomNum = Random.Range(1, 6);
        Debug.Log(randomNum);
        switch (randomNum)
        {
            case 1:
                person.type = typeOfPerson.Blue;
                person.speed = 40;
                person.points = 20;
                GetComponent<Renderer>().material = b;
                break;
            case 2:
                person.type = typeOfPerson.Red;
                person.speed = 80;
                person.points = 60;
                GetComponent<Renderer>().material = r;
                break;
            case 3:
                person.type = typeOfPerson.Green;
                person.speed = 30;
                person.points = 10;
                GetComponent<Renderer>().material = g;
                break;
            case 4:
                person.type = typeOfPerson.Yellow;
                person.speed = 60;
                person.points = 40;
                GetComponent<Renderer>().material = y;
                break;
            case 5:
                person.type = typeOfPerson.Purple;
                person.speed = 100;
                person.points = 80;
                GetComponent<Renderer>().material = p;
                break;
        }
    }
}
