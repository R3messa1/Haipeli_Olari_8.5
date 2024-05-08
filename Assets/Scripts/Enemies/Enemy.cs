using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{

    private float currentSpeed = 3;

    private Rigidbody2D body;

    private Transform playerTransform;

    private int currentHealth = 1;
    // Start is called before the first frame update
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){

        if(!GameManager.Instance.IsGamePlay()){
            return;
        }

        GetPlayer();

        Move();
    }

    private void Move(){

        if(playerTransform == null){
            return;
        }

        Vector2 direction = (playerTransform.position - transform.position).normalized;

        body.MovePosition(body.position + direction * currentSpeed * Time.fixedDeltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetPlayer(){

        if(playerTransform == null){

            playerTransform = GameManager.Instance.playerController.transform;
        }
    }

    public void TakeDamage(int damage){

        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }

    }

    public void Die(){
        EnemyPoolManager.Instance.ReturnEnemy(gameObject);
    }
}
