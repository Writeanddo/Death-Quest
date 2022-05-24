using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] float distancetoplayer;
    [SerializeField] GameObject Player;

    [SerializeField] NavMeshAgent NavmeshAgent;

    [SerializeField] float Attackrange;

    [SerializeField] GameObject Bullet;

    [SerializeField] float Bulletforce;

    [SerializeField] float cooldowncounter, cooldowntime;

    [SerializeField] GameObject asd;


    [SerializeField] float randmin, randmax;

    public enum AIstate
    {
        ischasing, isattacking
    }

    public AIstate currentstate;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cooldowncounter -= Time.deltaTime;
        move();
    }

    private void move()
    {
        distancetoplayer = Vector3.Distance(transform.position, PlayerMovement.instance.transform.position);


        switch (currentstate)
        {
            case AIstate.ischasing:

                NavmeshAgent.SetDestination(PlayerMovement.instance.transform.position);


                if(cooldowncounter <= 0)
                {
                    GameObject bullet = Instantiate(Bullet, transform.position, Quaternion.identity);
                    //bullet.GetComponent<EnemyProjectile>().PlayerMovement = Player.GetComponent<PlayerMovement>();
                    //bullet.GetComponent<EnemyProjectile>().ha =asd ;

                    Vector3 rand = new Vector3(Random.Range(randmin, randmax), Random.Range(randmin, randmax), Random.Range(randmin, randmax));
                    

                    Vector3 veloctiy = PlayerMovement.instance.GetComponent<CharacterController>().velocity;
                    float targetspeed = veloctiy.magnitude;

                    Vector3 pos = (transform.forward * Bulletforce) + veloctiy;

                    bullet.GetComponent<Rigidbody>().AddForce(pos,ForceMode.Impulse);


                    cooldowncounter = cooldowntime;
                }
              

                if (distancetoplayer <= Attackrange)
                {
                    currentstate = AIstate.isattacking;
                }

                break;


            case AIstate.isattacking:
                NavmeshAgent.SetDestination(PlayerMovement.instance.transform.position);

                if (distancetoplayer > Attackrange)
                {
                    currentstate = AIstate.ischasing;
                }
                break;
        }
    }


}
