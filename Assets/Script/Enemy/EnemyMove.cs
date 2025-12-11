using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        
    }

    void Update()
    {
        MoveEn();
    }

    private void MoveEn()
    {
        GameObject pLayer = GameObject.FindGameObjectWithTag("Player");
        if (pLayer != null)
        {
            Debug.Log("Чапаю");
            Vector2 movement = new Vector2(speedEnemy, rb.linearVelocityY);
            rb.linearVelocity = movement;
        }
    }
}
