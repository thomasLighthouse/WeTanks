using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rb;
    public GameObject playerGun;
    public GameObject shell;
    public GameObject treadTracks;
    public float speed = 2f;
    private bool trackFlag = false;

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
            SpawnTracks(true);
        } else if (Input.GetKey("s")) {
            _rb.velocity = -speed * transform.up;
            SpawnTracks(false);
        } else {
            _rb.velocity = new Vector2(0, 0);
        }

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(shell, gun.transform.position + .95f * gun.transform.up, gun.transform.rotation);
        }
        
        gun.transform.position = transform.position - 0.22f * transform.up;

    }

    internal void OnCollisionEnter2D (Collision2D other) {

        if (other.gameObject.name.Contains("Shell")){
            Destroy(gameObject);
            Destroy(gun);
        }

    }

    internal void SpawnTracks(bool forward){
        if (!trackFlag){
            Vector3 rot = transform.rotation.eulerAngles;
            float direction = 1f;
            if (!forward) {
                direction = -1f;
                rot = new Vector3(rot.x,rot.y,rot.z - 180f);
            }


            Instantiate(treadTracks, new Vector3(transform.position.x, transform.position.y, 2) - direction * 0.35f * transform.up - 0.21f * transform.right, Quaternion.Euler(rot));
            Instantiate(treadTracks, new Vector3(transform.position.x, transform.position.y, 2) - direction * 0.35f * transform.up + 0.21f * transform.right, Quaternion.Euler(rot));
            Invoke("ResetTrackFlag", 0.05f);
            trackFlag = true;
        }
    }

    internal void ResetTrackFlag(){
        trackFlag = false;
    }
}
