using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManage : MonoBehaviour
{
    private GameObject dummy;
    private SpriteRenderer spriteRenderer;
    public Sprite dummySprite; 
    public Rigidbody2D myRigidbody;
    public bool birdIsAlive = true;
    public Logic logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();

    }

    void Update()
    {
        if (transform.position.y < -4.5f)
        {
            myRigidbody.gravityScale = 0;
            myRigidbody.linearVelocity = new Vector2(0,0);

            logic.gameOver();

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collition");
        dummy = GameObject.Find("Dummy");
        spriteRenderer = dummy.GetComponent<SpriteRenderer>();

        if (spriteRenderer.sprite == dummySprite)
        {
            logic.addScore(1);
            Destroy(gameObject);
        }
        else
        {
            logic.gameOver();
        }
    }
}
