using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spiderroundmanager : MonoBehaviour
{
    [SerializeField] float enemyspawntime;
    public static Spiderroundmanager instance;

    [SerializeField] GameObject currentenemy;

    [SerializeField] Transform spawnpos;

    [SerializeField] GameObject enemyprefab;

    private void Awake()
    {
        instance = this;
    }
    public void spawnenemy()
    {

        if(currentenemy != null)
        {
            Destroy(currentenemy);
        }

        StartCoroutine(enemy());
    }

    private IEnumerator enemy()
    {

        yield return new WaitForSeconds(enemyspawntime);
        GameObject obj = Instantiate(enemyprefab, spawnpos.position, Quaternion.identity);
        currentenemy = obj;
    }


    public void destoryenemy()
    {

        if (currentenemy != null)
        {
            Destroy(currentenemy);
        }
    }

}
