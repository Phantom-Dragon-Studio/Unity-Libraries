namespace PhantomDragonStudio.Core.Audio_Management
{
    public class AudioSourceHandler
    {
        public AudioSourceHandler(AudioSource[] sources)
        {
            AutoAssignSourcesByPriority(sources);
        }

        private AudioSource musicSource;
        private AudioSource sfxSource;
        
        public AudioSource MusicSource => musicSource;
        public AudioSource SpecialEffectsSource => sfxSource;
        
        public void AutoAssignSourcesByPriority(AudioSource[] sources)
        {
            if (sources != null)
            {
                foreach (AudioSource priorityCheck in sources)
                    switch (priorityCheck.priority)
                    {
                        case 1:
                            musicSource = priorityCheck;
                            break;
                        case 128:
                            sfxSource = priorityCheck;
                            break;
                    }
            }
            else
            {
                Debug.Log("Audio Sources is null!");
            }
        }
    }
}