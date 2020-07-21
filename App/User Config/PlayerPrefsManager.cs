using PhantomDragonStudio.Core.Audio_Management;
using UnityEngine;

namespace App.User_Config
{
    public static class PlayerPrefsManager
    {
        static PlayerPrefsManager()
        {
            Initialize();
        }
        
        const string MUSIC_VOLUME_KEY = "music_volume";
        const string EFFECTS_VOLUME_KEY = "effects_volume";

        public static void Initialize()
        {
            AudioManager.instance.MusicVolume = GetMusicVolume();
            AudioManager.instance.EffectsVolume = GetEffectsVolume();
        }

        public static void SetMusicVolume(float volume)
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        }

        public static float GetMusicVolume()
        {
            return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
        }

        public static void SetEffectsVolume(float volume)
        {
            PlayerPrefs.SetFloat(EFFECTS_VOLUME_KEY, volume);
        }

        public static float GetEffectsVolume()
        {
            return PlayerPrefs.GetFloat(EFFECTS_VOLUME_KEY);
        }
    }

}