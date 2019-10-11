using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator anime;

    public float runSpeed = 3.0f;
    //public float walkBackspeed = 2.0f;
    public float rotateSpeed = 80.0f;
    float gravity = 20;
    float jumpHeight = 3;

    //audioclips for sound
    public AudioSource running;
    

    Vector3 moveDir = Vector3.zero;
   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anime = GetComponentInChildren<Animator>();
        running = GetComponent<AudioSource>();
       
        
    }


    // Update is called once per frame


    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") *runSpeed;
        float deltaZ = Input.GetAxis("Vertical") *runSpeed;
        Vector3 movement = new Vector3(deltaX,0,deltaZ);
        movement = Vector3.ClampMagnitude(movement,runSpeed);
       

        movement.y -= gravity;

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        //change animation from foward and backward
        if (deltaZ==0)
        {
            Debug.Log("I should be idle");
            anime.SetInteger("condition", 0);
           
        }
        if (deltaZ<0)
        {
            Debug.Log("I should walk backwards");
            anime.SetInteger("condition", 2);
            
        }
        if (deltaZ > 0)
        {
            
            Debug.Log("I should running ");
            anime.SetInteger("condition", 1);
        }
        if (deltaX>0)
        {
           
            anime.SetInteger("condition", 4);
        }
        if (deltaX < 0)
        {
          
            anime.SetInteger("condition", 3);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("I should be jumping");
            anime.SetInteger("condition", 5);
            characterController.Move(Vector3.up*jumpHeight);
        }

        //for sound
        if (Input.GetButtonDown("Horizontal")||Input.GetButtonDown("Vertical"))
        {
            running.Play();
        }else if (!Input.GetButtonDown("Horizontal") && !Input.GetButtonDown("Vertical"))
        {
            running.Stop();
        }
        characterController.Move(movement);
        

        

    }

    IEnumerator playerRun()
    {

        //while (isRunning)
        //{
       ///     AudioSource audio = GetComponent<AudioSource>();
        //    audioSounds.PlayOneShot(running);


            
            Debug.Log("Player running");
            yield return new WaitForSeconds(1f);
        }

    }



