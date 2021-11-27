using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _player = null;

    private void Update()
    {
        if (_player == null)
            TriggerGameOver();
    }

    void TriggerGameOver()
    {
        SceneManager.LoadScene(3);
    }

    private const string TRIGGERRESPAWN_METHODNAME = "TriggerRespawn";

    public void TriggerRespawn()
    {
        SceneManager.LoadScene(0);
    }
}
