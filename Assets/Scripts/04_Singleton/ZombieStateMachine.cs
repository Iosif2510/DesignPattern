using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStateMachine : MonoBehaviour
{
    private enum ZombieState
    {
        Idle,
        Track,
        Attack,
        Die
    }
    
    private ZombieState currentState = ZombieState.Idle;

    private Transform player;

    private float startTrackDistance = 20f;
    private float attackDistance = 5f;

    private float health = 100f;

    private void Update()
    {
        switch (currentState)
        {
            case ZombieState.Idle:
                Idle();
                break;
            case ZombieState.Track:
                Track();
                break;
            case ZombieState.Attack:
                Attack();
                break;
            case ZombieState.Die:
                Die();
                break;
        }
        
        if (health <= 0)
        {
            currentState = ZombieState.Die;
        }
    }
    
    private void Idle()
    {
        if (Vector3.SqrMagnitude(transform.position - player.position) < startTrackDistance * startTrackDistance)
        {
            currentState = ZombieState.Track;
        }
    }
    
    private void Track()
    {
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            currentState = ZombieState.Attack;
        }

        if (Vector3.SqrMagnitude(transform.position - player.position) > startTrackDistance * startTrackDistance)
        {
            currentState = ZombieState.Idle;
        }
        else
        {
            transform.LookAt(player);
            transform.position += transform.forward * Time.deltaTime;
        }
    }
    
    private void Attack()
    {
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            currentState = ZombieState.Track;
        }
        else
        {
            // Attack
        }
    }
    
    private void Die()
    {
        Destroy(gameObject);
    }
}
