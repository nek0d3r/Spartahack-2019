using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D playerBoxCollider;
    
    private float distToGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        playerBoxCollider = GetComponent<BoxCollider2D>();

        distToGround = playerBoxCollider.bounds.extents.y + 0.1f;
    }

    bool isGrounded()
    {
        foreach(var i in Physics2D.RaycastAll(transform.position, Vector3.down * (distToGround + 0.5f)).Where(x => x.collider.name != "Player"))
        {
            Debug.Log(i.collider.name);
        }
        return Physics2D.RaycastAll(transform.position, Vector3.down * (distToGround + 0.5f)).Where(x => x.collider.name != "Player").ToList().Count > 0;
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * (distToGround + 0.5f), Color.blue, Time.deltaTime);
        var input = Input.GetAxis("Horizontal");

        playerRigidbody.velocity = new Vector2(input * 5f, playerRigidbody.velocity.y);

        if(input != 0)
        {
            playerSpriteRenderer.flipX = input < 0;
        }
        
        var jump = Input.GetButton("Jump");
        
        if(jump && isGrounded())
        {
            Debug.Log("jump!");
            playerRigidbody.AddForce(new Vector2(0, 10f));
        }
    }
}
