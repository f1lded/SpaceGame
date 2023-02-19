using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceShip : MonoBehaviour
{   
    public GameObject Bulby;
    public SpriteRenderer spriteRenderer;                   

    private float speed = 0.1f;
    private int health = 10;

   
    void Update()
    {   
        float halfWidth = spriteRenderer.bounds.size.x / 2;
        float halfHeight = spriteRenderer.bounds.size.y / 2;
        

        bool  IsKeyDown = Input.GetKey(KeyCode.A);              
        if (IsKeyDown == true) {
            Vector3 newPosition = new Vector3(transform.position.x - speed,transform.position.y,0);
            Vector3 checkPosition = new Vector3 (newPosition.x - halfWidth, newPosition.y,0  );
            if (ScreenUtils.point(checkPosition)){
                transform.position = newPosition;
            }
                                              
        }   
        
        IsKeyDown = Input.GetKey(KeyCode.D);              
        if (IsKeyDown == true) {
            Vector3 newPosition = new Vector3(transform.position.x + speed,transform.position.y,0);
            Vector3 checkPosition = new Vector3 (newPosition.x + halfWidth, newPosition.y,0  );
            if (ScreenUtils.point(checkPosition)){
                transform.position = newPosition;
            }
                                              
        }   
        
        IsKeyDown = Input.GetKey(KeyCode.W);              
        if (IsKeyDown == true) {
            Vector3 newPosition = new Vector3(transform.position.x ,transform.position.y +speed,0);
            Vector3 checkPosition = new Vector3 (newPosition.x , newPosition.y + halfHeight,0  );
            if (ScreenUtils.point(checkPosition)){
                transform.position = newPosition;
            }
                                              
        }   

        IsKeyDown = Input.GetKey(KeyCode.S);              
        if (IsKeyDown == true) {
            Vector3 newPosition = new Vector3(transform.position.x ,transform.position.y -speed,0);
            Vector3 checkPosition = new Vector3 (newPosition.x , newPosition.y -halfHeight,0  );
            if (ScreenUtils.point(checkPosition)){
                transform.position = newPosition;
            }
                                              
        }   

        IsKeyDown = Input.GetKeyUp(KeyCode.Space);
        if (IsKeyDown == true) {
           GameObject bulletclone = Instantiate(Bulby);
           bulletclone.transform.position = transform.position;
        }                                                        
    }   
     
    void  OnTriggerEnter2D(Collider2D collider){
        GameObject otherObject = collider.gameObject;
        EnemyBullet bullet = otherObject.GetComponent<EnemyBullet>();
        if (bullet != null){
            health -= bullet.damage;
            Destroy(otherObject);
            if (health <= 0){
                SceneManager.LoadSceneAsync(SceneIDS.LoseSceneID);
                Destroy(gameObject);
            }
        } else {
            RamShip ship = otherObject.GetComponent<RamShip>();
            if (ship != null) {
                Destroy(otherObject);
                SceneManager.LoadSceneAsync(SceneIDS.LoseSceneID);
                Destroy(gameObject);
            }
        }
    }
}
