using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Elevator : MonoBehaviour
{
    [SerializeField] private List<Transform> points = new List<Transform>();
    [SerializeField] private float speed;
    [SerializeField] private GameObject elevatorCanvas;
    private bool elevetorStart = false;
    private int currentFloor = 0;
    private int targetFloor;

    //private void Start()
    //{
    //}
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
            elevatorCanvas.SetActive(true);
            //StartCoroutine(TimerStart());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            elevetorStart = false;
            elevatorCanvas.SetActive(false);
        }
    }

    IEnumerator TimerStart()
    {
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
    public void StartElevator(int point)
    {
        targetFloor = point;
        StartCoroutine(TimerStart());
    }
}