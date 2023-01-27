using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    GameObject gameManager;
    GameObject keyOrigin;
    SoundManager s;
    InputManager im;
    AudioSource a;
    SpriteRenderer sr;
    Transform t;
    bool held;
    public int keyPos;

    public int keyPosLocal;
    public int octave;
    Sprite[] keySprites;
    // Start is called before the first frame update
    void Start()
    {
        keyOrigin = GameObject.Find("KeyOrigin");
        t = GetComponent<Transform>();
        sr = GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager");
        a = GetComponent<AudioSource>();
        s = gameManager.GetComponent<SoundManager>();
        im = gameManager.GetComponent<InputManager>();

        gameManager.GetComponent<VisualManager>().KeyVisualData(keyPos,out keyPosLocal,out octave,out keySprites);
        Debug.Log(keyPosLocal);
    }

    // Update is called once per frame
    void Update()
    {
        if(im.Key(keyPos) > 0.1f && !held)
        {
            sr.sprite = keySprites[1];
            a.volume = im.Key(keyPos);                  
            a.pitch = Mathf.Pow(Mathf.Pow(2,1/12f),keyPos);
            a.time = 0;
            a.Play();   
            held = true;
        }
        if(im.Key(keyPos) <= 0.1f)
        {
            sr.sprite = keySprites[0];
            a.Stop();
            held = false;
        }     
        
        if(keyPosLocal < 5)
        {
            t.position = new Vector3(octave*112/keySprites[1].pixelsPerUnit + keyPosLocal*8/keySprites[1].pixelsPerUnit,0) + keyOrigin.GetComponent<Transform>().position;
        }
        if(keyPosLocal > 4)
        {
            t.position = new Vector3(octave*112/keySprites[1].pixelsPerUnit + (keyPosLocal+1)*8/keySprites[1].pixelsPerUnit,0) + keyOrigin.GetComponent<Transform>().position;
        }
    }
}
