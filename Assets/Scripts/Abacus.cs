using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abacus : MonoBehaviour
{
    public Transform rightcentre, leftcentre;

    [SerializeField] Vector3 size;
    [SerializeField] int Numleft,Numright;

    public bool correct;

    private void Update()
    {

        int sumleft = 0;

        int sumright = 0;

        Collider[] collidersleft =  Physics.OverlapBox(leftcentre.position, size / 2);
        Collider[] collidersright = Physics.OverlapBox(rightcentre.position, size / 2);

        for (int i = 0; i < collidersleft.Length; i++)
        {
            if (collidersleft[i].GetComponent<block>() != null)
            {
                sumleft += collidersleft[i].GetComponent<block>().number;
            }

        }

        for (int i = 0; i < collidersright.Length; i++)
        {
            if (collidersright[i].GetComponent<block>() != null)
            {
                sumright += collidersright[i].GetComponent<block>().number;
            }

        }

        if(sumleft == Numright && sumright == Numleft)
        {
            Debug.Log("correct");
            correct = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(leftcentre.position, size);
        Gizmos.DrawWireCube(rightcentre.position, size);

    }
}
