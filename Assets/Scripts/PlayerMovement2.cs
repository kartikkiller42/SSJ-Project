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

    public ParticleSystem particleDeath;
    public GameObject spriteRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw(("Horizontal"))*runSpeed;
        if (Input.GetButtonDown(("Jump")))
        {
            jump = true;
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
            //end cutscene
            //SceneManager.LoadScene();
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
