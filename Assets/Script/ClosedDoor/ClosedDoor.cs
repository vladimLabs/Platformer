using System;
using TMPro;
using UnityEngine;

public class ClosedDoor : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    [SerializeField] private GameObject panel;
    
    [SerializeField] private string password;
    [SerializeField] private TMP_InputField inputField;

    bool isActive = false;
    bool isOpen = false;
    private void Update()
    {
        if(isActive == false) return;
        if (inputField.text == password)
        {
            animator.SetBool("Opened", true);
            isOpen = true;
            panel.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            panel.SetActive(true);
            isOpen = true;
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            panel.SetActive(false);
            isOpen = false;
            isActive = false;
        }
    }
}
