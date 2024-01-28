using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{
    public Transform player;
    public float speedFollow = 5f;
    private float limitRightX;
    private float limitLeftX;
    public Move scrMove;


    //dezoom progressif en sortant de la maison

    void Start()
    {
        limitRightX = 150f;
        limitLeftX = 10f;
    }


    void Update()
    {
        player = scrMove.controlled;

        FollowPlayer();
    }

    void FollowPlayer()
    {
        float newPositionX = Mathf.Lerp(transform.position.x, player.position.x, speedFollow * Time.deltaTime);

        // Limitez la position X de la caméra pour éviter de sortir des bords de l'écran.
        newPositionX = Mathf.Clamp(newPositionX, limitLeftX, limitRightX);

        // Appliquez la nouvelle position.
        transform.position = new Vector3(newPositionX, transform.position.y, -5);
    }

}
