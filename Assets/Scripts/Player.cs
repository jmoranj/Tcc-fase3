using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float horizontal = 0;
    public bool onGround;
    private Rigidbody2D rb;
    public LayerMask groundMask;

    public PhysicsMaterial2D bounceMat, normalMat;
    public bool podePular = true;
    public float valorPulo = 0.0f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal != 0)
        {
            transform.localScale = new Vector3(horizontal, 1, 1);
        }
       

        if(valorPulo == 0.0f && onGround)
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        onGround = Physics2D.OverlapBox(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f),
        new Vector2(0.9f, 0.4f), 0f, groundMask);

        if(valorPulo > 0)
        {
            rb.sharedMaterial = bounceMat;
        }
        else
        {
            rb.sharedMaterial = normalMat;      
        }

        if(Input.GetKey("space") && onGround && podePular)
        {
            valorPulo += 0.1f;
        }

        if(Input.GetKeyDown("space")&& onGround && podePular)
        {
            rb.velocity = new Vector2(0.0f, rb.velocity.y);
        }

        if(valorPulo >= 20f && onGround)
        {
            float tempx = horizontal * speed;
            float tempy = valorPulo;
            rb.velocity = new Vector2(tempx, tempy);
            Invoke("ResetJump", 0.2f);
        }

        if (Input.GetKeyUp("space"))
        {
            if (onGround)
            {
                rb.velocity = new Vector2(horizontal * speed, valorPulo);
                valorPulo = 0.0f;
            }
            podePular = true;
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        onGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onGround = false;
    }

    void ResetJump()
    {
        podePular = false;
        valorPulo = 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 1f), new Vector2(0.9f, 0.8f));
    }


}


