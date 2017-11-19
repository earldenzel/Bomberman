using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastController : MonoBehaviour {

    public GameObject bombUp;
    public GameObject fireUp;
    public GameObject speedUp;
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Breakable")
        {
            Vector2 position = collider.gameObject.transform.position;
            Destroy(collider.gameObject);
            PowerupSpawn(position);
        }
        if (collider.gameObject.tag == "Bomb")
        {
            collider.gameObject.SendMessage("SpawnExplosions");
            Destroy(collider.gameObject);
            collider.gameObject.GetComponent<BombDetonator>().Bomber.GetComponent<BombSpawner>().OutBombs--;
        }
    }

    private void PowerupSpawn(Vector2 position)
    {
        if (Random.Range(0,4) < 1)
        {
            float spawnPercents = Random.Range(0, 100);
            if (spawnPercents < 40)
            {
                Instantiate(bombUp, position, Quaternion.identity);
            }
            else if (spawnPercents < 80)
            {
                Instantiate(fireUp, position, Quaternion.identity);
            }
            else
            {
                Instantiate(speedUp, position, Quaternion.identity);
            }
        }
    }
}
