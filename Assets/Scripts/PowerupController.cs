using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Blast")
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Player")
        {
            BombSpawner playerStats = collision.gameObject.GetComponent<BombSpawner>();
            PlayerController playerStats2 = collision.gameObject.GetComponent<PlayerController>();
            switch (gameObject.tag)
            {
                case "FireUp":
                    if (playerStats.Strength < 9)
                    {
                        playerStats.Strength++;
                    }
                    break;
                case "BombUp":
                    if (playerStats.MaxBombs < 10)
                    {
                        playerStats.MaxBombs++;
                    }
                    break;
                case "SpeedUp":
                    if (playerStats2.Speed < 8)
                    {
                        playerStats2.Speed++;
                    }
                    break;
                default:
                    break;
            }
            Debug.Log("BombUp " + playerStats.MaxBombs);
            Destroy(this.gameObject);
        }
    }
}
