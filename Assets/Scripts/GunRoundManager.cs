using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRoundManager : MonoBehaviour
{
    public static GunRoundManager instance;

    [SerializeField] GameObject spawnlocation;

    [SerializeField] GameObject enemyprefab;
    [SerializeField] List<GameObject> first_enemies = new List<GameObject>();
    [SerializeField] List<GameObject> second_enemies = new List<GameObject>();

    [SerializeField] bool finishedspawning;
    [SerializeField] bool finishedspawning2;


    [SerializeField] float timebetweenspawns1;


    [SerializeField] Animator dooranim;
    [SerializeField] Flyenemiesspawner flyenemiesspawner;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
     
    }

    private void beginning()
    {
        /*
        if(GameManager.instance.playedguninto == true)
        {
            start normal round
        }

        else
        {
            playintro then start round
        }

        */
    }


    private void Update()
    {

        if (finishedspawning)
        {
           for(int i = 0; i < first_enemies.Count; i++)
            {
                if(first_enemies[i] == null)
                {
                    first_enemies.RemoveAt(i);
                }
            }

           if(first_enemies.Count == 0)
            {
                StartCoroutine(spawn_second_enemies());
                finishedspawning = false;
            }

        }

        if (finishedspawning2)
        {
            for (int i = 0; i < second_enemies.Count; i++)
            {
                if (second_enemies[i] == null)
                {
                    second_enemies.RemoveAt(i);
                }
            }

            if (second_enemies.Count == 0)
            {
                dooranim.SetTrigger("open");
                flyenemiesspawner.ROUNDfinished = true;
                finishedspawning2 = false;
            }
        }
    }


    public IEnumerator spawnfirstenemies()
    {
        for(int i = 0; i <5; i++)
        {
            GameObject enemy = Instantiate(enemyprefab, spawnlocation.transform.position, Quaternion.identity);

            first_enemies.Add(enemy);

            yield return new WaitForSeconds(timebetweenspawns1);
        }

        finishedspawning = true;
    }


    private IEnumerator spawn_second_enemies()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject enemy = Instantiate(enemyprefab, spawnlocation.transform.position, Quaternion.identity);

            second_enemies.Add(enemy);
            yield return new WaitForSeconds(timebetweenspawns1);

        }

        finishedspawning2 = true;
    }

    public  void restart()
    {

        foreach(GameObject enemy in first_enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject enemy in second_enemies)
        {
            Destroy(enemy);
        }


        first_enemies.Clear();
        second_enemies.Clear();

        finishedspawning = false;
        finishedspawning2 = false;
    }
    

}
