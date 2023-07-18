using UnityEngine;
using UnityEngine.UI;

public class ChangeVolume : MonoBehaviour
{
    [SerializeField] internal AudioSource _audio;
    [SerializeField] internal Slider _volume;

    private void OnEnable()
    {
        _volume = GetComponent<Slider>();
    }
    public void ChangeAudio()
    {
        Audio();
    }
    private void Audio()
    {
        _audio.volume = _volume.value;
    }
}
