using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMain : MonoBehaviour
{
    private AudioMain audioMain;


    private void Awake()
    {
        audioMain = new AudioMain();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (audioMain != null && audioMain != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            audioMain = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
