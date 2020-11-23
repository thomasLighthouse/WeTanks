using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public GameObject turretGun;
    GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        gun = Instantiate(turretGun, new Vector3(transform.position.x, transform.position.y, transform.position.z - 1), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
