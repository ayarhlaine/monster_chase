using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReferences;

    [SerializeField]
    private Transform leftPosition, rightPosition;

    private GameObject spawnedMonster;
    private int randomIndex, randomSide;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnMonsters()
    {
        while(true)
        {
            // wait for 1 to 5 seconds
            yield return new WaitForSeconds(Random.Range(2, 5));
            SpawnNewMonster();
        }
       
    }

    void SpawnNewMonster()
    {
        randomIndex = Random.Range(0, monsterReferences.Length);
        randomSide = Random.Range(0, 2);

        spawnedMonster = Instantiate(monsterReferences[randomIndex]);

        if (randomSide == 0)
        {
            // spawn from left side
            spawnedMonster.transform.position = leftPosition.position;
            spawnedMonster.GetComponent<Monster>().speed = Random.Range(6, 10);
        }
        else
        {
            // spawn from right side
            spawnedMonster.transform.position = rightPosition.position;
            spawnedMonster.GetComponent<Monster>().speed = -Random.Range(6, 10);
            spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}
