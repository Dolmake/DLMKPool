using UnityEngine;
using System.Collections;
using DLMKPool;

public class Cannon : MonoBehaviour {


    public Vector3 Force;
    public GameObject CannonBall_Prefab;
    public float TimeToFire;
    float _accumTime = 0f;

    DLMKPool.GameObjectPool _pool = new GameObjectPool();


	// Use this for initialization
	void Start () {
        _pool.Initialize(this.transform, CannonBall_Prefab, 5);       
	}

    void Update()
    {
        _accumTime += Time.deltaTime;
        if (_accumTime > TimeToFire)
        {
            _accumTime -= TimeToFire;
            Fire();
        }
    }
	
	// Update is called once per frame
    void Fire()
    {
        GameObject cannonBall = _pool.Get();
        cannonBall.transform.localPosition = Vector3.zero;
        cannonBall.rigidbody.velocity = Force;
        cannonBall.PoolRelease(2f);
	}
}
