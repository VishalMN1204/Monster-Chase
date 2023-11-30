using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] monsterReference;

    [SerializeField]
    private Transform leftPos, rightPos;

    private GameObject spawnedMonster;

    private int randomIndex;
    // to determine the index of the spawned monster

    private int randomSide;
    // to determine at which side monster would spawned

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMonsters());
        // is called only once
    }

    // Update is called once per frame
    void Update()
    {

    }

    // why coroutine because to call this method over interval of time can be called again and again
    IEnumerator SpawnMonsters()
    {
        // infinite while loop when the game starts these will keep on looping
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));
            // monsters will be spawned every 1-5 seconds
            // because of the waitforseconds there is a delay which results in not crashing the program which happens in while loop

            randomIndex = Random.Range(0, monsterReference.Length);
            randomSide = Random.Range(0, 2);



            spawnedMonster = Instantiate(monsterReference[randomIndex]);
            // spawns the monster
            // Instantiate will create a copy of the gameobject passed as a reference
            // It will return either 0,1,2 as mentioned in the Unity
            // If the randomIndex is 0 it will spawn the enemy with index 0

            //spawn enemies side condition
            if (randomSide == 0)
            {
                //spawns on left side

                spawnedMonster.transform.position = leftPos.position;
                spawnedMonster.GetComponent<Monster>().speed = Random.Range(4, 10);
                // to go to the right side
            }
            else
            {
                // spawns on right side

                spawnedMonster.transform.position = rightPos.position;
                spawnedMonster.GetComponent<Monster>().speed = -Random.Range(4, 10);
                // to go to the left side

                spawnedMonster.transform.localScale = new Vector3(-1f, 1f, 1f);
                // default looking position of monster is towards right but if we want to look it towards the left use the above one
                // alternative to flipX in sprite renderer
            }
        }
    }
}
