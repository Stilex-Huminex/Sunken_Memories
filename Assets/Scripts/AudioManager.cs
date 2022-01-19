using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private List<AudioClip> clips;

    public static AudioManager Instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        SceneManager.sceneLoaded += OnLoad;
    }

    private void PlayTrack(string inputName)
    {
        AudioClip introClip = null;
        AudioClip loopClip = null;
        foreach (var clip in clips.Where(clip => clip.name.StartsWith(inputName)))
        {
            if (clip.name.EndsWith("_intro"))
            {
                introClip = clip;
            }
            else
            {
                loopClip = clip;
            }
        }
        if (loopClip == null) return;
        source.time = 0;

        if (introClip != null)
        {
            StartCoroutine(PrepareLoop(introClip, loopClip));
        }
        else
        {
            source.clip = loopClip;
            source.Play();
        }
    }

    private IEnumerator PrepareLoop(AudioClip intro, AudioClip loop)
    {
        source.clip = intro;
        source.loop = false;
        source.Play();
        yield return new WaitWhile(() => source.isPlaying);
        source.clip = loop;
        source.Play();
        source.loop = true;
    }

    private static void OnLoad(Scene scene , LoadSceneMode mode)
    {
        print(scene.name);
        var name = scene.name;
        PlayerPrefs.SetString("PreviousArea", PlayerPrefs.GetString("LastArea", "zob"));
        PlayerPrefs.SetString("LastArea", name);
        Instance.PlayTrack(name);
    }
}
