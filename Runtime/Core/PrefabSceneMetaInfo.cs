using UnityEngine;


[System.Serializable]
public class PrefabSceneMetaInfo : I_GetPrefabSceneMetaInfo
{

    public string m_sceneName = "";
    public string m_sceneTitle = "";
    [TextArea(1, 4)]
    public string m_sceneDescription = "";

    public void GetSceneDescription(out string description)
    {
        description = m_sceneDescription;
    }

    public void GetSceneName(out string name)
    {
        name = m_sceneName;
    }

    public void GetSceneTitle(out string title)
    {
        title = m_sceneTitle;
    }
}