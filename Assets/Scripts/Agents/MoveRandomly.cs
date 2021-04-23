﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveRandomly : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] int distance;
    [SerializeField] float speed;
    [SerializeField] int newtarget;
    [SerializeField] NavMeshAgent navMeshAgent;
    [SerializeField] Vector3 Target;
    [SerializeField] Animator agentAnimation;

    float myX;
    float myZ;
    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        myX = gameObject.transform.position.x;
        myZ = gameObject.transform.position.z;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= newtarget){
            StartCoroutine(MovementCoroutine());
        }

    }

    IEnumerator MovementCoroutine()
    {
        agentAnimation.SetBool("isWalking", false);
        navMeshAgent.SetDestination(transform.position);
        yield return new WaitForSeconds(2f);
        //float myX = gameObject.transform.position.x;
        //float myZ = gameObject.transform.position.z;
        
        float xPos = myX + Random.Range(myX - distance, myX + distance);
        float zPos = myZ + Random.Range(myZ - distance, myZ + distance);

        Target = new Vector3(xPos, gameObject.transform.position.y, zPos);
        navMeshAgent.SetDestination(Target);
        agentAnimation.SetBool("isWalking", true);
        timer = 0;
    }

}
