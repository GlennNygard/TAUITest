using UnityEngine;

[CreateAssetMenu(fileName = "HomeScreenInventoryItemData", menuName = "Scriptable Objects/HomeScreenInventoryItemData")]
public class HomeScreenInventoryItemData : ScriptableObject {

    public Sprite MainIcon;

    public string LabelText;

    public string IconText;

    public bool CanAdd;
    
}
