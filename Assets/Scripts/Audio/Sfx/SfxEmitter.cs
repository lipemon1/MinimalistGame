using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MinimalGame.Audio
{
    [System.Serializable]
    public struct SfxItem
    {
        public SfxKey Key;
        public AudioClip Clip;
    }
    
    public enum SfxKey
    {
        ChangeConductor = 0,
        InterfaceClick = 1,
        Win = 2
    }
    
    public class SfxEmitter : MonoBehaviour
    {
        public static SfxEmitter Instance { get; set; }

        [SerializeField] AudioSource audioSource;
        [SerializeField] List<SfxItem> sfxList = new List<SfxItem>();

        void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(this.gameObject);
        }

        public void PlaySfx(SfxKey key)
        {
            audioSource.PlayOneShot(GetAudioClipByKey(key));
        }

        AudioClip GetAudioClipByKey(SfxKey key)
        {
            return sfxList.First(ac => ac.Key == key).Clip;
        }
    }
}
