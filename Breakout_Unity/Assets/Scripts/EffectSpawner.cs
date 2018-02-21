using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    public int queueSize;
    public GameObject effectObject;

    private Queue<GameObject> queue = new Queue<GameObject>();
	
    // Use this for initialization
	void Start()
    {

        for (int i = 0; i < queueSize; ++i)
        {
            GameObject obj = Instantiate(effectObject);
            // obj.SetActive(false);
            queue.Enqueue(obj);

        }
	}


    public void PlaceAt(Vector2 pos)
    {
        GameObject ret = queue.Dequeue();
        ret.transform.position = pos;
        // ret.SetActive(true);
        ret.GetComponent<AudioSource>().Play();
        queue.Enqueue(ret);
    }
}
