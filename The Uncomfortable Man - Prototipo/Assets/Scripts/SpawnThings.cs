using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnThings : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPoint;
    public TimeBar timeBar;

    public bool spawnOverTime;
    public float timeToSpawn;

    float time;

    private void Start()
    {
        if (!spawnOverTime) SpawnObject();
        else time = timeToSpawn;
    }
    
    void Update()
    {
        if (spawnOverTime && timeBar.transform.localScale.x >= 0)
        {
            if (time <= 0)
            {
                SpawnObject();
                time = timeToSpawn;
            }
            else time -= Time.deltaTime;
        }
    }

    void SpawnObject()
    {
        /*Transform t = transform;
        t.position = new Vector3(0, 0, 0);*/
        Instantiate(prefab);
    }
}
