﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreadTracks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SelfDestruct", 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SelfDestruct() {
        Destroy(gameObject);
    }
}
