using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class Sight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Transform enemyPos = collision.GetComponent<Transform>();
            GetComponent<Tower>().sightList.Add(enemyPos);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Transform enemyPos = collision.GetComponent<Transform>();
            GetComponent<Tower>().sightList.Remove(enemyPos);
        }
    }
}
