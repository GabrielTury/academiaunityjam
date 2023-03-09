using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private PlayerScript playerScript;
    private Rigidbody2D bulletRbd;
    [SerializeField] private float speed;
    void Start()
    {
        bulletRbd= GetComponent<Rigidbody2D>();
        bulletRbd.velocity = transform.right * -1 * speed;

        Invoke("Destroy", 10);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript = collision.GetComponent<PlayerScript>();
            playerScript.TakeDamage(10);
        }
            
    }
}
