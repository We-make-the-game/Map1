using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector2(transform.localPosition.x-0.01f, transform.localPosition.y);
        if (transform.localPosition.x <= -5)
        {
            transform.localPosition = new Vector2(0, transform.localPosition.y);
        }
    }

    void FixedUpdate()
    {
        transform.localPosition = new Vector2(transform.localPosition.x-0.005f, transform.localPosition.y);
        if (transform.localPosition.x <= -5)
        {
            transform.localPosition = new Vector2(0, transform.localPosition.y);
        }
    }
}
