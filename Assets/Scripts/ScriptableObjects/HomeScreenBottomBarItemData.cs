using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "HomeScreenBottomBarItemData", menuName = "Scriptable Objects/HomeScreenBottomBarItemData")]
public class HomeScreenBottomBarItemData : ScriptableObject {

    public Sprite MainIcon;

    public string MainText;

    public bool Locked;
    
}
