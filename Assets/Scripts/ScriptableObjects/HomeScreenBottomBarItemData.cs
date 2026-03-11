using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;


[CreateAssetMenu(fileName = "HomeScreenBottomBarItemData", menuName = "Scriptable Objects/HomeScreenBottomBarItemData")]
public class HomeScreenBottomBarItemData : ScriptableObject {

    public Sprite MainIcon;

    public string MainText;

    public LocalizedString LocString;

    public bool Locked;
}
