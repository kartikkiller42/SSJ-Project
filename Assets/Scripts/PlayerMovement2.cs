using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Tutorial followed: https://www.youtube.com/watch?v=dwcT-Dch0bA&t=1012s
public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController2D controller;

    private float horizontalMove = 0f;

    public float runSpeed = 40f;

    public bool jump = false;

    public bool isJumping;

    public ParticleSystem particleDeath;
    public GameObject spriteRef;

    public Animator animator;
    // Start is called before the first frame update
    void Awake()
    {
        animator = spriteRef.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw(("Horizontal"))*runSpeed;
        if(horizontalMove != 0)
        {
            animator.SetBool("move", true);
        }
        if (horizontalMove == 0)
        {
            animator.SetBool("move", false);
        }
        if (Input.GetButtonDown(("Jump")))
        {
            jump = true;
            isJumping = true;
        }
        if (!controller.m_Grounded && isJumping)
        {
            animator.SetBool("jumpL", true);
            animator.SetBool("landanim", true);
        }
        if (controller.m_Grounded)
        {
            animator.SetBool("jumpL", false);
            animator.SetBool("landanim", false);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove*Time.fixedDeltaTime,false,jump);
        jump = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(Death());

        }
        else if (collision.gameObject.tag == "Scythe")
        {
            Debug.Log("WINWIN");
            
            SceneManager.LoadScene("LastScene");
        }
    }
    IEnumerator Death()
    {
        //disable sprite
        spriteRef.SetActive(false);
        //spawn particle effect
        Instantiate(particleDeath, transform.position, transform.rotation);
        yield return new WaitForSeconds(3f);
        //reset level
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
