using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Platformsettings")]
public class Platformorder : ScriptableObject
{

    [SerializeField] GameObject Note;

    [SerializeField] string[] positions;


    public GameObject getNote()
    {
        return Note;
    }

    public string[] getpositions()
    {
        return positions;
    }
    

}
