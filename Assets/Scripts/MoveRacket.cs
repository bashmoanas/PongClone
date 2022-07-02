using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    // Vertical or Vertical2 Axis
    public string axis;

    // This is the speed of the racket mouvement
    public float speed = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // This is our GetAxisRaw input (not smoothed) multiplied by the speed we defined.
        // It checks for the axis variable.
        float velocity = Input.GetAxisRaw(axis) * speed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity);
        
    }
}
