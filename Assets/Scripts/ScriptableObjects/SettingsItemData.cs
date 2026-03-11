using UnityEngine;
using UnityEngine.Localization;


[CreateAssetMenu(fileName = "SettingsItemData", menuName = "Scriptable Objects/SettingsItemData")]
public class SettingsItemData : ScriptableObject {

    public Sprite MainIcon;

    public string MainText;

    public LocalizedString LocString;
    
}
