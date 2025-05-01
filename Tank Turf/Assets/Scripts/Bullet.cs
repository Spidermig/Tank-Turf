using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50.0f;

    public float maxLifeTime = 3.0f;

    private Rigidbody2D _rigidbody;

    private bool hasRicocheted = false;

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
            if (!hasRicocheted)
            {
                //_rigidbody.velocity = Vector3.zero;
                //_rigidbody.angularVelocity = 0.0f;

                Vector2 reflectDir = Vector2.Reflect(_rigidbody.velocity.normalized, collision.contacts[0].normal);
                //_rigidbody.velocity = reflectDir * 200.0f;
                _rigidbody.AddForce(reflectDir * this.speed);
                hasRicocheted = true;
                Destroy(this.gameObject, this.maxLifeTime);

                //Debug.Log("Hitting wall");

                //FindObjectOfType<GameManager>().PlayerDied();
            }
            else
            {
                Vector2 reflectDir = Vector2.Reflect(_rigidbody.velocity.normalized, collision.contacts[0].normal);
                //_rigidbody.velocity = reflectDir * 200.0f;
                _rigidbody.AddForce(reflectDir * this.speed);
            }
        }

        if (collision.gameObject.CompareTag("EnemyTank"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            Destroy(this.gameObject);

            //FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
