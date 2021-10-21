using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public ShooterInfo shooterInfo;
    public float lifetime;
    public int damage;
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    public void SetDirection(Vector2 velocity)
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = velocity * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
