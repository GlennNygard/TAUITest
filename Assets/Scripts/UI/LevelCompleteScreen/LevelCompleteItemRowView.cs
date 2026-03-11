using System.Collections.Generic;
using PrimeTween;
using UnityEngine;


public class LevelCompleteItemRowView : MonoBehaviour {

    [Header("Configuration")]
    [SerializeField]
    private float _itemAnimationDuration = 1f;


    private RectTransform[] _rowItems;


    private void Awake() {
        var itemList = new List<RectTransform>();
        foreach(Transform trans in transform) {
            RectTransform rt = trans.gameObject.GetComponent<RectTransform>();
            itemList.Add(rt);
        }

        _rowItems = itemList.ToArray();
    }


    public void Show() {

        Tween.Custom(
            0f, 1f,
            duration: _itemAnimationDuration,
            ease: Ease.OutCubic,
            onValueChange: (float val) => {

                foreach(RectTransform rt in _rowItems) {
                    rt.localScale = Vector3.Lerp(Vector3.one * 0.8f, Vector3.one, val);
                }
        });
    }
}
