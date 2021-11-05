using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayTimeHUD : MonoBehaviour
{
    [SerializeField] private GameObject _colorImage;
    private Image _imageComponent;
    private PickupBehavior _playerPickupBehavior;
    [SerializeField] private GameObject _timerFiller;
    private Image _timerFillerImageComponent;
    [SerializeField] private GameObject _timerFillerBackground;
    private Image _timerFillerBackgroundImageComponent;
    [SerializeField] private GameObject _pickupHelpText;
    private Text _pickupHelpTextComponent;

    private void Start()
    {
        if (_colorImage != null) _imageComponent = _colorImage.GetComponent<Image>();
        if (_timerFiller != null) _timerFillerImageComponent = _timerFiller.GetComponent<Image>();
        if (_timerFillerBackground != null)
            _timerFillerBackgroundImageComponent = _timerFillerBackground.GetComponent<Image>();
        if (_pickupHelpText != null) _pickupHelpTextComponent = _pickupHelpText.GetComponent<Text>();
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();

        if (player != null)
        {
            _playerPickupBehavior = player.GetComponent<PickupBehavior>();
        }
    }

    private void Update()
    {
        SyncData();
    }

    private void SyncData()
    {
        if (_imageComponent && _playerPickupBehavior)
        {
            _imageComponent.fillAmount = (1.0f / 3.0f) * _playerPickupBehavior.PickedUpItems.Count;
        }

        if (_timerFillerImageComponent && _playerPickupBehavior)
        {
            if (_playerPickupBehavior.HasPickupInRange)
            {
                _pickupHelpTextComponent.enabled = true;
                _timerFillerImageComponent.enabled = true;
                _timerFillerBackgroundImageComponent.enabled = true;
                _timerFillerImageComponent.fillAmount = _playerPickupBehavior.AccuTime / _playerPickupBehavior.PickupSpeed;
            }
            else
            {
                _pickupHelpTextComponent.enabled = false;
                _timerFillerImageComponent.enabled = false;
                _timerFillerBackgroundImageComponent.enabled = false;
            }
        }
    }
}
