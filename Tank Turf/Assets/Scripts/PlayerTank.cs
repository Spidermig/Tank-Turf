using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTank : MonoBehaviour
{
    public Bullet playerBulletPrefab;
    //public Bullet enemyBulletPrefab;
    public float moveSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    private Rigidbody2D _rigidbody;
    private bool _moving;
    private float _turnDirection;
    //public float respawnShieldTime = 3.0f;

    [Header("Inscribed")]
    public Sprite[] playerTankSprites;
    //public int numPlayerTanks = 3;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        //this.gameObject.layer = LayerMask.NameToLayer("NoCollision");
        //this.Invoke(nameof(TurnOnCollision), this.respawnShieldTime);
    }

    private void TurnOnCollision()
    {
        this.gameObject.layer = LayerMask.NameToLayer("PlayerTank");
    }

    void Start()
    {
        GameObject playerTankGO = GameObject.FindWithTag("PlayerTank");
        SpriteRenderer sRend = playerTankGO.AddComponent<SpriteRenderer>();;

        //playerTankGO = new GameObject();
        //playerTankGO = this.GameObject();
        //sRend = playerTankGO.AddComponent<SpriteRenderer>();

        int playerSpriteNum = Random.Range(0, 3);
        sRend.sprite = playerTankSprites[playerSpriteNum];
    }

    // Update is called once per frame
    void Update()
    {
        _moving = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }   
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        if(_moving)
        {
            _rigidbody.AddForce(this.transform.up * this.moveSpeed);
        }

        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }

    private void Shoot()
    {
        Bullet playerBullet = Instantiate(this.playerBulletPrefab, this.transform.position + (transform.up * 1.0f), this.transform.rotation);
        playerBullet.Project(this.transform.up);
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            Destroy(this.gameObject);

            //this.gameObject.SetActive(false);

        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            //this.gameObject.SetActive(false);

            //FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
