using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlastController : MonoBehaviour {

    public GameObject bombUp;
    public GameObject fireUp;
    public GameObject speedUp;
    public GameObject maxFireUp;
    public GameObject punch;
    public GameObject kick;
    public GameObject detonate;
    public GameObject skull;
    
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
            collider.gameObject.SendMessage("Explode", 0.05f);
            collider.gameObject.GetComponent<BombDetonator>().Bomber.GetComponent<BombSpawner>().OutBombs--;
        }
    }

    private void PowerupSpawn(Vector2 position)
    {
        if (Random.Range(0,3) < 1)
        {
            float spawnPercents = Random.Range(0, 100);
            if (spawnPercents < 25)
            {
                Instantiate(bombUp, position, Quaternion.identity);
            }
            else if (spawnPercents < 50)
            {
                Instantiate(fireUp, position, Quaternion.identity);
            }
            else if (spawnPercents < 60)
            {
                Instantiate(speedUp, position, Quaternion.identity);
            }
            else if (spawnPercents < 70)
            {
                Instantiate(punch, position, Quaternion.identity);
            }
            else if (spawnPercents < 80)
            {
                Instantiate(kick, position, Quaternion.identity);
            }
            else if (spawnPercents < 90)
            {
                Instantiate(detonate, position, Quaternion.identity);
            }
            else if (spawnPercents < 95)
            {
                Instantiate(maxFireUp, position, Quaternion.identity);
            }
            else
            {
                Instantiate(skull, position, Quaternion.identity);
            }
        }
    }
}
