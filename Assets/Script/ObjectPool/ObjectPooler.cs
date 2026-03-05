using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<ObjectPoolItem> itemsToPool;
    private Dictionary<string, Queue<GameObject>> poolDictionary;
    
    private void Awake()
    {
        InitializePool();
    }
    
    private void InitializePool()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        
        foreach (ObjectPoolItem item in itemsToPool)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            
            for (int i = 0; i < item.poolSize; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }
            
            poolDictionary.Add(item.prefab.name, objectPool);
        }
    }
    
    public GameObject GetFromPool(string prefabName, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(prefabName))
        {
            Debug.LogWarning($"Pool with name {prefabName} doesn't exist.");
            return null;
        }
        
        if (poolDictionary[prefabName].Count == 0)
        {
            ExpandPool(prefabName);
        }
        
        GameObject objectToSpawn = poolDictionary[prefabName].Dequeue();
        
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        
        objectToSpawn.SetActive(true);
        
        IPooledObject pooledObject = objectToSpawn.GetComponent<IPooledObject>();
        if (pooledObject != null)
        {
            pooledObject.OnObjectSpawn(this);
        }
        
        
        return objectToSpawn;
    }
    
    public void ReturnToPool(string prefabName, GameObject objectToReturn)
    {
        if (!poolDictionary.ContainsKey(prefabName))
        {
            Debug.LogWarning($"Pool with name {prefabName} doesn't exist.");
            return;
        }
        
        objectToReturn.SetActive(false);
        poolDictionary[prefabName].Enqueue(objectToReturn);
    }
    
    private void ExpandPool(string prefabName)
    {
        ObjectPoolItem item = itemsToPool.Find(x => x.prefab.name == prefabName);
        if (item == null) return;
        
        GameObject newObj = Instantiate(item.prefab);
        newObj.SetActive(false);
        poolDictionary[prefabName].Enqueue(newObj);
    }
}