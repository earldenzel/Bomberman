using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Controller : MonoBehaviour {

    public GameObject breakable;
    public GameObject unbreakable;

	// Use this for initialization
	void Start () {
        int[][] spawner = new int[13][];

        spawner[0]  = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        spawner[1]  = new int[] { 1, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 1 };
        spawner[2]  = new int[] { 1, 0, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 1 };
        spawner[3]  = new int[] { 1, 0, 2, 0, 2, 2, 2, 2, 2, 2, 0, 0, 2, 0, 1 };
        spawner[4]  = new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 1, 2, 1 };
        spawner[5]  = new int[] { 1, 2, 0, 2, 0, 0, 2, 2, 0, 0, 2, 2, 2, 2, 1 };
        spawner[6]  = new int[] { 1, 2, 1, 2, 1, 2, 1, 0, 1, 2, 1, 0, 1, 0, 1 };
        spawner[7]  = new int[] { 1, 0, 2, 2, 2, 2, 2, 2, 2, 0, 2, 2, 2, 2, 1 };
        spawner[8]  = new int[] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 1, 0, 1 };
        spawner[9]  = new int[] { 1, 2, 2, 0, 2, 0, 2, 2, 2, 2, 2, 2, 2, 2, 1 };
        spawner[10] = new int[] { 1, 0, 1, 2, 1, 2, 1, 2, 1, 2, 1, 0, 1, 0, 1 };
        spawner[11] = new int[] { 1, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 1 };
        spawner[12] = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };

        for(int i = 0; i < 13; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                switch (spawner[i][j])
                {
                    case 1:
                        Instantiate(unbreakable, new Vector3(j-6, i-6), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(  breakable, new Vector3(j-6, i-6), Quaternion.identity);
                        break;
                    default:
                        break;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
