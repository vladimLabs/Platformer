using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject attacker;
    private float detectionDistance = 5f;
    private bool startAttack = true;

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance <= detectionDistance && startAttack == true)
            {
                StartCoroutine(FarmAttack());
                Debug.Log("Враг близко! Расстояние: " + distance.ToString("F2"));

            }
        }
    }
    
    private IEnumerator FarmAttack()
    {
        startAttack = false;
        attacker.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        attacker.SetActive(false);
        startAttack = true;
    }
}
