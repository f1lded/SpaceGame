using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public Directions direction;  
    public SpriteRenderer shipRenderer;
    private float speed = 0.1f;  
    private float halfWidth;
    private float halfHeight;

    private int health = 20;
    void Start()
    {
        halfWidth = shipRenderer.sprite.bounds.size.x/2;
        halfHeight= shipRenderer.sprite.bounds.size.y/2;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        switch(direction){
            case Directions.left:
                MovingLeft();
                break;
            case Directions.right:
                MovingRight();
                break;
            case Directions.up:
                MovingUp();
                break;
            case Directions.down:
                MovingDown();
                break;
        }
    }

    private void MovingRight() {
        Vector3 newPosition = new Vector3(transform.position.x + speed, transform.position.y,0);
        Vector3 checkPosition = newPosition;
        checkPosition.x += halfWidth;
        if (ScreenUtils.point(checkPosition)){ 
            transform.position =newPosition;

        }else {
            if (transform.position.y > 0){
                direction = Directions.down;
            }else {
                direction= Directions.up;
            }
        }
    }
    private void MovingLeft() {
        Vector3 newPosition = new Vector3(transform.position.x - speed, transform.position.y,0);
        Vector3 checkPosition = newPosition;
        checkPosition.x -= halfWidth;

        if (ScreenUtils.point(checkPosition)){ 
            transform.position =newPosition;

        }else {
            if (transform.position.y > 0){
                direction = Directions.down;
            }else {
                direction= Directions.up;
            }
        }
    }
     private void MovingUp() {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y + speed,0);
        Vector3 checkPosition = newPosition;
        checkPosition.y += halfHeight;
        if (ScreenUtils.point(checkPosition)){ 
            transform.position =newPosition;

        }else {
            if (transform.position.x> 0){
                direction = Directions.left;
            }else {
                direction = Directions.right;
            }
        }
    }
     private void MovingDown() {
        Vector3 newPosition = new Vector3(transform.position.x , transform.position.y -speed,0);
        Vector3 checkPosition = newPosition;
        checkPosition.y -= halfHeight;
        if (ScreenUtils.point(checkPosition)){ 
            transform.position =newPosition;

        } else {
            if (transform.position.x >0){
                direction = Directions.left;
            }else {
                direction= Directions.right;
            }
        }
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
            Destroy(OtherObject);
        }
    }
}

