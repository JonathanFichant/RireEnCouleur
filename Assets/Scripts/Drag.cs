using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public Transform SlotEmot1;
    public Transform SlotEmot2;
    public Transform SlotEmot3;
    public bool isDrag = false;
    public float distanceDetection = 0.5f;
    private bool target = true;
    private string nameObject;
    public int order = 0;
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public Busy busyScript1;
    public Busy busyScript2;
    public Busy busyScript3;
    private bool slotDetected = false;

    void Start()
    {
        nameObject = gameObject.name;
        Slot1 = GameObject.Find("Slot1");
        Slot2 = GameObject.Find("Slot2");
        Slot3 = GameObject.Find("Slot3");
        busyScript1 = Slot1.GetComponent<Busy>();
        busyScript2 = Slot2.GetComponent<Busy>();
        busyScript3 = Slot3.GetComponent<Busy>();
    }

    // Update is called once per frame
    void Update()
    {
     
        if (isDrag)
        {
            MoveDrag();
            if (order == 1)
            {
                busyScript1.isBusy = false;
            }
            else if (order == 2)
            {
                busyScript2.isBusy = false;
            }
            if (order == 3)
            {
                busyScript3.isBusy = false;
            }
        }

        if (Input.GetMouseButtonUp(0) && isDrag)
        {
            isDrag = false;
            DetectSlot();
            //check si slot en dessous sinon revient au slot de base
        }

        if (!target)
        {
            if (nameObject == "Emot1" || nameObject == "Emot4" || nameObject == "Emot7" || nameObject == "Emot10")
            {
                transform.position = SlotEmot1.position;
            }
            if (nameObject == "Emot2" || nameObject == "Emot5" || nameObject == "Emot8" || nameObject == "Emot11")
            {
                transform.position = SlotEmot2.position;
            }
            if (nameObject == "Emot3" || nameObject == "Emot6" || nameObject == "Emot9" || nameObject == "Emot12")
            {
                transform.position = SlotEmot3.position;
            }
            order = 0;
            target = true;
        }
    }


    void MoveDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y,-3.5f);
    }

    void DetectSlot()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, distanceDetection);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Slot"))
            {
                slotDetected = true;
                Busy busyScript = collider.gameObject.GetComponent<Busy>();
                if (collider.name == "Slot1")
                {   
                    if (busyScript.isBusy == false)
                    {
                        order = 1;
                        busyScript.isBusy = true;
                        transform.position = collider.transform.position;
                        target = true;
                    }
                    else
                    {
                        target = false;
                    }
                }
                else if (collider.name == "Slot2")
                {
                    if (busyScript.isBusy == false)
                    {
                        order = 2;
                        busyScript.isBusy = true;
                        transform.position = collider.transform.position;
                        target = true;
                    }
                    else
                    {
                        target = false;
                    }
                }
                else if (collider.name == "Slot3")
                {
                    if (busyScript.isBusy == false)
                    {
                        order = 3;
                        busyScript.isBusy = true;
                        transform.position = collider.transform.position;
                        target = true;
                    }
                    else
                    {
                        target = false;
                    }
                }
                
            }
            else if (!slotDetected)
            {
                target = false;
            }
        }
        slotDetected = false;
    }
}

