using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class platformpickupgetstring : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    private void Start()
    {
      if(Platform.instance.correctorderstring != null)

        {
            text.text = Platform.instance.correctorderstring;
        }
    }
}
