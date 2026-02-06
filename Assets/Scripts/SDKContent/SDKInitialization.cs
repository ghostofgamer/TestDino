using System.Collections;
using System.Collections.Generic;
using BananaParty.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SDKContent
{
    public class SDKInitialization : MonoBehaviour
    {
        private const string MainScene = "MenuScene";

        private void Awake()
        {
#if UNITY_WEBGL&&!UNITY_EDITOR
            YandexGamesSdk.CallbackLogging = true;
#endif
        }

        private IEnumerator Start()
        {
#if UNITY_WEBGL&&!UNITY_EDITOR
            yield return YandexGamesSdk.Initialize(OnInitialized);
#else
            SceneManager.LoadScene(MainScene);
            yield break;
#endif
        }

        private void OnInitialized()
        {
            SceneManager.LoadScene(MainScene);
        }
    }
}