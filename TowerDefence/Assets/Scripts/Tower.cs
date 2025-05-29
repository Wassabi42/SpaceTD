using UnityEngine;
using NUnit.Framework;

public class Tower : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] Transform bulletParent;

    public List[] sightList;
    [SerializeField] float sightRadius;
    public float rotationSpeed = 0.1f;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, shootPoint.rotation, rotationSpeed);
        }
    }
    void Shoot()
    {
        Instantiate(bullet, shootPoint.position, Quaternion.identity, bulletParent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

}
