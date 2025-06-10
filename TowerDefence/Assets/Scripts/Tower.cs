using UnityEngine;
using NUnit.Framework;
using UnityEditor;
using Unity.VisualScripting;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform enemyPosition;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform shootPoint;
    [SerializeField] Transform bulletParent;
    [SerializeField] float bulletSpeed;

    [SerializeField] float shootTime;
    [SerializeField] float shootTimer;

    public List[] sightList;
    [SerializeField] float sightRadius;
    [SerializeField] float rotationSpeed = 1f;

    private void Awake()
    {
        enemyPosition = GameObject.Find("enemy").GetComponent<Transform>();
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

        float angle = Mathf.Atan2(enemyPosition.transform.position.y - transform.position.y, enemyPosition.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    public void Shoot()
    {
        GameObject Projectile = Instantiate(bullet, shootPoint.position, Quaternion.identity, bulletParent);
        
        Rigidbody2D projectileRb = Projectile.GetComponent<Rigidbody2D>();
        projectileRb.linearVelocity = transform.up * bulletSpeed;
    }
}

#if UNITY_EDITOR

    [CustomEditor(typeof(Tower))]

    public class TowerCustomInspector : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Tower tower = (Tower)target;

        GUILayout.Space(10f);

        GUILayout.BeginHorizontal();

        if(GUILayout.Button("Shoot", GUILayout.Width(90f)))
        {
            tower.Shoot();
        }

        GUILayout.EndHorizontal();
    }
}

#endif