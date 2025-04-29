using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50.0f;

    public float maxLifeTime = 3.0f;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }   

    public void Project(Vector2 direction)
    {
        _rigidbody.AddForce(direction * this.speed);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            Destroy(this.gameObject, this.maxLifeTime);

            Debug.Log("Hitting wall");

            //FindObjectOfType<GameManager>().PlayerDied();
        }

        if (collision.gameObject.CompareTag("EnemyTank"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            //FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
