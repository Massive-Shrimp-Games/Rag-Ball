using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides an interface (facade pattern) to gameplay settings
/// Settings are Singleton Classes, and can be found in
/// Assets/_RagBall/Scripts/Settings directory
/// </summary>
public class SettingsManager : MonoBehaviour
{
    private List<Setting> Settings = new List<Setting>();
    
    public List<Setting> Setting()
    {
        return Settings;
    }

    public void Setting(Setting newSetting)
    {
        Settings.Add(newSetting);
    }

    public void Setting(Setting oldSetting, Object newValue)
    {
        Settings.Find(oldSetting).Setting(newValue);
    }




    
    void Start()
    {
        
    }

}
