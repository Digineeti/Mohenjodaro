using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boat_Motion : MonoBehaviour
{

    Rigidbody2D RD;
    // Start is called before the first frame update
    void Start()
    {
        RD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RD.velocity = new Vector2(0f, 1.5f);
    }
}
