using UnityEngine;

  namespace PhantomDragonStudio.Core.Audio_Management
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance = null;

        private AudioSourceHandler _audioSourceHandler;
        private AudioSource[] audioSources;

        //TODO Seperate these into their own ScriptableObject collections
        public AudioClip[] musicTrack;
        public AudioClip buttonSFX;

        public float MusicVolume
        {
            get => _audioSourceHandler.MusicSource.volume;
            set => _audioSourceHandler.MusicSource.volume = value;
        }
        
        public float EffectsVolume
        {
            get => _audioSourceHandler.SpecialEffectsSource.volume;
            set => _audioSourceHandler.SpecialEffectsSource.volume = value;
        }

        public void Awake()
        {
            if (instance != null)
                Destroy(gameObject);
            else
                instance = this;

            _audioSourceHandler = new AudioSourceHandler(GetComponents<AudioSource>());
            _audioSourceHandler.AutoAssignSourcesByPriority(audioSources);
            PlayMusic(0);
        }

        public void PlayMusic(int level)
        {
            Debug.Log("Playing this level music track: " + musicTrack[level]);
            if (!musicTrack[level]) return;
            _audioSourceHandler.MusicSource.clip = musicTrack[level];
            _audioSourceHandler.MusicSource.loop = true;
            _audioSourceHandler.MusicSource.Play();
        }

        public void PlayClickedSound()
        {
            _audioSourceHandler.SpecialEffectsSource.clip = buttonSFX;
            _audioSourceHandler.SpecialEffectsSource.loop = false;
            _audioSourceHandler.SpecialEffectsSource.Play();
        }
    }
}