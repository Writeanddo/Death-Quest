using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemCabinet : MonoBehaviour
{
    public string correctcode;


    [SerializeField] TMP_Text code;

    [SerializeField] List<string> codelist = new List<string>();


    [SerializeField] Animator anim;



    public void addnumber(string number)
    {
        if (number == "cancel")
        {
            clear();
        }

        else if (number == "enter")
        {
            ENTER();
        }
        else
        {
            codelist.Add(number);

            rendernumber();
        }

    }

    public void clear()
    {
        codelist.Clear();
        code.text = "";
    }

    private void rendernumber()
    {
        code.text = string.Join("", codelist.ToArray());


    }


    void ENTER()
    {
        if (code.text == correctcode)
        {
            Debug.Log("correct");
            //play open safe anim;
            //play correct sound

            anim.SetTrigger("open");
        }

        else
        {
            Debug.Log("incorrect");
            //play incrorrect sound
            clear();
        }
    }
}
