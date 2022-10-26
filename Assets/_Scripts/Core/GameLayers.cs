using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeHunter
{
    public class GameLayers : MonoBehaviour
    {
    [SerializeField] private LayerMask wallObjLayer;
    [SerializeField] private LayerMask playerObjLayer;

    public LayerMask WallObjLayer => wallObjLayer;
    public LayerMask PlayerObjLayer => playerObjLayer;

    public static GameLayers SharedInstance;

    void Awake()
    {
        if (SharedInstance == null) SharedInstance = this;
    }

    }
}
