using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using App.Common;
using System.IO;
using System;

namespace App.TitleScene
{
    public class TitleSceneController : MonoBehaviour
    {
        [SerializeField]
        private Text _countText = null;

        private int _count = 0;

        public AudioSource source;

        private void Start()
        {
            //SoundManager.Instance.PlayBGM(1);
            source = gameObject.AddComponent<AudioSource>();
        }

        public void OnClickVRButton()
        {
            //SoundManager.Instance.PlaySE(0);
            SceneManager.LoadScene("RunningScene");
        }

        public void OnClickAddTenButton()
        {
            //this.StreamPlayAudioFile();

            // Unityエディタ上なら何もしない
#if UNITY_EDITOR
            Debug.Log("NOT IOS. DO NOTHING.");
            StartCoroutine(StreamPlayAudioFile("ogg", 100));
#elif UNITY_IOS
            _count = _count + IOSPluginCallManager.PlusTen();
            StartCoroutine(StreamPlayAudioFile("mp3", 100));
#endif
            _countText.text = _count.ToString();
        }


        private IEnumerator StreamPlayAudioFile(string ext, int sec)
        {
            var username = "spajam2018";
            var password = "Lpnsen58";
            var input_type = "ssml";
            var speaker_name = "reina";
            var use_wdic = "1";

            var interval = sec / 10;

            // ランニング中
            for (int count = 0; count < sec; count += 10)
            {

                var text = "とも君,がんばれ！";

                var url = string.Format(
                    "https://webapi.aitalk.jp/webapi/v2/ttsget.php?username={0}&password={1}&text={2}&input_type={3}&speaker_name={4}&volume=1.00&speed=1.30&pitch=1.00&range=1.00&style=%7B%22j%22%3A%221.0%22%2C%22s%22%3A%220.0%22%2C%22a%22%3A%220.0%22%7D&ext={5}&use_wdic={6}",
                    username,
                    password,
                    text,
                    input_type,
                    speaker_name,
                    ext,
                    use_wdic
                );
                var uri = new Uri(url);
                print(uri.AbsoluteUri);

                using (var www = new WWW(uri.AbsoluteUri))
                {
                    //yield return www;
                    yield return new WaitForSeconds(interval);
                    switch (ext)
                    {
                        case "mp3":
                            source.clip = www.GetAudioClip(true, false, AudioType.MPEG);
                            break;
                        case "ogg":
                            source.clip = www.GetAudioClip(true, false, AudioType.OGGVORBIS);
                            break;
                        default:
                            source.clip = www.GetAudioClip(true, false, AudioType.MPEG);
                            break;
                    }
                    source.Play();
                }
            }
        }


    }
}
