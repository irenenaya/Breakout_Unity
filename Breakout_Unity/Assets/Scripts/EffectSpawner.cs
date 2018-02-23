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


	public void RunEffectAt(Vector2 pos, Color col = default(Color))
    {
        EffectWrapper effect = queue.Dequeue();
        effect.Play(pos, col);

        queue.Enqueue(effect);
    }


    public class EffectWrapper
    {
        public GameObject gameObject;
        private AudioSource sound;
        private ParticleSystem particles;
		private ParticleSystem.MainModule _main;

        public EffectWrapper(GameObject obj)
        {
            gameObject = obj;
            sound = obj.GetComponent<AudioSource>();
            particles = obj.GetComponent<ParticleSystem>();
			_main = particles.main;
        }

		public void Play(Vector2 pos, Color col = default(Color))
        {
            gameObject.transform.SetPositionAndRotation(pos, Quaternion.identity);
            sound.Play();
			_main.startColor = col;
            particles.Play();
        }
    }
}
