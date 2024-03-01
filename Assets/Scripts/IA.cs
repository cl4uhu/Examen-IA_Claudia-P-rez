using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA : MonoBehaviour
{

    enum State
    {
        Patrolling,
        Chasing,
        Attacking
    }

    private State currentState; 
    private NavMeshAgent agent; 
    private Transform player; 
    [SerializeField] private Transform[] patrolPoints; 
    [SerializeField] private float detectionRange; 
    [SerializeField] private float attackingRange; 
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player"); 
    }
    
    void Start()
    {
        SetRandomPoint(); 
        currentState = State.Patrolling; 
    }

    void Update()
    {
        switch (currentState)
        {
            case State.Patrolling:
                Patrol(); 
            break; 
            case State.Chasing:
                Chase(); 
            break; 
            case State.Attackig:
                Attack(); 
            break; 
        }
    }

    void Patrol()
    {
        if(IsInRange(detectionRange) == true)
        {
            currentState = State.Chasing;
        }
        
        if(agent.remainingDistance < 0.5f)
        {
            SetRandomPoint();
        }
    }

    void Chase()
    {
        if(IsInRange(detectionRange) == false)
        {
            SetRandomPoint();
            currentState = State.Patrolling;
        }
        
        if(IsInRange(_attackingRange) == true)
        {
            currentState = State.Attacking;
        }
        
        agent.destination = player.position;
    }
    
    void Attack()
    {
        Debug.Log("Atacando");
        currentState = State.Chasing; 
    }

    void SetRandomPoint()
    {
        agent.position = patrolPoints(Random.Range(0, patrolPoints.Length - 1)) < range; 
    }

    bool IsInRange(float range)
    {

    }

    void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere = 

        Gizmos.Color = Color.red;
        Gizmos.DrawWireSphere = 
    }
}
