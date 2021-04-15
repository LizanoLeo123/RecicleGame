﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float jumpSpeed = 400f;
    [SerializeField] Animator playerAnimator;
    Vector3 forward, right;
    bool isGrounded = true;

    
    void Start()
    {
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        if(Input.GetAxis("HorizontalKey") == 0 && Input.GetAxis("VerticalKey") == 0){
            playerAnimator.SetBool("isWalking", false);
        }else if(Input.GetAxis("HorizontalKey") < 0 ){
            playerAnimator.SetBool("isWalking", true);
        }else if(Input.GetAxis("HorizontalKey") > 0 ){
            playerAnimator.SetBool("isWalking", true);
        }else if(Input.GetAxis("VerticalKey") < 0 ){
            playerAnimator.SetBool("isWalking", true);
        }else if(Input.GetAxis("VerticalKey") > 0 ){
            playerAnimator.SetBool("isWalking", true);
        }
        
        if(isGrounded){
            if(Input.GetKeyDown(KeyCode.Space)){
                playerRb.AddForce(Vector3.up * jumpSpeed);
                isGrounded = false;
                playerAnimator.SetTrigger("isJump");
            }
        }
        
        if(Input.anyKey){
            move();
        }
    }

    void move(){
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;

    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
    }
}
