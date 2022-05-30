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

    [SerializeField] GameObject interactableobject;

    [SerializeField] GameObject go;

    public Transform respawnlocation;
    public float respawntime;

    public GameObject pickupobject;

    public GameObject door;
   

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
        interactable();
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


        if (Input.GetKey(KeyCode.Alpha1))
        {
            selectedweapon = 0;
            weaponsetactive();

        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            selectedweapon = 1;
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


               

                if (pickupobject != null)
                {
                    if(pickupobject == Hit.transform.gameObject)
                    {
                        pickupobject.GetComponent<itemforpickup>().CANVAS.SetActive(true);

                    }

                    else
                    {
                        pickupobject.GetComponent<itemforpickup>().CANVAS.SetActive(false);

                    }
                   
                }

                pickupobject = Hit.transform.gameObject;

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

            else
            {
                if(pickupobject != null)
                {
                    pickupobject.GetComponent<itemforpickup>().CANVAS.SetActive(false);
                }
            }

          

        }
        else
        {
            if (pickupobject != null)
            {
                pickupobject.GetComponent<itemforpickup>().CANVAS.SetActive(false);
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

    void interactable()
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



            if (Hit.transform.gameObject.tag == "interactable")
            {
                 interactableobject = Hit.transform.gameObject;

                if (interactableobject.GetComponent<DOOR>() != null)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        interactableobject.GetComponent<DOOR>().turnoffHoldEandenablestatus();
                        interactableobject.GetComponent<DOOR>().cancount = true;
                    }
                    else
                    {
                        interactableobject.GetComponent<DOOR>().turnonHoldEanddisablestatus();
                        interactableobject.GetComponent<DOOR>().cancount = false;

                    }
                }

                if (interactableobject.GetComponent<tomb_ground_detection>() != null)
                {
                    if (Input.GetKey(KeyCode.E))
                    {
                        interactableobject.GetComponent<tomb_ground_detection>().turnoffHoldEandenablestatus();
                        interactableobject.GetComponent<tomb_ground_detection>().cancount = true;
                    }
                    else
                    {
                        interactableobject.GetComponent<tomb_ground_detection>().turnonHoldEanddisablestatus();
                        interactableobject.GetComponent<tomb_ground_detection>().cancount = false;

                    }
                }
            }

            else
            {
                if (interactableobject != null)
                {
                    if (interactableobject.GetComponent<DOOR>() != null)
                    {
                        interactableobject.GetComponent<DOOR>().turnoffHoldEanddisablestatus();
                        interactableobject.GetComponent<DOOR>().cancount = false;
                    }

                    if(interactableobject.GetComponent<tomb_ground_detection>() != null)
                    {
                        interactableobject.GetComponent<tomb_ground_detection>().turnoffHoldEanddisablestatus();
                        interactableobject.GetComponent<tomb_ground_detection>().cancount = false;
                    }
                   
                }
               
            }

            if (Hit.transform.gameObject.tag == "Gear")
            {
               go = Hit.transform.gameObject;

                if (go.GetComponent<Gearmanager>() != null)
                {
                    if (go.GetComponent<Gearmanager>().gearplaced == false)
                    {
                        if(Items[selectedweapon] != AllItems[5])
                        {
                            go.GetComponent<Gearmanager>().missingcanvas.SetActive(true);
                            go.GetComponent<Gearmanager>().insertgearcanvas.SetActive(false);
                        }

                        else
                        {
                            go.GetComponent<Gearmanager>().missingcanvas.SetActive(false);
                            go.GetComponent<Gearmanager>().insertgearcanvas.SetActive(true);
                        }
                     
                    }
                    else
                    {

                    }

                    if (Input.GetKey(KeyCode.E))
                    {
                        if (Items[selectedweapon] == AllItems[5])
                        {
                            go.GetComponent<Gearmanager>().gearplaced = true;
                            go.GetComponent<Gearmanager>().gearinserted();

                            Items[selectedweapon].SetActive(false);
                            Items[selectedweapon] = null;
                            

                            if(Items[0] == null && Items[1] != null)
                            {
                                Items[0] = Items[1];
                                Items[1] = null;
                            }

                            weaponsetactive();
                        }
                    }
                }
            }

            else
            {

                if (go != null)
                {

                        go.GetComponent<Gearmanager>().missingcanvas.SetActive(false);
                        go.GetComponent<Gearmanager>().insertgearcanvas.SetActive(false);
                    
                }
            }


            if (Hit.transform.gameObject.tag == "enddoor")
            {
                door = Hit.transform.gameObject;

                if (door.GetComponent<enddoor>() != null)
                {
                    if (door.GetComponent<enddoor>().hasunlockeddoor == false)
                    {
                        if (Items[selectedweapon] != AllItems[6])
                        {
                            door.GetComponent<enddoor>().nokeyfound.SetActive(true);
                            door.GetComponent<enddoor>().unlockdoor.SetActive(false);
                        }

                        else
                        {
                            door.GetComponent<enddoor>().nokeyfound.SetActive(false);
                            door.GetComponent<enddoor>().unlockdoor.SetActive(true);
                        }

                    }
                    else
                    {

                    }
                    if (Input.GetKey(KeyCode.E))
                    {
                        if (Items[selectedweapon] == AllItems[6])
                        {
                            door.GetComponent<enddoor>().hasunlockeddoor = true;
                            door.GetComponent<enddoor>().opendoor();

                            Items[selectedweapon].SetActive(false);
                            Items[selectedweapon] = null;


                            if (Items[0] == null && Items[1] != null)
                            {
                                Items[0] = Items[1];
                                Items[1] = null;
                            }

                            weaponsetactive();
                        }
                    }
                }
            }

            else
            {

                if (door != null)
                {

                    door.GetComponent<enddoor>().nokeyfound.SetActive(false);
                    door.GetComponent<enddoor>().unlockdoor.SetActive(false);

                }
            }

        }

        else
        {

            if (interactableobject != null)
            {
                if (interactableobject.GetComponent<DOOR>() != null)
                {
                    interactableobject.GetComponent<DOOR>().turnoffHoldEanddisablestatus();
                    interactableobject.GetComponent<DOOR>().cancount = false;
                }

                if (interactableobject.GetComponent<tomb_ground_detection>() != null)
                {
                    interactableobject.GetComponent<tomb_ground_detection>().turnoffHoldEanddisablestatus();
                    interactableobject.GetComponent<tomb_ground_detection>().cancount = false;
                }

            }


            if (go!=  null)
            {
                go.GetComponent<Gearmanager>().missingcanvas.SetActive(false);
                go.GetComponent<Gearmanager>().insertgearcanvas.SetActive(false);

            }

            if (door != null)
            {

                door.GetComponent<enddoor>().nokeyfound.SetActive(false);
                door.GetComponent<enddoor>().unlockdoor.SetActive(false);

            }
        }
    }


    public void stopdoorcount()
    {
        if (interactableobject != null)
        {
            if(interactableobject.GetComponent<DOOR>() != null)
            {
                interactableobject.GetComponent<DOOR>().turnoffHoldEanddisablestatus();
                interactableobject.GetComponent<DOOR>().cancount = false;
            }
          
        }

    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Camera.transform.position,Camera.transform.position +  Camera.transform.forward * safe_range);

    }
}
