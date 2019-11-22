using System.Collections;
using UnityEngine;
using System.Collections.Generic;


public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool1;
    public GameObject objectToPool2;
    public GameObject objectToPool3;
    public GameObject objectToPool4;
    public GameObject objectToPool5;
    public GameObject objectToPool6;
    public GameObject objectToPool7;

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
            GameObject obj = (GameObject)Instantiate(objectToPool1);
            GameObject obj2 = (GameObject)Instantiate(objectToPool2);
            GameObject obj3 = (GameObject)Instantiate(objectToPool3);
            GameObject obj6 = (GameObject)Instantiate(objectToPool6);
            GameObject obj4 = (GameObject)Instantiate(objectToPool4);
            GameObject obj5 = (GameObject)Instantiate(objectToPool5);
            GameObject obj7 = (GameObject)Instantiate(objectToPool7);



            obj.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
            obj5.SetActive(false);
            obj6.SetActive(false);
            obj7.SetActive(false);
            pooledObjects.Add(obj);
            pooledObjects.Add(obj2);
            pooledObjects.Add(obj3);
            pooledObjects.Add(obj4);
            pooledObjects.Add(obj5);
            pooledObjects.Add(obj6);
            pooledObjects.Add(obj7);
        }


    }

    public GameObject GetPooledObject()
    {
        //1
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            //2
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        //3   
        return null;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
