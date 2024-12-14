using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    Collider2D body;
    Collider2D feet;
    //[SerializeField] int playerHealth = 10;
    //[SerializeField] float invincilityTime = 2f;
    //bool invincible = false;

    //void Disableinvincility()
    //{
        //invincible = false;
    //}
    void Start()
    {
        body = GetComponent<PolygonCollider2D>();
        feet = GetComponent<BoxCollider2D>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (feet.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            Destroy(other.gameObject);

        }
        else if (body.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            FindFirstObjectByType<GameSession>().ProcessPlayerDamage();

            //if (invincible == true)
            //{
            //return;
            //}
            //if (playerHealth > 0)
            //{
            //playerHealth--;
            //invincible = true;
            //Invoke("Disableinvincility", invincilityTime);
            //Debug.Log("player Health:" + playerHealth);
            //}
            //else
            //{
            //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            //SceneManager.LoadScene(currentSceneIndex);
            //}

        }
    }


}
