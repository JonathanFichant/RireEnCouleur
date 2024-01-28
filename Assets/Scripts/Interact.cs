using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public bool talk = false;
    public float distanceDetection = 3.5f;
    public string nameNPC;
    public Talking scrTalking;
    public Move scrMove;
    public GameObject Emot1;
    public GameObject Emot2;
    public GameObject Emot3;
    public GameObject Emot4;
    public GameObject Emot5;
    public GameObject Emot6;
    public GameObject Emot7;
    public GameObject Emot8;
    public GameObject Emot9;
    public GameObject Emot10;
    public GameObject Emot11;
    public GameObject Emot12;
    private Transform emotSlot1Transform;
    private Transform emotSlot2Transform;
    private Transform emotSlot3Transform;
    public GameObject Slot1;
    public GameObject Slot2;
    public GameObject Slot3;
    public Busy busyScript1;
    public Busy busyScript2;
    public Busy busyScript3;
    private bool win = false;
    public Transform transformNPC2;
    public Transform transformNPC3;
    public int numberObjectPicked = 0;



    void Start()
    {
        Slot1 = GameObject.Find("Slot1");
        Slot2 = GameObject.Find("Slot2");
        Slot3 = GameObject.Find("Slot3");
        busyScript1 = Slot1.GetComponent<Busy>();
        busyScript2 = Slot2.GetComponent<Busy>();
        busyScript3 = Slot3.GetComponent<Busy>();
        CheckPositionEmotSlot();

    }

    void Update()
    {
        Talk();

        if (talk)
        {
            checkWin();
        }
        if (win)
        {
            ResetWin();
        }
    }


    void Talk()
    {
        if (Input.GetKey("space")) //besoin de 2 frames pour tp les emot, bizarre
        {
            if (numberObjectPicked == 3){
                if (DetectObjectNPC())
                {
                    talk = true;
                    scrMove.isTalking = true;
                    scrTalking.isTalking = true;
                }
            }

        }
    }

    public bool DetectObjectNPC()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(scrMove.controlled.transform.position, distanceDetection);

        foreach (Collider2D collider in colliders)
        {
            if ((collider.name == "NPC1" && scrMove.stepGame == 0) || (collider.name == "NPC2" && scrMove.stepGame == 1) || (collider.name == "NPC3" && scrMove.stepGame == 2) || (collider.name == "NPC4" && scrMove.stepGame == 3))
            {
                nameNPC = collider.gameObject.name;
                return true;
            }
        }
        return false;
    }

    void OpenInteraction()
    {
        if (talk)
        {
            switch (nameNPC) //ou nameNPC
            {
                case "NPC1":
                    PlaceObjectNPC1(); // peut faire bug ?
                    break;

                case "NPC2":
                    PlaceObjectNPC2();
                    break;

                case "NPC3":
                    PlaceObjectNPC3();
                    break;

                case "NPC4":
                    PlaceObjectNPC4();
                    break;

                default:
                    break;
            }
        }
    }

    void checkWin()
    {

        switch (nameNPC)
        {
            case "NPC1": //soluce order 321
                Drag scriptDrag1 = Emot1.GetComponent<Drag>();
                Drag scriptDrag2 = Emot2.GetComponent<Drag>();
                Drag scriptDrag3 = Emot3.GetComponent<Drag>();
                if (scriptDrag1.order == 3 && scriptDrag2.order == 2 && scriptDrag3.order == 1)
                {
                    //WIN
                    win = true;
                    Emot1.SetActive(false); Emot2.SetActive(false) ; Emot3.SetActive(false) ;
                    //FX de win + autres feedback

                }
                    break;

            case "NPC2": // soluce order 123
                Drag scriptDrag4 = Emot4.GetComponent<Drag>();
                Drag scriptDrag5 = Emot5.GetComponent<Drag>();
                Drag scriptDrag6 = Emot6.GetComponent<Drag>();
                if (scriptDrag4.order == 1 && scriptDrag5.order == 2 && scriptDrag6.order == 3)
                {

                    // WIN
                    win = true; 
                    Emot4.SetActive(false); Emot5.SetActive(false); Emot6.SetActive(false);
                    scrTalking.player = transformNPC2;
                    // PASSER LE CONTROLE AU NPC2
                }

                break;

            case "NPC3": // soluce order 213
                Drag scriptDrag7 = Emot7.GetComponent<Drag>();
                Drag scriptDrag8 = Emot8.GetComponent<Drag>();
                Drag scriptDrag9 = Emot9.GetComponent<Drag>();
                if (scriptDrag7.order == 2 && scriptDrag8.order == 1 && scriptDrag9.order == 3)
                {
                    // WIN
                    win = true;
                    Emot7.SetActive(false); Emot8.SetActive(false); Emot9.SetActive(false);
                    scrTalking.player = transformNPC3;
                    // PASSER LE CONTROLE AU NPC3
                }

                break;

            case "NPC4": // soluce order 213
                Drag scriptDrag10 = Emot10.GetComponent<Drag>();
                Drag scriptDrag11 = Emot11.GetComponent<Drag>();
                Drag scriptDrag12 = Emot12.GetComponent<Drag>();
                if (scriptDrag10.order == 2 && scriptDrag11.order == 1 && scriptDrag12.order == 3)
                {
                    // WIN
                    win = true;
                    Emot10.SetActive(false); Emot11.SetActive(false); Emot12.SetActive(false);
                    // WIN FINALE
                }

                break;

            default:
                break;
        }
    }



    void CheckPositionEmotSlot()
    {
        GameObject emotSlot1 = GameObject.Find("SlotEmot1");
        emotSlot1Transform = emotSlot1 != null ? emotSlot1.transform : null;
        GameObject emotSlot2 = GameObject.Find("SlotEmot2");
        emotSlot2Transform = emotSlot2 != null ? emotSlot2.transform : null;
        GameObject emotSlot3 = GameObject.Find("SlotEmot3");
        emotSlot3Transform = emotSlot3 != null ? emotSlot3.transform : null;
    }


    public void PlaceObjectNPC1()
    {
        Transform transformEmot1 = Emot1.transform;
        Transform transformEmot2 = Emot2.transform;
        Transform transformEmot3 = Emot3.transform;

        transformEmot1.position = emotSlot1Transform.position;
        transformEmot2.position = emotSlot2Transform.position;
        transformEmot3.position = emotSlot3Transform.position;
        
    }

    public void PlaceObjectNPC2()
    {
        Transform transformEmot4 = Emot4.transform;
        Transform transformEmot5 = Emot5.transform;
        Transform transformEmot6 = Emot6.transform;

        transformEmot4.position = emotSlot1Transform.position;
        transformEmot5.position = emotSlot2Transform.position;
        transformEmot6.position = emotSlot3Transform.position;
    }

    public void PlaceObjectNPC3()
    {
        Transform transformEmot7 = Emot7.transform;
        Transform transformEmot8 = Emot8.transform;
        Transform transformEmot9 = Emot9.transform;

        transformEmot7.position = emotSlot1Transform.position;
        transformEmot8.position = emotSlot2Transform.position;
        transformEmot9.position = emotSlot3Transform.position;
    }

    public void PlaceObjectNPC4()
    {
        Transform transformEmot10 = Emot10.transform;
        Transform transformEmot11 = Emot11.transform;
        Transform transformEmot12 = Emot12.transform;

        transformEmot10.position = emotSlot1Transform.position;
        transformEmot11.position = emotSlot2Transform.position;
        transformEmot12.position = emotSlot3Transform.position;
    }

    void ResetWin()
    {
        // fx win sound particle
        talk = false;
        scrMove.isTalking = false;
        scrTalking.isTalking = false;
        busyScript1.isBusy = false;
        busyScript2.isBusy = false;
        busyScript3.isBusy = false;
        win = false;
        numberObjectPicked = 0;
        NextStep();
    }


    void NextStep()
    {
        scrMove.stepGame++;
    }

}
