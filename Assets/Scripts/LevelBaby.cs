using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBaby : MonoBehaviour
{
    public GameObject OriginalShip;
     public GameObject EnemyGroup;
    public GameObject ramGroup;
    Vector3 groupPosition = new Vector3(-0.145f,3.7f,0);
    Vector3 startPlayerPosition = new  Vector3(0,-2.31f,0);
    private int CountGroup = 0;
    private BaseGroup currentGroup;
    private GroupType[] levelGroupsTypes = { GroupType.ram,GroupType.shooting   };
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
           if (CountGroup == levelGroupsTypes.Length){
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
        if (levelGroupsTypes[CountGroup]==GroupType.shooting){
            GameObject newEnemyGroup = Instantiate(EnemyGroup);
            newEnemyGroup.transform.position = groupPosition;   
            currentGroup = newEnemyGroup.GetComponent<EnemyGroups>();
        }else if (levelGroupsTypes[CountGroup]==GroupType.ram) {
            GameObject newEnemyGroup = Instantiate(ramGroup);
            newEnemyGroup.transform.position = groupPosition;   
            currentGroup = newEnemyGroup.GetComponent<RamGroup>();
        }
        
    }

}