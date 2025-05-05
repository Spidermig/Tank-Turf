using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public PlayerTank shieldCounter;

    [Header("Inscribed")]
    public Sprite[] powerUpSprites;

    private int powerUpSpriteNum;
    private SpriteRenderer sRend;

    // Start is called before the first frame update
    void Start()
    {
        // Get or add SpriteRenderer
        sRend = this.gameObject.GetComponent<SpriteRenderer>();
        if (sRend == null)
        {
            sRend = this.gameObject.AddComponent<SpriteRenderer>();
        }

        // Assign PlayerTank reference
        GameObject pTankGO = GameObject.FindWithTag("PlayerTank");
        shieldCounter = pTankGO.GetComponent<PlayerTank>();

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
                shieldCounter.shield += 1 ;
                Debug.Log(shieldCounter.shield);
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
