using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderMovement : MonoBehaviour
{
    [SerializeField] float distancetoplayer;
    [SerializeField] GameObject Player;

    private NavMeshAgent NavmeshAgent;

    [SerializeField] float Attackrange;

    public enum AIstate
    {
        ischasing, isattacking
    }

    public AIstate currentstate;



    // Start is called before the first frame update
    void Start()
    {
        NavmeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        distancetoplayer = Vector3.Distance(transform.position,Player.transform.position);


        switch (currentstate)
        {
            case AIstate.ischasing:

                NavmeshAgent.SetDestination(Player.transform.position);

                if(distancetoplayer <= Attackrange)
                {
                    currentstate = AIstate.isattacking;
                }

                break;


            case AIstate.isattacking:
                NavmeshAgent.SetDestination(Player.transform.position);

                if(distancetoplayer > Attackrange)
                {
                    currentstate = AIstate.ischasing;
                }
                break;
        }
    }
}
