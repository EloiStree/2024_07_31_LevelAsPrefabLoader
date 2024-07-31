using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PrefabSceneGuidTagMono : MonoBehaviour
{
    public string m_guidOfPrefabScene = "00000000-0000-0000-0000-000000000000";
    private bool m_isInstanciated;

    private void Awake()
    {
        if (m_isInstanciated)
        {
            m_isInstanciated = true; 
        }
        PrefabSceneGuidMonoInScene.AddToLoadedScene(this);
        m_onSceneLoaded.Invoke();
    }

    public bool IsInstanceInScene()
    {
        return m_isInstanciated;
    }
    private void OnDestroy()
    {
        PrefabSceneGuidMonoInScene.RemoveToLoadedScene(this);
        m_onSceneUnloaded.Invoke();
    }

    [ContextMenu("Reset Guid")]
    private void ResetGuid()
    {
        m_guidOfPrefabScene = System.Guid.NewGuid().ToString();
    }

    [ContextMenu("Unload Scene")]
    public void UnloadSceneByDestroyingPrefabScene() {

        if (Application.isPlaying)
        { 
            Destroy(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    public UnityEvent m_onSceneLoaded;
    public UnityEvent m_onSceneUnloaded;
  

    private void Reset()
    {
        ResetGuid();
    }

}
