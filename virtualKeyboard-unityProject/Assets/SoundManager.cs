using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    bool _keyDown;
    bool _keyUp;

    [SerializeField]GameObject _sound;
    AudioSource a;
    InputManager iM;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -24; i <= 36; i++)
        {
            Instantiate(_sound);
            _sound.name = i.ToString();
            _sound.GetComponent<Key>().keyPos = i;
            _sound.transform.parent = GameObject.Find("KeyOrigin").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
