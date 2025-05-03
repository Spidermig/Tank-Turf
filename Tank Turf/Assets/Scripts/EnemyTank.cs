using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    public Bullet enemyBulletPrefab;

    void Start()
    {
        InvokeRepeating(nameof(Shoot), 2.0f, 5.0f);
    }

    private void Shoot()
    {
        Bullet enemyBullet = Instantiate(this.enemyBulletPrefab, this.transform.position + (transform.up * 1.0f), this.transform.rotation);
        enemyBullet.Project(this.transform.up);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
