using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{


    public static AudioManager inst;


    private List<AudioSource> audioSources = new List<AudioSource>();

    public int audioSourceCount = 5;

    private float minPitch = 0.8f;

    private float maxPitch = 1.2f;



    public AudioClip[] footsteps;

    private int lastIndex; 





    private void Awake()
    {
        if (inst == null)
        {
            inst = this;

        }
        else
        {
            Destroy(gameObject);
        
        
        }


        CreateAudioSource();


    }


    //Can call from any script to play a sound in any relative position
    public void PlaySoundAtPosition(AudioClip clip, Vector3 worldPos, float volume = 1 )
    {
        AudioSource source = null;

        for (int i = 0; i < audioSources.Count; i++) 
        {
            if (audioSources[i].isPlaying)  //go through the list and the one not playing becomes the source
            {
                source = audioSources[i];
                break; //exit the loop to then go play the next song


            }

        
        }

        if (source != null)
        {
            source.clip = clip;
            source.volume = volume;
            source.transform.position = worldPos;

            source.pitch = Random.Range(minPitch, maxPitch);

            source.Play();


        }


    }


    public void PlayFootstep(AudioSource source)
    {

        int randomIndex = Random.Range(0, footsteps.Length);

        if (footsteps.Length == 1)
        {
            randomIndex = 0;

        }
        else
        {
            randomIndex++;
        
        }

        if (randomIndex >= footsteps.Length)
        {
            randomIndex = 0;

        }

        lastIndex = randomIndex;

        source.clip = footsteps[randomIndex];
        source.Play();




    }



    //Can create from scratch instead of using prefabs
    private void CreateAudioSource() 
    {
        for (int i = 0; i < audioSourceCount; i++)
        {
            GameObject obj = new GameObject("AudioSource");
            obj.transform.SetParent(transform);

            AudioSource source = obj.AddComponent<AudioSource>();
            audioSources.Add(source);

            source.spatialBlend = 1;
            source.playOnAwake = false;



        }

    
    
    
    }










}
