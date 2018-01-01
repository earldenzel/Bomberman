using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHandler : MonoBehaviour {

    public bool canKick;
    public bool canPunch;
    public bool canRemoteDetonate;
    public int skullEffect;
    private int direction;
    private GameObject closestBomb;
    private bool randomlyLayBombs;

    // Use this for initialization
    void Start () {
        canKick = false;
        canPunch = false;
        canRemoteDetonate = false;
        randomlyLayBombs = false;
        skullEffect = 0;
    }
	void Update () {
        if (randomlyLayBombs)
        {
            if (Random.Range (0f, 100f) < 0.5f)
            {
                GetComponent<BombSpawner>().LayBombs();
            }
        }

        if (Input.GetButtonUp("Fire2"))
        {
            if (canKick)
            {
                KickBombs();
            }
            else if (canPunch)
            {
                PunchBombs();
            }
            else if (canRemoteDetonate)
            {
                RemoteDetonateBombs();
            }
        }
	}

    public IEnumerator SetNormal(float spd, int str)
    {
        yield return new WaitForSeconds(7.0f);
        Debug.Log("Setting normals");
        skullEffect = 0;
        randomlyLayBombs = false;
        GetComponent<PlayerController>().speed = spd;
        GetComponent<BombSpawner>().OutBombs = 0;
        GetComponent<BombSpawner>().Strength = str;
        GetComponent<SpriteRenderer>().enabled = true;
    }

    public IEnumerator Skull(float spd, int str)
    {
        skullEffect = Random.Range(1, 8);
        /*
         * 1- Temporarily reduces speed
         * 2- Radically increases speed
         * 3- Lays bombs randomly
         * 4- Disallows laying bombs
         * 5- Makes Bomberman invisible
         * 6- Keeps laying bombs at high speed
         * 7- Allows only one minimum-range bomb to be laid at a time
         */
        if (skullEffect == 1)
        {
            GetComponent<PlayerController>().speed = 2;
        }
        if (skullEffect == 2)
        {
            GetComponent<PlayerController>().speed = 8;
        }
        if (skullEffect == 3 || skullEffect == 6)
        {
            randomlyLayBombs = true;
        }
        if (skullEffect == 4)
        {
            GetComponent<BombSpawner>().OutBombs = GetComponent<BombSpawner>().MaxBombs;
        }
        if (skullEffect == 5)
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        if (skullEffect == 7)
        {
            GetComponent<BombSpawner>().Strength = 1;
            GetComponent<BombSpawner>().OutBombs = GetComponent<BombSpawner>().MaxBombs - 1;
        }
        StartCoroutine(SetNormal(spd, str));
        yield return new WaitUntil(() => skullEffect == 0);
    }

    public void KickBombs()
    {
        int move = 0;
        closestBomb = CheckClosestBomb();
        if (closestBomb != null)
        {
            while(!Physics2D.OverlapCircle((Vector2)closestBomb.transform.position + DetermineUnitVector(), 0.1f))
            {
                closestBomb.transform.position = closestBomb.transform.position + (Vector3)DetermineUnitVector();
                move++;
            }
        }
        if (move > 0)
        {
            canKick = false;
        }
    }
    public void PunchBombs()
    {
        closestBomb = CheckClosestBomb();
        if (closestBomb != null)
        {
            Destroy(closestBomb);
            closestBomb.GetComponent<BombDetonator>().Bomber.GetComponent<BombSpawner>().OutBombs -= 1; //if own bombs, should be reduced.
            canPunch = false;
        }
    }
    public void RemoteDetonateBombs()
    {
        foreach (GameObject bomb in GameObject.FindGameObjectsWithTag("Bomb"))
        {
            bomb.SendMessage("Explode",0.05f);
        }
        canRemoteDetonate = false;
    }

    private GameObject CheckClosestBomb()
    {
        Vector2 checkPosition = new Vector2(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y - 0.5f));
        RaycastHit2D bombHit = Physics2D.Linecast(checkPosition, checkPosition + DetermineUnitVector(), 1 << LayerMask.NameToLayer("Bomb"));
        return bombHit.collider.gameObject;
    }

    private Vector2 DetermineUnitVector()
    {
        direction = this.GetComponent<Animator>().GetInteger("Direction");
        Vector2 returnVector;
        switch (direction)
        {
            case 1:
                returnVector = Vector2.left;
                break;
            case 2:
                returnVector = Vector2.up;
                break;
            case 3:
                returnVector = Vector2.right;
                break;
            default:
                returnVector = Vector2.down;
                break;
        }
        return returnVector;
    }
}
