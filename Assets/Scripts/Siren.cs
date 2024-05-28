using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Siren : MonoBehaviour
{
    [SerializeField] private Trigger _trigger;

    private AudioSource _sound;
    private Coroutine _coroutineIncreaseVolume;
    private Coroutine _coroutineReduceVolume;

    private void OnEnable()
    {
        _trigger.TriggerOccupied += TurnOnSiren;
        _trigger.TriggerVacated += TurnOffSiren;
    }

    private void OnDisable()
    {
        _trigger.TriggerOccupied -= TurnOnSiren;
        _trigger.TriggerVacated -= TurnOffSiren;
    }

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
        _sound.volume = 0;
    }

    private void TurnOnSiren()
    {
        if (_coroutineReduceVolume != null)
        {
            StopCoroutine(_coroutineReduceVolume);
        }

        float maxVolume = 1f;
        _sound.Play();
        _coroutineIncreaseVolume = StartCoroutine(ChangeVolume(maxVolume));
    }

    private void TurnOffSiren()
    {
        float minVolume = 0f;
        StopCoroutine(_coroutineIncreaseVolume);
        _coroutineReduceVolume = StartCoroutine(ChangeVolume(minVolume));
    }

    private IEnumerator ChangeVolume(float volume)
    {
        float changeVolumeRate = 0.7f;

        while (_sound.volume != volume)
        {
            _sound.volume = Mathf.MoveTowards(_sound.volume, volume, changeVolumeRate * Time.deltaTime);
            yield return null;
        }

        if (_sound.volume == 0)
        {
            _sound.Stop();
        }
    }
}