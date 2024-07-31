using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelPrefabByGuidMono : MonoBehaviour
{
   
    public string m_guidOfPrefabScene = "";

    public void LoadSceneAsSingle(string guid)
    {
        LoadLevelPrefabFromResources.LoadSceneAsSingle(guid);
    }
    public void LoadSceneAsAdditive(string guid)
    {
        LoadLevelPrefabFromResources.LoadSceneAsAdditive(guid);
    }
    [ContextMenu("Load Scene Single")]
    public void LoadSceneAsSingleFromInspector() { 
        LoadSceneAsSingle(m_guidOfPrefabScene);
    }
    [ContextMenu("Load Scene Additive")]
    public void LoadSceneAsAdditiveFromInspector() { 
        LoadSceneAsAdditive(m_guidOfPrefabScene);
    }

    [ContextMenu("Destroy Scenes")]
    public void UnloadAllScenes() { 
    
        LoadLevelPrefabFromResources.DestroyAllPrefabOfSceneLoaded();
    }
}

