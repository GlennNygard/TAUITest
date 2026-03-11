using System;
using PrimeTween;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelCompleteView : MonoBehaviour {

    [SerializeField]
    private Button _homeButton;

    [SerializeField]
    private LevelCompleteTitleView _levelCompleteTitleView;

    [SerializeField]
    private LevelCompleteStarView _levelCompleteStarView;

    [SerializeField]
    private LevelCompleteItemRowView _levelCompleteItemRowView;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [Header("Configuration")]
    [SerializeField]
    private float _scoreAnimationDuration = 2f;

    public event Action OnHomeButtonSelected;
    private ParticleSystem[] _particleSystems;


    void Awake() {
        _particleSystems = GetComponentsInChildren<ParticleSystem>(includeInactive: true);
        Hide();
    }

    void Start() {

        if(_homeButton != null) {
            _homeButton.onClick.AddListener(()=> OnHomeButtonSelected?.Invoke());
        }
    }

    public void Show() {

        _levelCompleteTitleView.Show();
        _levelCompleteItemRowView.Show();

        _levelCompleteStarView.Show(onComplete: () => {
            foreach(ParticleSystem ps in _particleSystems) {
                ps.Play();
            }
        });

        int scoreTarget = -1;
        if(int.TryParse(_scoreText.text, out int result)) {
            scoreTarget = result;
        }

        Tween.Custom(
            0f, 1f,
            duration: _scoreAnimationDuration,
            ease: Ease.OutCubic,
            onValueChange: (float val) => {
                if(scoreTarget >= 0) {
                    _scoreText.text = Mathf.FloorToInt((float)scoreTarget * val).ToString();
                }
        });
    }

    public void Hide() {
        foreach(ParticleSystem ps in _particleSystems) {
            ps.Stop(withChildren: true, stopBehavior: ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
