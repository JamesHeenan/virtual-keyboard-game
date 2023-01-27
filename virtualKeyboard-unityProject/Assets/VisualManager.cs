using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualManager : MonoBehaviour
{
    char[] shapeOrder = new char[] {'r','b','m','b','l','r','b','m','b','m','b','r'};
    
    public Sprite right1;
    public Sprite right2;
    public Sprite middle1;
    public Sprite middle2;
    public Sprite left1;
    public Sprite left2;
    public Sprite black1;
    public Sprite black2;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void KeyVisualData(int keyPos, out int keyPosLocal, out int octave, out Sprite[] keySprites)
    {
        if(keyPos >= 0)
        {
            octave = keyPos/12;
            keyPosLocal = keyPos%12;
        }
        else
        {
            octave = -Mathf.Abs(keyPos)/12 -1;
            keyPosLocal =   12 +   keyPos%12;
            if(keyPosLocal == 12)
            {
                octave = -Mathf.Abs(keyPos)/12;
                keyPosLocal = 0;
            }
        }

        if(keyPosLocal == 0 || keyPosLocal == 5 )
            keySprites = new Sprite[] {right1,right2};
        else if(keyPosLocal == 4 || keyPosLocal == 11)
            keySprites = new Sprite[] {left1,left2};
        else if(keyPosLocal == 2 || keyPosLocal == 7 || keyPosLocal == 9)
            keySprites = new Sprite[] {middle1,middle2};
        else
            keySprites = new Sprite[] {black1,black2};
    }
    // Update is called once per frame
    void Update()
    {
  
    }
}
