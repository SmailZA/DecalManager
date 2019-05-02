using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecalManager : MonoBehaviour
{
    public GameObject DecalPrefab;
    int shootingPoolFreeIndex = 0;

    GameObject[] shootingPool = new GameObject[10];
    Queue<GameObject> queueForDecals = new Queue<GameObject>();

    #region Singleton
    public static DecalManager instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(instance);
        instance = this;
    }
    #endregion

    void Start()
    {
       
            for (int i = 0; i < shootingPool.Length; i++)
            {
                shootingPool[i] = Instantiate(DecalPrefab, transform.position, Quaternion.Euler(Vector3.zero), this.gameObject.transform);
            shootingPool[i].gameObject.SetActive(false);

            }
        
    }
    public GameObject GetInactiveDecal()
    {
        for (int i = 0; i < shootingPool.Length; i++)
        {
            if(shootingPool[i].activeInHierarchy == false)
            {
                queueForDecals.Enqueue(shootingPool[i]);
                return shootingPool[i];
            }
           
        }
        GameObject tempDecals = queueForDecals.Dequeue();
        queueForDecals.Enqueue(tempDecals);
        return tempDecals;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
