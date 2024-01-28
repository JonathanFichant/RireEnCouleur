using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Talking : MonoBehaviour
{
    public bool isTalking = false;
    public Transform player;
    public Transform bulleBD;
    public Transform SelectionEmot;
    public bool clic = false;
    private GameObject objectDrag;

    void Start()
    {

    }

    void Update()
    {
        if (isTalking)
        {
            bulleBD.position = player.position + new Vector3(0f, 5f, -2f);
            SelectionEmot.position = player.position + new Vector3(0f, -1.5f, -2f);
        }
        else
        {
            bulleBD.position = new Vector3(-5f, -9f,-1.5f);
            SelectionEmot.position = new Vector3(0f, -9f,-1.5f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            

            if (hit.collider != null && hit.collider.CompareTag("Emot"))
            {
                clic = true;
                hit.collider.GetComponent<Drag>().isDrag = true;
            }
        }
        
    }
}
