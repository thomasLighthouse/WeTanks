using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.GameActive)
        {
            Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            Vector3 objpos = Camera.main.WorldToViewportPoint(transform.position);


            Vector2 relobjpos = new Vector2(objpos.x - 0.5f, objpos.y - 0.5f);
            Vector2 relmousepos = new Vector2(mouse.x - 0.5f, mouse.y - 0.5f) - relobjpos;

            float angle = Vector2.Angle(Vector2.up, relmousepos);

            if (relmousepos.x > 0)
            {
                angle = 360 - angle;
            }
            Quaternion quat = Quaternion.identity;
            quat.eulerAngles = new Vector3(0, 0, angle); //Changing angle
            transform.rotation = quat;
        }
    }
}
