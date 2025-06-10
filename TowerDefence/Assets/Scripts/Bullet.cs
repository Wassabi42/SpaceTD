using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] float lifeTimer;

    private void Update()
    {
        if (lifeTimer > 0)
        {
            lifeTimer -= Time.deltaTime;
        }
        if (lifeTimer >= 0)
        {
            lifeTimer = lifeTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Debug.Log("´Me when I kaboom");
            Destroy(gameObject);
        }
    }
}
