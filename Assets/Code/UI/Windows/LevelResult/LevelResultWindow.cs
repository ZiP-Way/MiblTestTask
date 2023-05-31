using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.LevelResult
{
  public class LevelResultWindow : AbstractScreen<LevelResultViewModel>
  {
    private const string PlayedTimeStr = "Played time: {0}s";

    [SerializeField]
    private Button _restartButton;

    [SerializeField]
    private TMP_Text _playedTimeText;

    public void Construct(LevelResultViewModel levelResultViewModel) => 
      ViewModel = levelResultViewModel;

    private void Awake() => 
      _restartButton.onClick.AddListener(RestartButtonClicked);

    private void Start()
    {
      _playedTimeText.text = string
        .Format(PlayedTimeStr, ViewModel.GetPlayedTime());
    }

    private void RestartButtonClicked() => 
      ViewModel.RestartLevel();
  }
}