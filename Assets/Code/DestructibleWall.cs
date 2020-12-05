using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void OnCollisionEnter2D (Collision2D other) {

        if (other.gameObject.name.Contains("Shell")){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
