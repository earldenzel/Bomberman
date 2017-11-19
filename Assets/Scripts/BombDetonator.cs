using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDetonator : MonoBehaviour {
    
    public float lifeTime = 3f;
    private GameObject bomber;
    private BombSpawner bombSpawner;
    private Collider2D bombCollider;
    private int strength;

    public GameObject centerExplosion;
    public GameObject northEndExplosion;
    public GameObject northExplosion;
    public GameObject westEndExplosion;
    public GameObject westExplosion;
    public GameObject southExplosion;
    public GameObject southEndExplosion;
    public GameObject eastExplosion;
    public GameObject eastEndExplosion;
    private Vector3 centerPosition;

    private bool lastOne;

    public GameObject Bomber
    {
        get
        {
            return bomber;
        }

        set
        {
            bomber = value;
        }
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(Explode(lifeTime));
        bombSpawner = bomber.GetComponent<BombSpawner>();
        bombCollider = this.GetComponent<CircleCollider2D>();
        centerPosition = this.transform.position;
        strength = bombSpawner.Strength;
        bombCollider.isTrigger = true; //enables transparent walking on bomb spawn
        lastOne = false;
	}

    IEnumerator Explode(float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        SpawnExplosions();
        Destroy(this.gameObject);
        bombSpawner.OutBombs -= 1;
    }

    void SpawnExplosions()
    {
        Instantiate(centerExplosion, centerPosition, Quaternion.identity);
        for (int i = 1; i <= strength; i++)
        {
            Vector2 checkPosition = new Vector2(centerPosition.x + i, centerPosition.y);
            if (Physics2D.OverlapCircle(checkPosition, 0.1f) != null)
            {
                lastOne = true;
            }
            if (i == strength)
            {
                Instantiate(eastEndExplosion, checkPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(eastExplosion, checkPosition, Quaternion.identity);
            }
            if (lastOne)
            {
                lastOne = false;
                break;
            }
        }
        for (int i = 1; i <= strength; i++)
        {
            Vector2 checkPosition = new Vector2(centerPosition.x - i, centerPosition.y);

            if (Physics2D.OverlapCircle(checkPosition, 0.1f) != null)
            {
                lastOne = true;
            }
            if (i == strength)
            {
                Instantiate(westEndExplosion, checkPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(westExplosion, checkPosition, Quaternion.identity);
            }
            if (lastOne)
            {
                lastOne = false;
                break;
            }
        }
        for (int i = 1; i <= strength; i++)
        {
            Vector2 checkPosition = new Vector2(centerPosition.x, centerPosition.y - i);

            if (Physics2D.OverlapCircle(checkPosition, 0.1f) != null)
            {
                lastOne = true;
            }
            if (i == strength)
            {
                Instantiate(southEndExplosion, checkPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(southExplosion, checkPosition, Quaternion.identity);
            }
            if (lastOne)
            {
                lastOne = false;
                break;
            }
        }
        for (int i = 1; i <= strength; i++)
        {
            Vector2 checkPosition = new Vector2(centerPosition.x, centerPosition.y + i);

            if (Physics2D.OverlapCircle(checkPosition, 0.1f) != null)
            {
                lastOne = true;
            }
            if (i == strength)
            {
                Instantiate(northEndExplosion, checkPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(northExplosion, checkPosition, Quaternion.identity);
            }
            if (lastOne)
            {
                lastOne = false;
                break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        bombCollider.isTrigger = false; //disables transparent walking once player goes away from it
    }
}
