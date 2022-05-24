using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Vector3 movevector;
    public PlayerMovement PlayerMovement;

    [SerializeField] float speed;
    [SerializeField] GameObject cube;
    [SerializeField] int damage;
    public GameObject ha;

    private void Start()
    {
  
    }
    void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerMovement.instance.Takedamage(damage);

            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
