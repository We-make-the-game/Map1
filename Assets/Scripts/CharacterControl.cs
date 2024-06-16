using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    Rigidbody2D rb;
    Collider2D coll;
    float speed = 5f;
    float jumpForce = 200f;
    public LayerMask groundLayer;
    bool isOnGround;
    int jumpCount;
    bool jumpPress;
    float moveX;
    Animator playerAni;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        playerAni = GameObject.Find("player/obj").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        jumpPress = false;
        if (Input.GetButtonDown("Jump") && jumpCount > 0)
        {
            jumpPress = true;
        }
        CheckOnGround();
        Jump();
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
        if (moveX < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (moveX > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        playerAni.SetFloat("speed", Mathf.Abs(moveX));
    }

    void FixedUpdate()
    {
        
    }

    void CheckOnGround()
    {
        isOnGround = Physics2D.IsTouchingLayers(coll, groundLayer);
    }

    void Jump()
    {
        //在地面上
        if (isOnGround)
        {
            jumpCount = 1;
        }
        //在地面上跳跃 or  //在空中跳跃
        if (jumpPress && (isOnGround || (jumpCount > 0 && !isOnGround)))
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            playerAni.SetTrigger("jump");
            jumpCount--;
            jumpPress = false;
        }
    }
}
