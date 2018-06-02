using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class RunningSceneController : MonoBehaviour {

    [SerializeField]
    public AudioSource source;

    [SerializeField]
    public Text _timerText = null;

    public enum Phase
    {
        Ready = 0,
        Run = 1,
        Goal = 2,
    }

    public Phase CurrentPhase = Phase.Ready;

    public float Timer = 5.0f;

    private Boolean _finishLastReq = false;

	// Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
#if UNITY_EDITOR
        Debug.Log("UNITY_EDITOR");
        StartCoroutine(PlayVoiceUnityChan("ogg", "とも君,張り切っていこう！"));
        StartCoroutine(RunnningPlayVoice("ogg", 100));
#elif UNITY_IOS
        Debug.Log("UNITY_EDITOR");
        StartCoroutine(PlayVoiceUnityChan("mp3", "とも君,張り切っていこう！"));
        StartCoroutine(RunnningPlayVoice("mp3", 100));
#endif
	}
	
	// Update is called once per frame
	void Update () {
        if (Timer <= 0)
        {
            CurrentPhase = Phase.Goal;
            Timer = 0.0f;

            if(!_finishLastReq)
            {
                #if UNITY_EDITOR
                Debug.Log("UNITY_EDITOR");
                StartCoroutine(PlayVoiceUnityChan("ogg", "とも君,お疲れ様！"));
                StartCoroutine(RunnningPlayVoice("ogg", 100));
#elif UNITY_IOS
            Debug.Log("UNITY_EDITOR");
            StartCoroutine(PlayVoiceUnityChan("mp3", "とも君,お疲れ様！));
            StartCoroutine(RunnningPlayVoice("mp3", 100));
#endif
                _finishLastReq = true;
            }
            return;
        }

        Timer -= Time.deltaTime;
        var seconds = (int)Timer;
        _timerText.text = seconds.ToString();
	}
    private IEnumerator PlayVoiceUnityChan(string ext, string comment)
    {
        var username = "spajam2018";
        var password = "Lpnsen58";
        var input_type = "ssml";
        var speaker_name = "reina";
        var use_wdic = "1";

        var url = string.Format(
            "https://webapi.aitalk.jp/webapi/v2/ttsget.php?username={0}&password={1}&text={2}&input_type={3}&speaker_name={4}&volume=1.00&speed=1.30&pitch=1.00&range=1.00&style=%7B%22j%22%3A%221.0%22%2C%22s%22%3A%220.0%22%2C%22a%22%3A%220.0%22%7D&ext={5}&use_wdic={6}",
            username,
            password,
            comment,
            input_type,
            speaker_name,
            ext,
            use_wdic
        );
        var uri = new Uri(url);
        print(uri.AbsoluteUri);

        using (var www = new WWW(uri.AbsoluteUri))
        {
            yield return www;
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
            yield return new WaitUntil(() => !source.isPlaying);
            // ボイス鳴り終わってからちょい待つ
            yield return new WaitForSeconds(3);
            CurrentPhase++;
        }

    }

    private IEnumerator RunnningPlayVoice(string ext, int sec)
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
                if(CurrentPhase != Phase.Goal)
                {
                    source.Play();
                }
                else
                {
                    break;
                }

            }
        }
    }
}
