using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldPointSystem : MonoBehaviour
{
    public static OldPointSystem SharedInstance;

    void Start()
    {
        if(SharedInstance!=null) Destroy(this);
        SharedInstance = this;
    }

    int Points;

    public void AddPoints(int points){
        Points += points;
    }
}
