using System;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField] private GameObject _TapToStartPanel;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void TapToStartGame()
    {
        _TapToStartPanel.gameObject.SetActive(false);
        GameManager.instance.StartGame();
    }
}
