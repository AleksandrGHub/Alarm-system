using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Siren : MonoBehaviour
{
    private AudioSource _sound;
    private Coroutine _coroutine;

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = 0;
    }

    public void TurnOnSiren()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        float maxSoundLevel = 1f;
        _sound.Play();
        LaunchCoroutine(maxSoundLevel);
    }

    public void TurnOffSiren()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        float minSoundLevel = 0f;
        LaunchCoroutine(minSoundLevel);
    }

    private void LaunchCoroutine(float soundLevel)
    {
        _coroutine = StartCoroutine(ChangeVolume(soundLevel));
    }

    private IEnumerator ChangeVolume(float soundLevel)
    {
        float changeVolumeRate = 0.7f;

        while (_sound.volume != soundLevel)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, soundLevel, changeVolumeRate * Time.deltaTime);
            yield return null;
        }

        if (_sound.volume == 0)
        {
            _sound.Stop();
        }
    }
}