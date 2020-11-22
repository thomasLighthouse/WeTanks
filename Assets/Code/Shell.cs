using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float speed = 2f;
    private int bounces = 0;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = speed * transform.up;
    }

    // Update is called once per frame
    void Update()
    {

    }

    internal void OnCollisionEnter2D (Collision2D other) {

        if (other.gameObject.name.Contains("Wall")){
            Debug.Log("WALL");
        }

        if (other.gameObject.name.Contains("Player")){
            Destroy(gameObject);
        }

    }


}
