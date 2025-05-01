using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [Header("Inscribed")]
    public Sprite[] powerUpSprites;
    //public int numPlayerTanks = 3;

    // Start is called before the first frame update
    void Start()
    {
        GameObject PowerUpsGO = GameObject.FindWithTag("PowerUp");
        SpriteRenderer sRend = PowerUpsGO.AddComponent<SpriteRenderer>();;

        int powerUpSpriteNum = Random.Range(0, 3);
        sRend.sprite = powerUpSprites[powerUpSpriteNum];
    }

    private void TurnOnCollision()
    {
        this.gameObject.layer = LayerMask.NameToLayer("PowerUp");
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("PlayerTank")){
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
