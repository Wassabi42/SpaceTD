using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

public class Tower : MonoBehaviour
{
    Transform enemyPosition;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] float bulletSpeed;

    [SerializeField] float shootTime;
    [SerializeField] float shootTimer;

    public List<GameObject> targetList = new List<GameObject>();
    [SerializeField] LayerMask layerMask;
    [SerializeField] float sightRadius;

    [SerializeField] float rotationSpeed;

    private void Start()
    {
        shootTimer = shootTime;
    }
    private void Update()
    {
        if(shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        if(shootTimer <= 0 && enemyPosition != null)
        {
            shootTimer = shootTime;
            Shoot();
        }

        Sight();

        if(targetList.Count > 0)
        {
            enemyPosition = targetList[0].transform;
            Debug.DrawLine(transform.position, enemyPosition.position, Color.green);
           
            float angle = Mathf.Atan2(enemyPosition.transform.position.x - transform.position.x,
            enemyPosition.transform.position.y - transform.position.y) * Mathf.Rad2Deg;

            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, -angle));
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            enemyPosition = null;
        }

    }

    public void Shoot()
    {
        GameObject Projectile = Instantiate(bullet, shootPoint.position, Quaternion.Euler(0,0,0));
        
        Rigidbody2D projectileRb = Projectile.GetComponent<Rigidbody2D>();
        projectileRb.linearVelocity = transform.up * bulletSpeed;
    }

    void Sight()
    {
        Collider2D[] seenEnemies = Physics2D.OverlapCircleAll(transform.position, sightRadius, layerMask);
        for(int i = 0; i < seenEnemies.Length; i++)
        {
            targetList.Add(seenEnemies[i].gameObject);
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRadius);
    }
    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<Tower>().targetList.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<Tower>().targetList.Remove(collision.gameObject);
        }
    }*/
}