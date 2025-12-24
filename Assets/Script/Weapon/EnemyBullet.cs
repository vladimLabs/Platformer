using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Vector2 dir;
    
    [SerializeField] private int damage;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<PleayrHealth>().GetDamage(damage);
            Destroy(gameObject);
        }
        
    }
}
