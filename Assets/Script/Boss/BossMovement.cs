using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossMovement : CreatureMove
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float speed;
    [SerializeField] private float delayBetweenMovements = 8f; 
    [SerializeField] private Animator animator;
    private int currentWaypointIndex = 0;
    private bool isMoving = false;
    
    public void StartMovement()
    {
        StartCoroutine(MovementDelay());
    }
    
    IEnumerator MovementDelay()
    {
        while (canMove)
        {
            if (!isMoving && waypoints.Length > 0)
            {
                currentWaypointIndex = Random.Range(0, waypoints.Length);
                
                StartCoroutine(MoveToWaypoint(waypoints[currentWaypointIndex]));
            }
            
            yield return new WaitForSeconds(delayBetweenMovements);
        }
    }
    
    IEnumerator MoveToWaypoint(Transform targetWaypoint)
    {
        isMoving = true;
        
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = targetWaypoint.position;
        float journeyLength = Vector3.Distance(startPosition, targetPosition);
        float startTime = Time.time;
        animator.SetBool("IsWalking", true);
        while (transform.position != targetPosition)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            
            transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
            
            yield return null;
        }
        animator.SetBool("IsWalking", false);
        transform.position = targetPosition;
        
        isMoving = false;
    }
    
}