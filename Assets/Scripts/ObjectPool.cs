using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPool 
{
    public GameObject prefabTool;
    public int amountToPool;

    private Queue<GameObject> poolQueue;

    public void InitPool()
    {
        poolQueue = new Queue<GameObject>();

        for(int i = 0; i < amountToPool; i++)
        {
            poolQueue.Enqueue(prepareCopy());
        }
    }

    public GameObject spawnAt(Vector3 position, Vector3 eulerRotation)
    {
        GameObject go = GetNextInLine();

        go.transform.position = position;
        go.transform.rotation = Quaternion.Euler(eulerRotation);

        go.SetActive(true);

        return go;
    }
    private GameObject GetNextInLine()
    {
        GameObject go;
        if(poolQueue.Count ==0 && !poolQueue.Peek().activeSelf)
        {
            go = poolQueue.Dequeue();
        }
        else
        {
            go = prepareCopy();
        }
        poolQueue.Enqueue(go);

        return go;
    }
    public GameObject prepareCopy()
    {
        GameObject copy = GameObject.Instantiate(prefabTool);
        copy.SetActive(false);
        return copy;
    }
}
