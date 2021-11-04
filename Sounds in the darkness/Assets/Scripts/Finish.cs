using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class Finish : MonoBehaviour
{
    private PickupBehavior _playerPickupBehavior;
    //private BoxCollider _boxCollider;
    private void Start()
    {
        PlayerCharacter player = FindObjectOfType<PlayerCharacter>();
        if (player != null) _playerPickupBehavior = player.GetComponent<PickupBehavior>();
        //_boxCollider = GetComponent<BoxCollider>();
    }

    private const string PLAYER_TAG = "Player";

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == PLAYER_TAG)
        {
            if (_playerPickupBehavior.Pickups.Count == 0)
            {
                SceneManager.LoadScene(2);
            }
        }
    }

    public void TriggerRespawn()
    {
        SceneManager.LoadScene(0);
    }
}
