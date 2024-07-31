using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabSceneIconInfoMono : MonoBehaviour
{
    public Texture2D m_icon;

    public void GetIcon(out Texture2D icon)
    {
        icon = m_icon;
    }
}

public interface I_GetPrefabSceneIconInfo
{
    void GetIcon(out Texture2D icon);
}
