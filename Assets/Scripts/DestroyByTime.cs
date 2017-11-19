using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(EndExplosion());
    }

    IEnumerator EndExplosion()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
