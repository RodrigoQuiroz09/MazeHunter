using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldGameLayers : MonoBehaviour
{
    [SerializeField] private LayerMask wallObjLayer;

    public LayerMask WallObjLayer => wallObjLayer;

    public static OldGameLayers SharedInstance;

    void Awake()
    {
        if (SharedInstance == null) SharedInstance = this;
    }

    public LayerMask CollisionLayers => wallObjLayer;

}
