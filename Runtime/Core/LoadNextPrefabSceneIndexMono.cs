using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNextPrefabSceneIndexMono : MonoBehaviour
{
    public PrefabSceneGuidTagMono[] m_sceneInResources;

    public int m_currentSceneIndex = 0;

    [ContextMenu("Refresh Scene in current project")]
    public void LoadCurrentScenesInResources() {

        LoadLevelPrefabFromResources.ReloadAllScenePrefabInRessourcesToList();
        m_sceneInResources = LoadLevelPrefabFromResources.GetAllScenesPrefabReloaded();
    }



    [ContextMenu("Destroy all scene prefab.")]
    public void RemoveAllPrefabs() { 
    
        LoadLevelPrefabFromResources.DestroyAllPrefabOfSceneLoaded();
    }

    [ContextMenu("Load Next Scene")]
    public void LoadNextLevelAsSingle()
    {
        if (m_sceneInResources.Length == 0)
            return;
        m_currentSceneIndex++;
        if (m_currentSceneIndex >= m_sceneInResources.Length)
            m_currentSceneIndex = 0;
        loadFromIndex(m_currentSceneIndex);
    }
    [ContextMenu("Load Previous Scene")]
    public void LoadPreviousLevelAsSingle()
    {
        if (m_sceneInResources.Length == 0)
            return;
        m_currentSceneIndex--;
        if (m_currentSceneIndex < 0)
            m_currentSceneIndex = m_sceneInResources.Length - 1;
        loadFromIndex(m_currentSceneIndex);
    }

    private void loadFromIndex(int index)
    {
        PrefabSceneGuidTagMono tag = m_sceneInResources[index];
        if(tag != null)
            LoadLevelPrefabFromResources.LoadSceneAsSingle(tag.m_guidOfPrefabScene);
    }
}
