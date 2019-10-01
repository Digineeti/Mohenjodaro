using UnityEngine.Audio;
using UnityEngine;using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instant;
    // Start is called before the first frame update
    void Awake()
    {
        if (instant == null)
            instant = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play(string name)
    {
        Sounds s = Array.Find(sounds, Sounds => Sounds.name == name);
        if(s==null)
        {
            Debug.Log("Sound: " + name +" not found");
            return;
        }
        s.source.Play();
    }
}
