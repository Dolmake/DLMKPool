using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        this.transform.localScale *= 0.9f;
	}

    public void Init()
    {
        this.transform.localScale = Vector3.one;
    }
}
