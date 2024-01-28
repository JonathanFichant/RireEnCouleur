using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSprite : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite colorfulSprite;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GreyToColor()
    {
        spriteRenderer.sprite = colorfulSprite;
    }
}
