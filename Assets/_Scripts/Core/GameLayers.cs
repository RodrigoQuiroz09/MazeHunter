using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeHunter
{
    public class GameLayers : MonoBehaviour
    {
    [SerializeField] private LayerMask wallObjLayer;

    public LayerMask WallObjLayer => wallObjLayer;

    public static GameLayers SharedInstance;

    void Awake()
    {
        if (SharedInstance == null) SharedInstance = this;
    }

    public LayerMask CollisionLayers => wallObjLayer;
    }
}
