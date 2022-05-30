using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class molehill : MonoBehaviour
{
    [SerializeField] List<GameObject> hills = new List<GameObject>();
    [SerializeField] int index;

    public GameObject canvas;

    void Start()
    {
        for(int i = 0; i< 3; i++)
        {
            GameObject section = gameObject.transform.GetChild(i).gameObject;

            hills.Add(section);
        }
    }

    public void destroyhill()
    {
        Destroy(hills[index]);

        index--;

        if(index < 0)
        {
            Destroy(gameObject);
        }
    }

}
