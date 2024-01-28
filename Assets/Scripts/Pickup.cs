using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Interact scrInteract;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (scrInteract.talk == false)
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                if (hit.collider != null && hit.collider.CompareTag("Pickup"))
                {
                    isPick pickScript = hit.collider.GetComponent<isPick>();
                    pickScript.Picked();
                }
          
            }
        }
        //selon l'état du jeu, on vérifie pas les memes booléens
        // Si on clic sur un élément on rend visible l'élément en bas
        // 

        // prévoir l'élément visible avant la bonne step, le squelette


    }
}
