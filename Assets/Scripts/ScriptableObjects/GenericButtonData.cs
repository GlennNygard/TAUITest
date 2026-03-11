using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Localization;


[CreateAssetMenu(fileName = "GenericButtonData", menuName = "Scriptable Objects/GenericButtonData")]
public class GenericButtonData : ScriptableObject {

    public string MainText;

    public LocalizedString LocString;
    
}
