using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pointsScreen : MonoBehaviour
{
    public GameObject[] objects;

    public GameObject[] screen;

    public float[] standartPoints;

    public TextMeshProUGUI pointsText;
    public GameObject finalScore;
    public GameObject messageSpace;

    private int p;

    float timer = 3;

    public SceneManagement manager;

    private void Start()
    {
        if (manager == null) manager = (SceneManagement)GameObject.FindObjectOfType(typeof(SceneManagement));
    }
    void Update()
    {
        if (timer <= 0)
        {
            p = int.Parse(pointsText.text);
            finalScore.GetComponent<TextMeshProUGUI>().text = "Your punctuation has been " + p.ToString() + " points.";

            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }

            screen[3].SetActive(true);

            if (p >= standartPoints[0] && p < standartPoints[1])
            {
                screen[0].SetActive(true);
            }
            else if (p >= standartPoints[1] && p < standartPoints[2])
            {
                screen[1].SetActive(true);
            }
            else if (p >= standartPoints[2])
            {
                screen[2].SetActive(true);
            }

            finalScore.SetActive(true);
            messageSpace.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                manager.loadScene(manager.nextScene);
            }
        }
        else { timer -= Time.deltaTime; }

    }
}
