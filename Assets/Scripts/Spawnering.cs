using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnering : MonoBehaviour
{
    Sprite[] SpriteList;
    public GameObject[] PrefabToList;
    public float SpawnEverySecond = 5f;
    [SerializeField] float SpawnAgainTimer = 5f;

    public float minRandom = 1f, maxRandom = 10f;
    public bool useRandom = true;

    public bool activateSpawner = false;
    public ParlorGame parlorGameSystem;

    // Start is called before the first frame update
    void Start()
    {
        SpawnAgainTimer = SpawnEverySecond;
    }

    // Update is called once per frame
    void Update()
    {
        if (parlorGameSystem)
        {
            activateSpawner = parlorGameSystem.HasGameStarted;
        } else
        {
            activateSpawner = true;
        }
        if (activateSpawner)
        {
            if (SpawnAgainTimer > 0f)
            {
                SpawnAgainTimer -= Time.deltaTime;

            }
            else
            {
                Instantiate(PrefabToList[Random.Range(0, PrefabToList.Length)], transform.position, Quaternion.identity, transform.parent);
                if(useRandom){
                    SpawnEverySecond = Random.Range(minRandom,maxRandom);
                }
                SpawnAgainTimer = SpawnEverySecond;
            }
        }
    }
}
