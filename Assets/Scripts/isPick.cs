using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPick : MonoBehaviour
{
    private bool picked = false;
    public Interact scrInteract;
    public Renderer objectAssociated;


    void Start()
    {
    }


    void Update()
    {
        if (picked)
        {
            objectAssociated.enabled = false;
            gameObject.SetActive(false);
        }
    }

    public void Picked()
    {
        picked = true;
    }
}
