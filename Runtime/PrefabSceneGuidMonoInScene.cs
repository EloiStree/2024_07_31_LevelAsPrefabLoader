using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabSceneGuidMonoInScene { 

    public static  List<PrefabSceneGuidTagMono> m_instanceInTheScene = new List<PrefabSceneGuidTagMono>();

    public static void AddToLoadedScene(PrefabSceneGuidTagMono prefabSceneGuidMono)
    {
        if(prefabSceneGuidMono!=null)
            m_instanceInTheScene.Add(prefabSceneGuidMono);
    }

    public static void RemoveToLoadedScene(PrefabSceneGuidTagMono prefabSceneGuidMono)
    {
        if (prefabSceneGuidMono != null)
            m_instanceInTheScene.Remove(prefabSceneGuidMono);
    }

    public static GameObject GetCreatedPrefabInScene(string guid)
    {
        if( m_instanceInTheScene==null)
        {
            return null;
        }
        foreach (var prefabSceneGuidMono in m_instanceInTheScene)
        {

            if (prefabSceneGuidMono &&  
                prefabSceneGuidMono.m_guidOfPrefabScene == guid)
            {
                return prefabSceneGuidMono.gameObject;
            }
        }
        return null;
    }

    public static PrefabSceneGuidTagMono[] GetAllPrefabAddedToSingleton()
    {
        return m_instanceInTheScene.ToArray();
    }
    public static PrefabSceneGuidTagMono[] GetAllPrefabInScene()
    {
        return GameObject.FindObjectsOfType<PrefabSceneGuidTagMono>(true).Where(k=>k.IsInstanceInScene()).ToArray();
    }


    public static void RemoveAllLoadedScenePrefab() { 
    
        PrefabSceneGuidTagMono[] prefabSceneGuidMonos = GetAllPrefabInScene();
        foreach (var prefabSceneGuidMono in prefabSceneGuidMonos)
        {
            prefabSceneGuidMono.UnloadSceneByDestroyingPrefabScene();
        }
    }
}
