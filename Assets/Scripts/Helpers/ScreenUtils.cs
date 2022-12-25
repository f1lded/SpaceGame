using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenUtils    
{
    public static bool point(Vector3 position){
        Vector3 converted = Camera.main.WorldToScreenPoint(position);
        if (converted.x > 0 &&
            converted.y > 0 &&
            converted.x < Screen.width &&
            converted.y < Screen.height){
                return true;
            }else {
                return false;
        }
    }    
}

