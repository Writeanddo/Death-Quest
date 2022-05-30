using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIE : MonoBehaviour
{
    public static DIE instance;

    [SerializeField] Transform RespawnLocation;

    [SerializeField] GameObject Tombstone;

    [SerializeField] bool lerpup, lerpdown;


    [SerializeField] float fadespeed;

    [SerializeField] float lerpvalue;
    [SerializeField] float lerpmultioplier;

    [SerializeField] Image RespawnBlackscreen;

    [SerializeField] spiderspawner spiderspawner;
    [SerializeField] Flyenemiesspawner Flyenemiesspawner;

    [SerializeField] DOOR door;

    [SerializeField] Transform target;


    private void Awake()
    {
        instance = this;
    }

    public IEnumerator die()
    {

        GunRoundManager.instance.restart();


        PlayerMovement.instance.gameObject.SetActive(false);

        lerpmultioplier = 0;
        lerpup = true;

        Instantiate(Tombstone, PlayerMovement.instance.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(GameManager.instance.respawntime);
        PlayerMovement.instance.transform.position = GameManager.instance.respawnlocation.position;
        PlayerMovement.instance.gameObject.SetActive(true);
        PlayerMovement.instance.CurrentHealth = PlayerMovement.instance.MaxHealth;

        GameManager.instance.stopdoorcount();

        door.cancount = false;


        Flyenemiesspawner.haschecked = false;
        spiderspawner.haschecked = false;
        Spiderroundmanager.instance.destoryenemy();
        

        lerpmultioplier = 0;
        lerpdown = true;

        

    }

    public IEnumerator respawn()
    {


        PlayerMovement.instance.gameObject.SetActive(false);


        lerpmultioplier = 0;
        lerpup = true;

        yield return new WaitForSeconds(GameManager.instance.respawntime);

        PlayerMovement.instance.transform.position = checkpoint.instance.checkpoints[checkpoint.instance.index].position;
        PlayerMovement.instance.gameObject.SetActive(true);
        PlayerMovement.instance.CurrentHealth = PlayerMovement.instance.MaxHealth;

        lerpmultioplier = 0;
        lerpdown = true;

       

      

    }

    private void Update()
    {

        if (lerpup)
        {
            lerpmultioplier += Time.deltaTime * fadespeed;

            lerpvalue = Mathf.Lerp(0, 1, lerpmultioplier);

            RespawnBlackscreen.color = new Color(RespawnBlackscreen.color.r, RespawnBlackscreen.color.g, RespawnBlackscreen.color.b, lerpvalue);

            if (lerpvalue == 1)
            {
                lerpup = false;
            }
        }

        if (lerpdown)
        {
            lerpmultioplier += Time.deltaTime * fadespeed;

            lerpvalue = Mathf.Lerp(1, 0, lerpmultioplier);

            RespawnBlackscreen.color = new Color(RespawnBlackscreen.color.r, RespawnBlackscreen.color.g, RespawnBlackscreen.color.b, lerpvalue);

            if (lerpvalue == 0)
            {
                lerpdown = false;
            }
        }
    }

   
}
