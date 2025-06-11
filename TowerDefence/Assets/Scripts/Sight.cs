using UnityEngine;

public class Sight : MonoBehaviour
{
    Tower s_Tower;

    private void Awake()
    {
        s_Tower = GetComponent<Tower>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            s_Tower.targetList.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            s_Tower.targetList.Remove(collision.gameObject);
        }
    }
}
