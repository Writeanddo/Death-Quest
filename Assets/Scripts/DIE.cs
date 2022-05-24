using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIE : MonoBehaviour
{
    public static DIE instance;

    [SerializeField] Transform RespawnLocation;
    [SerializeField] GameObject Player;

    [SerializeField] GameObject Tombstone;
    [SerializeField] float respawntime;

    [SerializeField] GunRoundManager gunRoundManager;

    private void Awake()
    {
        instance = this;
    }

    public IEnumerator die()
    {

        gunRoundManager.restart();


        Player.gameObject.SetActive(false);
        
        Instantiate(Tombstone, Player.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(respawntime);
        Player.transform.position = RespawnLocation.position;
        Player.gameObject.SetActive(true);


    }
}
