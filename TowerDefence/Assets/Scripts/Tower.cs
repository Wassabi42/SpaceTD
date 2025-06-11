using UnityEngine;
using NUnit.Framework;
using System.Collections.Generic;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform enemyPosition;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] Transform bulletParent;
    [SerializeField] float bulletSpeed;

    [SerializeField] float shootTime;
    [SerializeField] float shootTimer;

    public List<Transform> sightList = new List<Transform>();
    [SerializeField] float rotationSpeed = 1f;

    private void Awake()
    {
        enemyPosition = GameObject.Find("enemy").GetComponent<Transform>();
    }
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
        if(shootTimer <= 0)
        {
            shootTimer = shootTime;
            Shoot();
        }
        Debug.DrawLine(transform.position, enemyPosition.position, Color.green);

        float angle = Mathf.Atan2(enemyPosition.transform.position.x - transform.position.x, enemyPosition.transform.position.y - transform.position.y) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, -angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

    }
    public void Shoot()
    {
        GameObject Projectile = Instantiate(bullet, shootPoint.position, Quaternion.Euler(0,0,0), bulletParent);
        
        Rigidbody2D projectileRb = Projectile.GetComponent<Rigidbody2D>();
        projectileRb.linearVelocity = transform.up * bulletSpeed;
    }
}