using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsByHit : MonoBehaviour
{
    TextMeshProUGUI pointsText;

    int points;

    void Start()
    {
        pointsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    public void addPoints(int amount)
    {
        points = int.Parse(pointsText.text);
        points += amount;
        pointsText.text = points.ToString();
    }

    public void subtractpoints(int amount)
    {
        points = int.Parse(pointsText.text);
        points -= amount;
        pointsText.text = points.ToString();
    }
}
