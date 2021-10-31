using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayTimeHUD : MonoBehaviour
{
    [SerializeField] private GameObject _colorImage;
    private Image _imageComponent;
    private PickupBehavior _playerPickupBehavior;

    private void Start()
    {
        if (_colorImage != null) _imageComponent = _colorImage.GetComponent<Image>();
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
    }
}
