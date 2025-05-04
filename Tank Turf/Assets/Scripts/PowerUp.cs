using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [Header("Inscribed")]
    public Sprite[] powerUpSprites;

    private int powerUpSpriteNum;
    private SpriteRenderer sRend;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PowerUpsGO = GameObject.FindWithTag("PowerUp");
        sRend = PowerUpsGO.AddComponent<SpriteRenderer>();

        powerUpSpriteNum = Random.Range(0, 3);
        sRend.sprite = powerUpSprites[powerUpSpriteNum];
    }

    private void TurnOnCollision()
    {
        this.gameObject.layer = LayerMask.NameToLayer("PowerUp");
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("PlayerTank")){
            // If statements for checking what powerup this is
            if (powerUpSpriteNum == 0)
            {
                Debug.Log("Player got Bullet PowerUp!");
            }
            else if (powerUpSpriteNum == 1)
            {
                Debug.Log("Player got Shield PowerUp!");
            }
            else if (powerUpSpriteNum == 2)
            {
                Debug.Log("Player got Speed PowerUp!");
            }

            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
