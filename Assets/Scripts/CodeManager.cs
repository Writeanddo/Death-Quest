using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodeManager : MonoBehaviour
{

    public int codeforplatformround;
    public TMP_Text textforplatformround;
    public TMP_Text textforplatformpickup;
    [SerializeField] SAFE toastersafe;


    public int CODEforgunround;
    public TMP_Text[] textforgunround;
    [SerializeField] SAFE tvsafe;

    public int codefordigginground;
    public TMP_Text textfordiggingrouund;
    [SerializeField] SAFE greenmugsafe;

    public int codeformazeround;
    public TMP_Text textformazeround;
    [SerializeField] SAFE kettlesafe;



    // Start is called before the first frame update
    void Start()
    {

        codeforplatformround = Random.Range(1001, 9999);

        textforplatformround.text = "This is something that may help you:\n\nCode: " + codeforplatformround.ToString() + "\n\nThis needs to be typed somewhere.\n\n(Hint: toaster)";
        toastersafe.correctcode = codeforplatformround.ToString();


        //gunround

        CODEforgunround = Random.Range(1001, 9999);

        string gunroundtext = "Warning: You will need a gun for this section as you will be fighting many enemies.\n\nHere is a code, make of that what you will\n\ncode: "+ CODEforgunround.ToString() +"\n\nHint: Television";

        foreach(TMP_Text text in textforgunround)
        {
            text.text = gunroundtext;
        }

        tvsafe.correctcode = CODEforgunround.ToString();

        //digginground
        codefordigginground = Random.Range(1001, 9999);

        textfordiggingrouund.text = "You will need two things.\n\n1) a tool to help you locate the key\n\n2) A tool to help you dig up the soil\n\nHere is a code: " + codefordigginground.ToString() + "\n\nHint: Green Mug";
        greenmugsafe.correctcode = codefordigginground.ToString();



        //maze round
        codeformazeround = Random.Range(1001, 9999);
        textformazeround.text = "Welcome to the Maze Round. You are going to need a map to help find your way to the end.\n\nHere is a code\n\nCode:" + codeformazeround.ToString() + "\n\nHint: Kettle";
        kettlesafe.correctcode = codeformazeround.ToString();



    }

   


}
