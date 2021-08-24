    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolHandler : MonoBehaviour
{
    public List<ObjectPool> prefabsToPool;
    private  static ObjectPoolHandler current;

    public void Awake()
    {
        current = this;
        foreach(var item in prefabsToPool)
        {
            item.InitPool();
        }
    }

    public static GameObject SpawnAt(GameObject prefab, Vector3 position, Vector3 eulerRotation)
    {
        foreach(var item in current.prefabsToPool)
        {
            if(item.prefabTool == prefab)
            {
              return (item.spawnAt(position, eulerRotation));
            }
        }
        return null;
    }
}
