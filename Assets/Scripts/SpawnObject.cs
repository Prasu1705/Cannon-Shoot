using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public int xPos;
    public int zPos;
    public int objCount;

    // Update is called once per frame
    public void ObjSpawn()
    {
       
        for(int i = 0; i< objCount; i++)
        {
            xPos = Random.Range(-15, 14);
            zPos = Random.Range(2, 46);
            ObjectPoolHandler.SpawnAt(objToSpawn, new Vector3(xPos, 0, zPos), Vector3.zero);
        }
        gameObject.SetActive(false);
    }
}
