using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Transform controlled;
    public Interact scrInteract;

    void Start()
    {
        controlled = NPC0;
        // empecher le joueur d'aller trop loin, mettre  des collider
        
    }


    void Update()
    {
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
                
                break;
            case 1:
                controlled = NPC0;
                if (!isTalking)
                {
                    scrInteract.PlaceObjectNPC2();
                }
                    
                break;

            case 2:
                controlled = NPC2;
                if (!isTalking)
                {
                    scrInteract.PlaceObjectNPC3();
                }
                    
                break;

            case 3:
                controlled = NPC3;
                if (!isTalking)
                {
                    scrInteract.PlaceObjectNPC4();
                }
                    
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
        }
        else if ((Input.GetKey("d") || Input.GetKey("right")) && controlled.position.x <= 152 ) // valeur à changer à chaque next step
        {
            Vector2 walking = new Vector2(1, 0) * speedWalk * Time.deltaTime;
            controlled.transform.Translate(walking);
        }
    }
}


  
