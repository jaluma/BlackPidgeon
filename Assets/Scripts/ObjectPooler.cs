using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] objectsToPool;
    public int amountToPool;


    private void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();
        for (int i = 0; i < amountToPool; i++)
        {
            for (int j = 0; j < objectsToPool.Length; j++)
            {
                GameObject obj = (GameObject)Instantiate(objectsToPool[j]);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }


    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {

            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
