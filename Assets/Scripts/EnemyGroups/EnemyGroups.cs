using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroups : BaseGroup
{
    public EnemyShip ship1;
    public EnemyShip ship2;
    public EnemyShip ship3; 
    private float speed = 0.07f;
    private int direction = -1;
    private List<EnemyShip> ships = new List<EnemyShip>();
    private System.Random generator = new System.Random();
    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);
        ship1.DeathEvent += OnShipDeath;
        ship2.DeathEvent += OnShipDeath;
        ship3.DeathEvent += OnShipDeath;
        InvokeRepeating("GroupShoot", 0f,1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        ships.RemoveAll(item => item == null);  
        if ( ships.Count == 0 ) {
                Alive = false;
                CancelInvoke("GroupShoot");
                return; 
        }

        if (direction == -1){
            Vector3 leftPosition = ships[0].transform.position;
            leftPosition.x -=speed;

            bool onScreen = ScreenUtils.point(leftPosition);
            if (onScreen){
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            } else {
                direction *= -1;
            }
        } else {
            Vector3 rightPosition = ships[ships.Count -1].transform.position;
            rightPosition.x +=speed;

            bool onScreen = ScreenUtils.point(rightPosition);
            if (onScreen){
                transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    0
                );
            } else {
                direction *= -1;
            }
        }
    }

    void OnShipDeath(EnemyShip deadship){
        //ships.Remove(deadship);
    }
    void GroupShoot( ) {
        int randomindex = generator.Next(0,ships.Count );
        ships[randomindex].Shoot();
    }
}
