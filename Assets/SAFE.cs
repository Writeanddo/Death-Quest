using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SAFE : MonoBehaviour
{
    [SerializeField] string correctcode;


    [SerializeField] TMP_Text code;

    [SerializeField] List<string> codelist = new List<string>();


    public void addnumber(string number)
    {
        codelist.Add(number);

        rendernumber();
    }

    public void clear()
    {
        //clear the whole list if we click the clear button
    }

    private void rendernumber()
    {
        code.text = string.Join("", codelist.ToArray());
    }
}
