using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{   
    public delegate void OnDeath(EnemyShip deadShip);
    public event OnDeath DeathEvent;
    public int health = 8;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void  OnTriggerEnter2D(Collider2D collider)
    {   
        GameObject OtherObject = collider.gameObject;
        MainBullet bulletObject = OtherObject.GetComponent<MainBullet>();
        if(bulletObject != null){
            health -= bulletObject.damage;
            if (health <= 0) {
                Destroy(gameObject);
            }
            DeathEvent.Invoke(this);                                              
            Destroy(OtherObject);
        }
    }
    public void Shoot () {
        GameObject bulletclone = Instantiate(bullet);
        bulletclone.transform.position = transform.position; 
    }
}
