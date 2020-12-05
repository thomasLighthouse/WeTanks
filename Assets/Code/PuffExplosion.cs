using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffExplosion : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    int frame = 0;
    int count = 0;

    public AudioClip puffSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        count = 0;
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        audioSource.PlayOneShot(puffSound, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Game.GameActive)
        {

            if (count < 10) {
                count = count + 1;
            } else {
                count = 0;
                frame = frame + 1;
                if (frame < 4){
                    spriteRenderer.sprite = spriteArray[frame]; 
                } else {
                    Destroy(gameObject);
                }
            }

        }

    }
}
