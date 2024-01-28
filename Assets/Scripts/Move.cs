using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public float speedWalk = 15f;
    public bool isTalking = false;
    public int stepGame = 0;
    public Transform NPC0;
    public Transform NPC1;
    public Transform NPC2;
    public Transform NPC3;
    public Transform NPC4;

    /*public Sprite spriteNPC0;
    public Sprite spriteNPC1;
    public Sprite spriteNPC2;
    public Sprite spriteNPC3;
    public Sprite colorNPC0;
    public Sprite colorNPC1;
    public Sprite colorNPC2;
    public Sprite colorNPC3;*/

    public SwitchSprite scrNPC0;
    public SwitchSprite scrNPC4;
    public SwitchSprite scrNPC2;
    public SwitchSprite scrNPC3;

    public Transform controlled;
    public Interact scrInteract;
    private float maxX;
    //public Sprite ActualSprite;
    private bool directionSprite = true;
    private bool Demon = true;

    void Start()
    {
        
        controlled = NPC0;
        maxX = 13f;
        
    }


    void Update()
    {
        /*if (setup == true)
        {
            SetUpSprite();
        }*/

        SetUpSprite();
        if (!isTalking)
        {
            Walk();
        }


        switch (stepGame)
        {
            case 0:
                controlled = NPC0;
                if (!isTalking)
                {
                    scrInteract.PlaceObjectNPC1();
                }
                maxX = 13f;
                
                break;
            case 1:
                controlled = NPC0;
                if (!isTalking)
                {
                    scrInteract.PlaceObjectNPC2();
                }
                maxX = 64.5f;
                break;

            case 2:
                controlled = NPC2;
                if (!isTalking)
                {
                    scrInteract.PlaceObjectNPC3();
                }
                maxX = 99f;

                break;

            case 3:
                if (Demon)
                {
                    SetUpDemon();
                }
                controlled = NPC3;
                if (!isTalking)
                {
                    scrInteract.PlaceObjectNPC4();
                }
                maxX = 161.5f;
                break;

            case 4:
                controlled = NPC3;
                //FIN , pas besoin de case 4
                // changement de scene vers écran de fin

                break;

            default:
                break;
        }
    }

    void Walk()
    {
        if ((Input.GetKey("a") || Input.GetKey("left")) && controlled.position.x >= -7) //Q
        {
            Vector2 walking = new Vector2(-1, 0) * speedWalk * Time.deltaTime;
            controlled.transform.Translate(walking);
            if (directionSprite)
            {
                RotateSprite();
            }
        }
        else if ((Input.GetKey("d") || Input.GetKey("right")) && controlled.position.x <= maxX ) // valeur à changer à chaque next step
        {
            Vector2 walking = new Vector2(1, 0) * speedWalk * Time.deltaTime;
            controlled.transform.Translate(walking);
            if (!directionSprite)
            {
                RotateSprite();
            }
        }
    }


    public void SetUpSprite()
    {
        switch (stepGame)
        {
            case 0:
                break;
            case 1:
                scrNPC0.GreyToColor();
                break;
            case 2:
                scrNPC2.GreyToColor();
                break;
            case 3:
                scrNPC3.GreyToColor();
                break;
            case 4:
                scrNPC4.GreyToColor();
                break;
        }

    }
    
    void RotateSprite()
    {
        Vector2 newScale = controlled.transform.localScale;
        newScale.x *= -1;
        controlled.transform.localScale = newScale;
        directionSprite = !directionSprite;
        //
    }

    void SetUpDemon()
    {
        directionSprite = false;
        Demon = false;
    }

}


  
