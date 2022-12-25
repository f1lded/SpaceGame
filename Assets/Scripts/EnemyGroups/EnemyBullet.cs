using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{    float speed = 0.2f;
     public int  damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3 (
        transform.position.x,
        transform.position.y-speed,
        0
        );
        if (transform.position.y < -6.15 ){
            Destroy(gameObject);
        }
    }
}
