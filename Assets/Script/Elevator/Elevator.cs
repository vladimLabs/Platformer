using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private float speed;
    private bool elevetorStart = false;
    private int currentFloor = 0;
    private int targetFloor;

    private void Update()
    {
        if (elevetorStart == true)
        {
            ElevatorMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(TimerStart());
        }
    }

    IEnumerator TimerStart()
    {
        targetFloor = currentFloor + 1;
        if (targetFloor >= points.Count)
        {
            targetFloor = 0;
        }
        currentFloor = targetFloor;
        yield return new WaitForSeconds(1f);
        elevetorStart = true;
    }    

    private void ElevatorMove()
    {
        transform.position = Vector3.Lerp(transform.position, points[targetFloor].position, Time.deltaTime * speed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            elevetorStart = false;
        }
    }
}