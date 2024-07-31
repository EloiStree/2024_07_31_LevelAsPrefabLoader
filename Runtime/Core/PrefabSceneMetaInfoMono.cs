using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSceneMetaInfoMono : MonoBehaviour, I_GetPrefabSceneMetaInfo
{

    public PrefabSceneMetaInfo m_metaInfo = new PrefabSceneMetaInfo();

    public void GetSceneDescription(out string description)
    {
        m_metaInfo.GetSceneDescription(out description);
    }

    public void GetSceneName(out string name)
    {
        m_metaInfo.GetSceneName(out name);
    }

    public void GetSceneTitle(out string title)
    {
        m_metaInfo.GetSceneTitle(out title);
    }
}
