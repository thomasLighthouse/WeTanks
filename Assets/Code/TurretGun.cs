using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGun : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Camera.main.WorldToViewportPoint(player.transform.position);
        Vector3 objpos = Camera.main.WorldToViewportPoint(transform.position);

        
        Vector2 relobjpos = new Vector2 (objpos.x - 0.5f, objpos.y - 0.5f);
        Vector2 realPlayerPos = new Vector2 (playerPos.x - 0.5f, playerPos.y - 0.5f) - relobjpos;

        float angle = Vector2.Angle (Vector2.up, realPlayerPos);

        if (realPlayerPos .x > 0){
            angle = 360 - angle;
        }  
         Quaternion quat = Quaternion.identity;
         quat.eulerAngles = new Vector3 (0, 0, angle); //Changing angle
         transform.rotation = quat;
    }
}
