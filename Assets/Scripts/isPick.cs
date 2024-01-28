using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPick : MonoBehaviour
{
    private bool picked = false;
    public Interact scrInteract;
    public Renderer objectAssociated;
    public Move scrMove;

    void Start()
    {

    }


    void Update()
    {
        if (picked)
        {
            objectAssociated.enabled = true;
            scrInteract.numberObjectPicked++;
            gameObject.SetActive(false);
            picked = false;
        }
    }

    public void Picked()
    {
        if (gameObject.name == "pickupObjectSkeleton7")
        {
            if (scrMove.stepGame == 2)
            {
                picked = true;
            }
        }
        else
        {
            picked = true;
        }
    }
}
