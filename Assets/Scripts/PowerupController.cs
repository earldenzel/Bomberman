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
            BombHandler playerStats3 = collision.gameObject.GetComponent<BombHandler>();
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
                    if (playerStats2.speed < 8)
                    {
                        playerStats2.speed++;
                    }
                    break;
                case "MaxFireUp":
                    playerStats.Strength = 9;
                    break;
                case "Detonate":
                    playerStats3.canRemoteDetonate = true;
                    break;
                case "Kick":
                    playerStats3.canKick = true;
                    break;
                case "Punch":
                    playerStats3.canPunch = true;
                    break;
                case "Skull":
                    float currentSpeed = playerStats2.speed;
                    int currentStrength = playerStats.Strength;
                    StartCoroutine(playerStats3.Skull(currentSpeed, currentStrength));
                    break;
                default:
                    break;
            }
            Debug.Log("BombUp " + playerStats.MaxBombs);
            Destroy(this.gameObject);
        }
    }
}
