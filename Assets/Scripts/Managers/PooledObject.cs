using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour {

    public ObjectPooler m_ObjectPooler;
    [HideInInspector] public Vector3 originalScale;
    
    public void ReturnToPool() {

        if(m_ObjectPooler == null)
        {
            m_ObjectPooler = GameObject.Find("DeadEnemies").GetComponent<ObjectPooler>();
        }

        m_ObjectPooler.ReturnObject(gameObject);
    }
}