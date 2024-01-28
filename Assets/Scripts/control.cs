using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    public int stepGame = 0;
    public Transform controlled;
    public Transform NPC0;
    public Transform NPC1;
    public Transform NPC2;
    public Transform NPC3;
    public Transform NPC4;

    void Start()
    {
        controlled = NPC0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (stepGame)
        {
            case 0:
                controlled = NPC0;
                break;
            case 1:
                controlled = NPC0;
                break;

            case 2:
                controlled = NPC2;
                break;

            case 3:
                controlled = NPC3;
                break;

            case 4:
                controlled = NPC4;
                break;

            default:
                break;
        }
    }
}
