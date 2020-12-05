using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 v; // velocityBeforePhysicsUpdate;
    public GameObject puffExplosion;
    
    public float speed = 2f;
    private int bounces = 0;

    public AudioClip bounceSound;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = speed * transform.up;
        v = _rb.velocity;
    }

    // FixedUpdate is called once per physics step
    void FixedUpdate()
    {
        v = _rb.velocity;
    }

    internal void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name.Contains("Player"))
        {
            BlowUpShell();
        } else if (other.gameObject.name.Contains("Shell")) {
            BlowUpShell();
        } else if (other.gameObject.name.Contains("Turret Base")) {
            BlowUpShell();
        } else if (other.gameObject.name.Contains("Destructible Wall")) {
            BlowUpShell();
        }

        else
        {
            GameObject otherObject = other.gameObject;
            if ((otherObject.GetComponent<Transform>().position.x - otherObject.GetComponent<Renderer>().bounds.extents.x) >= this.GetComponent<Transform>().position.x && v.x > 0)
            {
                _rb.velocity = new Vector2(-v.x, v.y);
                bounces++;
            }
            else if ((otherObject.GetComponent<Transform>().position.x + otherObject.GetComponent<Renderer>().bounds.extents.x) <= this.GetComponent<Transform>().position.x && v.x < 0)
            {
                _rb.velocity = new Vector2(-v.x, v.y);
                bounces++;
            }

            if ((otherObject.GetComponent<Transform>().position.y - otherObject.GetComponent<Renderer>().bounds.extents.y) >= this.GetComponent<Transform>().position.y && v.y > 0)
            {
                _rb.velocity = new Vector2(v.x, -v.y);
                bounces++;
            }
            else if ((otherObject.GetComponent<Transform>().position.y + otherObject.GetComponent<Renderer>().bounds.extents.y) <= this.GetComponent<Transform>().position.y && v.y < 0)
            {
                _rb.velocity = new Vector2(v.x, -v.y);
                bounces++;
            }
            // Rotate bullet
            transform.up = _rb.velocity;
            _rb.angularVelocity = 0;
            if (bounces > 2)
            {
                BlowUpShell();
            } else {
                audioSource.PlayOneShot(bounceSound, 0.05f);
            }
        }

    }


    internal void BlowUpShell(){
        Instantiate(puffExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}