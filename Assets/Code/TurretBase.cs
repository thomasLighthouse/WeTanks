using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public GameObject turretGun;
    public GameObject shell;
    public GameObject explosion;
    GameObject gun;
    int count;
    
    // Start is called before the first frame update
    void Start()
    {
        count = Random.Range(0, 100);
        gun = Instantiate(turretGun, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Game.GameActive)
        {

            if (count < 500) {
                count = count + 1;
            } else {
                Instantiate(shell, gun.transform.position + .95f * gun.transform.up, gun.transform.rotation);
                count = Random.Range(0, 100);
            }

        }

    }

    internal void OnCollisionEnter2D (Collision2D other) {

        if (other.gameObject.name.Contains("Shell")){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(gun);
        }

    }


}
