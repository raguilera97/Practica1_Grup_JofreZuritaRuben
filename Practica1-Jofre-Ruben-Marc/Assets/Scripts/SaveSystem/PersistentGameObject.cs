using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PersistentGameObject : MonoBehaviour
{

    [SerializeField] public string GUID;

    void Update()
    {
        if (Application.isPlaying) return;
        if (string.IsNullOrEmpty(gameObject.scene.path)) return;

        if (string.IsNullOrEmpty(GUID))
        {
            GUID = Guid.NewGuid().ToString();
        }
    }

    public object CaptureState()
    {
        Dictionary<string, object> data = new Dictionary<string, object>();

        ISaveable[] saveables = GetComponents<ISaveable>();

        foreach(ISaveable saveable in saveables)
        {
            data[saveable.GetType().Name] = saveable.CaptureState();
        }

        return data;
    }

    public void RestoreState(object data)
    {
        Dictionary<string, object> dataToRestore = (Dictionary<string, object>)data;

        ISaveable[] saveables = GetComponents<ISaveable>();

        foreach(ISaveable saveable in saveables)
        {
            saveable.RestoreState(dataToRestore[saveable.GetType().Name]);
        }
    }

}
