using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    // <GUID, Dictionary<String, object>>
    Dictionary<string, object> data = new Dictionary<string, object>();

    public object Load()
    {
        // Deserialize data
        RestoreState();
        float a = 1.0f;
        return a;
    }

    public void Save(object data)
    {
        // Serializa data
        CaptureState();
    }

    private void CaptureState()
    {
        PersistentGameObject[] objectsToSave = FindObjectsOfType<PersistentGameObject>();

        foreach(PersistentGameObject objectToSave in objectsToSave)
        {
            data[objectToSave.GUID] = objectToSave.CaptureState();
        }
    }

    private void RestoreState()
    {
        PersistentGameObject[] objectsToLoad = FindObjectsOfType<PersistentGameObject>();

        foreach(PersistentGameObject objectToLoad in objectsToLoad)
        {
            objectToLoad.RestoreState(data[objectToLoad.GUID]);
        }
    }

}
