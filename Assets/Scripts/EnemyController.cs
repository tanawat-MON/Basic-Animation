using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    
    float speed = 2f;
    //Rigidbody rb;
    NavMeshAgent agent;

    Animator anim;

    [SerializeField]
    List<Transform> waypoints = new List<Transform>();
    [SerializeField]
    float waitTimeAtPoint = 2f;
    [SerializeField]
    bool patrolInLoop = true;

    int currentWaypointIndex = 0;
    bool iswaiting = false;
    bool movingForward = true;


    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        if (waypoints == null || waypoints.Count == 0) return;
        GoToCurrentWaypoint();
    }

    void Update()
    {
        if (waypoints.Count == 0 || iswaiting) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetTrigger("Stop");
            agent.speed = 0;
            StartCoroutine(WaitAtWaypoint());
        }
    }
    void GoToCurrentWaypoint()
    {
        if (waypoints.Count == 0) return; 
        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }
    void SelectNextWayPoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
    }

    IEnumerator WaitAtWaypoint()
    {
        iswaiting = true;
        yield return new WaitForSeconds(waitTimeAtPoint);
        SelectNextWayPoint();
        anim.SetTrigger("Walk");
        agent.speed = speed;
        GoToCurrentWaypoint();
        iswaiting = false;
    }
  
}
