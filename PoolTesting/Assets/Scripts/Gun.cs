using UnityEngine;
using System.Collections;
using DLMKPool;

public class Gun : MonoBehaviour
{
    public Vector3 Force;
    public Bullet Bullet_Prefab;
    public float TimeToFire;
    float _accumTime = 0f;

    GameComponentPool<Bullet> _pool = new GameComponentPool<Bullet>();


    // Use this for initialization
    void Start()
    {
        _pool.Initialize(this.transform, Bullet_Prefab, 5);
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
        Bullet bullet = _pool.Get();
        bullet.Init();
        bullet.transform.localPosition = Vector3.zero;
        bullet.rigidbody.velocity = Force;
        bullet.gameObject.PoolRelease(2f);
    }
}
