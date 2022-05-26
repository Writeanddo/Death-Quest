using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Camera Camera;
    [SerializeField] float pickuprange;
    [SerializeField] float  abacusrange;
    [SerializeField] float safe_range;

    public List<GameObject> AllItems = new List<GameObject>();

    public List<GameObject> Items = new List<GameObject>();

    [SerializeField] int selectedweapon;

    [SerializeField] GameObject Key_for_molehill;
    [SerializeField] GameObject[] molehills;
    [SerializeField] MetalDetector MetalDetector;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        weaponsetactive();
        molehillkey();

    }
    private void Update()
    {
        scrollwheel();
        pickup();
        Abacus();
        safe();
    }

    private void scrollwheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedweapon >= Items.Count - 1)
            {
                selectedweapon = 0;
            }
            else
            {
                selectedweapon++;
            }

            weaponsetactive();

        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedweapon <= 0)
            {
                selectedweapon = Items.Count - 1;
            }
            else
            {
                selectedweapon--;
            }

            weaponsetactive();
        }
    }

    private void weaponsetactive()
    {
        
            foreach (GameObject weapon in Items)
            {
                if(weapon!= null)
                {
                weapon.SetActive(false);
                }
               
            }

            if(Items[selectedweapon] != null)
        {
            Items[selectedweapon].SetActive(true);
        }
          
        
   

    }

    private void pickup()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Hit,pickuprange ))
        {
            if (Hit.transform.gameObject.tag == "Pickup")
            {
                Debug.Log("hit pickup");

                if (Input.GetKeyDown(KeyCode.E))
                {
                  
                    if(Items[0] != null && Items[1] != null)
                    {
                        //get the items pickable object from the items script and instatiate it
                        Instantiate(Items[selectedweapon].GetComponent<item>().pickup, Hit.point, Quaternion.identity);


                        //disable the items gameobject
                        Items[selectedweapon].SetActive(false);

                        //swap the current item with the pickable objects itemindex
                        Items[selectedweapon] = AllItems[Hit.transform.gameObject.GetComponent<itemforpickup>().itemindex];
                        weaponsetactive();

                    }

                    else if( Items[0] == null && Items[1] == null)
                    {
                        //add item to first slot
                        Items[0] = AllItems[Hit.transform.gameObject.GetComponent<itemforpickup>().itemindex];
                        weaponsetactive();

                    }

                    else if (Items[0] != null && Items[1] == null)
                    {
                        //add item to first slot
                        Items[1] = AllItems[Hit.transform.gameObject.GetComponent<itemforpickup>().itemindex];
                        weaponsetactive();
                    }

                    //destroy the pickable objects gameobject
                    Destroy(Hit.transform.gameObject);

                }
            }
            

        }
    }

    void molehillkey()
    {
     int randnumber = Random.Range(0, molehills.Length);

        Vector3 Position = molehills[randnumber].GetComponent<molehill>().gameObject.transform.GetChild(0).gameObject.transform.position;

       GameObject key = Instantiate(Key_for_molehill, Position, Quaternion.identity);

        MetalDetector.Key = key;
    }

    void Abacus()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Hit, abacusrange))
        {
            if (Hit.transform.gameObject.tag == "Block")
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    GameObject block = Hit.transform.gameObject;

                    Ray ray = Camera.ScreenPointToRay(Input.mousePosition);

                    float clmapedxpos = Mathf.Clamp(Hit.point.x, block.GetComponent<block>().Abacus.rightcentre.position.x, block.GetComponent<block>().Abacus.leftcentre.position.x );

                   // Debug.Log(Hit.point.x);



                    //Debug.Log(clmapedxpos);
                    //Debug.Log(block.GetComponent<block>().Abacus.leftcentre.position.x);

                    //Debug.Log(block.GetComponent<block>().Abacus.rightcentre.position.x);
                     
                    block.transform.position = new Vector3(clmapedxpos, block.transform.position.y, block.transform.position.z);

                }
            }

        }
    }

    void safe()
    {
        RaycastHit Hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Hit, safe_range))
        {
            if (Hit.transform.gameObject.tag == "Safe")
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GameObject key = Hit.transform.gameObject;

                    string number = key.GetComponent<safe_keys>().number;

                    key.GetComponent<safe_keys>().safe.addnumber(number);


                }


                   
            }
        }
    }
}
