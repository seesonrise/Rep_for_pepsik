using UnityEngine;
using UnityEngine.UI;

public class AudioMute : MonoBehaviour
{
    [SerializeField] internal AudioSource _audio;
    [SerializeField] internal Slider _volume;
    [SerializeField] internal Sprite[] _stateAudio;

    private void ChangeAudio()
    {
        Audio();
    }
    private void Audio()
    {
        if (_audio.volume == 0)
        {
            _audio.volume = 1;
            gameObject.GetComponent<Image>().sprite = _stateAudio[0];
        }
        else
        {
            _audio.volume = 0;
            gameObject.GetComponent<Image>().sprite = _stateAudio[1];
        }
    }
}
