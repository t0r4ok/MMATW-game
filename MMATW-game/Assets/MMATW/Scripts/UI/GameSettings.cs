using UnityEngine;

namespace MMATW.Scripts.UI
{
    public class GameSettings : MonoBehaviour
    {
        [SerializeField] private float _defaultSoundVolume = 1.0f;
        [SerializeField] private float _defaultMusicVolume = 1.0f;

        public float SoundVolume { get; private set; }
        public float MusicVolume { get; private set; }

        private void Awake()
        {
            SoundVolume = _defaultSoundVolume;
            MusicVolume = _defaultMusicVolume;
        }

        public void SetSoundVolume(float value)
        {
            SoundVolume = value;
        }

        public void SetMusicVolume(float value)
        {
            MusicVolume = value;
        }

    }
}
