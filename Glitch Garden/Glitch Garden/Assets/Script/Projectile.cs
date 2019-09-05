using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 1f;
    [SerializeField] float spinSpeed = 10f;
    [SerializeField] int damage = 1;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spinSpeed * Time.deltaTime * -1);
        transform.position = new Vector2(transform.position.x + projectileSpeed * Time.deltaTime, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var attacker = collision.gameObject.GetComponent<Attacker>();
        var health = collision.gameObject.GetComponent<Health>();
        if (!attacker || !health)
        {
            return;
        }
        health.DealDamage(damage);
        Destroy(gameObject);
    }
}
