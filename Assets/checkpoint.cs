using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public static checkpoint instance;
    public Transform[] checkpoints;
    public int index;

    private void Awake()
    {
        instance = this;
    }

    public void sectioncompleted()
    {
        index++;
    }
}
