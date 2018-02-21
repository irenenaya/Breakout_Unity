using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public int queueSize;
    public GameObject effectObject;

    private Queue<EffectWrapper> queue = new Queue<EffectWrapper>();
	
    // Use this for initialization
	void Start()
    {

        for (int i = 0; i < queueSize; ++i)
        {
            EffectWrapper effect = new EffectWrapper(Instantiate(effectObject));
            queue.Enqueue(effect);
        }
	}


    public void PlaceAt(Vector2 pos)
    {
        EffectWrapper effect = queue.Dequeue();
        effect.Play(pos);
        // ret.SetActive(true);
        queue.Enqueue(effect);
    }


    public class EffectWrapper
    {
        public GameObject gameObject;
        private AudioSource sound;
        private ParticleSystem particles;

        public EffectWrapper(GameObject obj)
        {
            gameObject = obj;
            sound = obj.GetComponent<AudioSource>();
            particles = obj.GetComponent<ParticleSystem>();
        }

        public void Play(Vector2 pos)
        {
            gameObject.transform.SetPositionAndRotation(pos, Quaternion.identity);
            sound.Play();
            particles.Play();
        }
    }
}
