using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject playerGun;
    public GameObject shell;
    public float speed = 2f;

    GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        gun = Instantiate(playerGun, transform.position + 0.22f * Vector3.down, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("a")) {
            _rb.angularVelocity = 150;
        } else if (Input.GetKey("d")) {
            _rb.angularVelocity = -150;
        } else {
            _rb.angularVelocity = 0;
        }

        if (Input.GetKey("w")) {
            _rb.velocity = speed * transform.up;
        } else if (Input.GetKey("s")) {
            _rb.velocity = -speed * transform.up;
        } else {
            _rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(shell, gun.transform.position + .95f * gun.transform.up, gun.transform.rotation);
        }
        
        gun.transform.position = transform.position - 0.22f * transform.up;

    }
}
