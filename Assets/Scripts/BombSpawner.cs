using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {

    private int maxBombs; //maximum possible bombs
    private int outBombs; //number of bombs currently out
    private int strength; //strength of bomb
    private Transform playerTransform;

    public GameObject bomb;
    private GameObject spawnedBomb;
    private Vector3 bombPosition;
    
    public float nextBomb = 0.45f;
    private float myTime = 0.0f;

    public int MaxBombs
    {
        get
        {
            return maxBombs;
        }

        set
        {
            maxBombs = value;
        }
    }

    public int OutBombs
    {
        get
        {
            return outBombs;
        }

        set
        {
            if (value < 0)
            {
                value = 0;
            }
            outBombs = value;
        }
    }

    public int Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    // Use this for initialization
    void Start () {
        MaxBombs = 1;
        OutBombs = 0;
        playerTransform = this.transform;
        Strength = 1;
	}
	
	// Update is called once per frame
	void Update () {
        myTime += Time.deltaTime;
        if (Input.GetButtonUp("Fire1") && OutBombs < MaxBombs && myTime>nextBomb)
        {
            LayBombs();
        }
	}

    public void LayBombs()
    {
        bombPosition = new Vector2(Mathf.Round(playerTransform.position.x), Mathf.Round(playerTransform.position.y - 0.5f));
        spawnedBomb = Instantiate(bomb, bombPosition, Quaternion.identity) as GameObject;
        spawnedBomb.GetComponent<BombDetonator>().Bomber = this.gameObject;
        OutBombs++;
        myTime = 0.0f;
    }
}
