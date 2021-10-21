using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    GameObject barrel;
    public ShooterInfo shooterInfo;
    public float playerSpeed;
    
    GameObject player;

    GameObject FireBullet(Vector2 velocity)
    {
        GameObject bullet = Instantiate(shooterInfo.bulletPrefab, transform);
        bullet.transform.position = barrel.transform.position;
        bullet.GetComponent<BulletBehavior>().SetDirection(velocity);
        return bullet;
    }

    void Start()
    {
        player = Instantiate(shooterInfo.shooterPrefab, transform);
        Debug.Log(player.transform.Find("Main/Barrel"));
        barrel = player.transform.Find("Main/Barrel").gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        float vx = Input.GetAxis("Horizontal");
        float vy = Input.GetAxis("Vertical");
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(vx, vy, 0) * playerSpeed;

        Vector3 relativePos = Input.mousePosition - playerCamera.WorldToScreenPoint(player.transform.position);
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * Mathf.Atan2(relativePos.y, relativePos.x));
        player.transform.localRotation = rotation;

        playerCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet(((Vector2) relativePos).normalized);
        }
    }
}
