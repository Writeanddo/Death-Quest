using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DIE : MonoBehaviour
{

    [SerializeField] Transform RespawnLocation;
    [SerializeField] GameObject Player;

    [SerializeField] GameObject Tombstone;
    [SerializeField] float respawntime;

    

    public IEnumerator die()
    {
        Player.gameObject.SetActive(false);

        Instantiate(Tombstone, Player.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(respawntime);
        Player.transform.position = RespawnLocation.position;
        Player.gameObject.SetActive(true);
    }
}
