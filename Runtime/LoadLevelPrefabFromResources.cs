using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LoadLevelPrefabFromResources 
{
    public static Dictionary<string, PrefabSceneGuidTagMono> m_prefabInResources = new Dictionary<string, PrefabSceneGuidTagMono>();

    public static void LoadSceneAsAdditive(string guid)
    {
        ReloadAllScenePrefabInRessourcesToList();
        if (m_prefabInResources.ContainsKey(guid))
        {
            PrefabSceneGuidTagMono prefabSceneGuidMono = m_prefabInResources[guid];
            if (prefabSceneGuidMono != null)
            {
                GameObject go = GameObject.Instantiate(prefabSceneGuidMono.gameObject);
                go.transform.position = Vector3.zero;
                go.transform.rotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;
            }
        }
    }
    public static void LoadSceneAsSingle(string guid)
    {
        ReloadAllScenePrefabInRessourcesToList();
        DestroyAllPrefabOfSceneLoaded();
        if (m_prefabInResources.ContainsKey(guid))
        {
            PrefabSceneGuidTagMono prefabSceneGuidMono = m_prefabInResources[guid];
            if (prefabSceneGuidMono != null)
            {
                GameObject go = GameObject.Instantiate(prefabSceneGuidMono.gameObject);
                go.transform.position = Vector3.zero;
                go.transform.rotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;
            }
        }
    }

    public static void ReloadAllScenePrefabInRessourcesToList()
    {
        GameObject[] prefab = Resources.LoadAll<GameObject>("");
        foreach (var go in prefab)
        {
            PrefabSceneGuidTagMono prefabSceneGuidMono = go.GetComponent<PrefabSceneGuidTagMono>();
            if (prefabSceneGuidMono != null)
            {
                if (!m_prefabInResources.ContainsKey(prefabSceneGuidMono.m_guidOfPrefabScene))
                    m_prefabInResources.Add(prefabSceneGuidMono.m_guidOfPrefabScene, prefabSceneGuidMono);
            }
        }
       
    }

    public static void LoadAllLevelPrefabInScenes() {

        ReloadAllScenePrefabInRessourcesToList();
        foreach (var prefabSceneGuidMono in m_prefabInResources.Values)
        {
            if (prefabSceneGuidMono != null)
            {
                GameObject go = GameObject.Instantiate(prefabSceneGuidMono.gameObject);
                go.transform.position = Vector3.zero;
                go.transform.rotation = Quaternion.identity;
                go.transform.localScale = Vector3.one;
            }
        }

    }

    public static void DestroyAllPrefabOfSceneLoaded() {

        PrefabSceneGuidTagMono[] sceneloaded = PrefabSceneGuidMonoInScene.GetAllPrefabInScene();
        foreach (var scenePrefabLoaded in sceneloaded)
        {
            if(scenePrefabLoaded!=null)
              scenePrefabLoaded.UnloadSceneByDestroyingPrefabScene(); 
        }
        sceneloaded = PrefabSceneGuidMonoInScene.GetAllPrefabAddedToSingleton();
        foreach (var scenePrefabLoaded in sceneloaded)
        {
            if (scenePrefabLoaded != null)
                scenePrefabLoaded.UnloadSceneByDestroyingPrefabScene();
        }

    }

    public static void UnloadScene(string guid) {
       GameObject prefab= PrefabSceneGuidMonoInScene.GetCreatedPrefabInScene(guid);
        if (prefab != null)
        {
            if (Application.isPlaying)
            {
                GameObject. Destroy(prefab);
            }
            else
            {
                GameObject.DestroyImmediate(prefab);
            }
        }


    }

   
}
