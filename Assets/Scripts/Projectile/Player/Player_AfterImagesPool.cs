using System.Collections.Generic;
using UnityEngine;

public class Player_AfterImagesPool : MonoBehaviour
{
    [SerializeField]
    GameObject afterImagePrefab;

    Queue<GameObject> availableObjects = new Queue<GameObject>();

    public static Player_AfterImagesPool Instance { get; private set; }

    [Range(1, 15)]
    public int clones = 5;

    private void Awake() {
        Instance = this;
        GrowPool();
    }

    void GrowPool() 
    {
        for (int i = 0; i < clones; i++)
        {
            var instanceToAdd = Instantiate(afterImagePrefab);
            instanceToAdd.transform.SetParent(transform);

            AddToPool(instanceToAdd);
        }
    }

    public void AddToPool(GameObject instance) 
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }

    public GameObject GetFromPool() 
    {
        if (availableObjects.Count == 0)
        {
            GrowPool();
        }

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
}
