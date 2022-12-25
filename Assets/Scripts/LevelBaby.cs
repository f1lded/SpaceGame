using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBaby : MonoBehaviour
{
    public GameObject OriginalShip;
    public GameObject EnemyGroup;
    Vector3 groupPosition = new Vector3(-0.145f,3.7f,0);
    Vector3 startPlayerPosition = new  Vector3(0,-2.31f,0);
    private int CountGroup = 0;
    private EnemyGroups currentGroup    ;
    void Start()
    {
        GameObject newPlayerShip = Instantiate(OriginalShip);
        newPlayerShip.transform.position = startPlayerPosition;
        MakeNewGroup();
        CountGroup++;
    }

    void Update()
    {
        if (currentGroup!= null && currentGroup.Alive == false){
           if (CountGroup == 3){
                SceneManager.LoadSceneAsync(SceneIDS.WinSceneID);
            } else {
                Destroy(currentGroup.gameObject);
                MakeNewGroup();
                CountGroup++;
            }
        }
    }
    void MakeNewGroup()
    {
      GameObject newEnemyGroup = Instantiate(EnemyGroup);
      newEnemyGroup.transform.position = groupPosition;   
      currentGroup = newEnemyGroup.GetComponent<EnemyGroups>();
    }
}
