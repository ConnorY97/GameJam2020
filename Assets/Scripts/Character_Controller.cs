using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    Character_Controller player1;
    Character_Controller player2;

    [SerializeField] private LayerMask platformLayerMask;
    [SerializeField] private LayerMask wallLayerMask;
    [SerializeField] AudioClip deathAudio;
    [SerializeField] AudioClip jumpAudio;
    [SerializeField] Animator animator;
    public float speed = 6.0f;
    public float jumpPower = 15.0f;
    public float jumpPushPower = 20.0f;
    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;
    private bool canJump;
    private bool canDoubleJump;

    private void Awake()
    {
        player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Character_Controller>();
        player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Character_Controller>();
        rigidBody2D = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        if (isGrounded())
        {
            canDoubleJump = true;
        }

        if (isWalled())
        {
            canJump = true;
        }

        if (this.gameObject.tag == "Player1")
        {
            if (Input.GetKey("a"))
            {
                pos.x -= speed * Time.deltaTime;
            }

            if (Input.GetKey("d"))
            {
                pos.x += speed * Time.deltaTime;
            }

            if (Input.GetKeyDown("w"))
            {

                if (isGrounded())
                {
                    rigidBody2D.AddForce(Vector2.up * jumpPower);
                    //soundManager.PlayAudioClip(deathAudio);
                    //animator.SetTrigger("isJump");
                }

                //else if (Input.GetKeyDown("w"))
                //{
                //    if (canDoubleJump)
                //    {
                //        rigidBody2D.AddForce(Vector2.up * jumpPower);
                //        canDoubleJump = false;
                //    }
                //}

                else if (isWalled())
                {
                    if (canJump)
                    {
                        rigidBody2D.AddForce(Vector2.up * jumpPushPower);
                        canJump = false;
                    }
                }
            }
        }

        if (this.gameObject.tag == "Player2")
        {
            if (Input.GetKey("left"))
            {
                pos.x -= speed * Time.deltaTime;
            }

            if (Input.GetKey("right"))
            {
                pos.x += speed * Time.deltaTime;
            }

            if (Input.GetKeyDown("up"))
            {

                if (isGrounded())
                {
                    rigidBody2D.AddForce(Vector2.up * jumpPower);
                }

                //else if (Input.GetKeyDown("up"))
                //{
                //    if (canDoubleJump)
                //    {
                //        rigidBody2D.AddForce(Vector2.up * jumpPower);
                //        canDoubleJump = false;
                //    }
                //}

                else if (isWalled())
                {
                    if (canJump)
                    {
                        rigidBody2D.AddForce(Vector2.up * jumpPushPower);
                        canJump = false;
                    }
                }

            }
        }

        transform.position = pos;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0.0f, Vector2.down, 0.1f, platformLayerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }

    private bool isWalled()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0.0f, Vector2.up, 0.1f, wallLayerMask);
        //Debug.Log(raycastHit2D.collider);
        return raycastHit2D.collider != null;
    }
}

