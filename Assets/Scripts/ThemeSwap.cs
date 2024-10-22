using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThemeSwap : MonoBehaviour
{
    [SerializeField]
    Image BackGround;
    [SerializeField]
    Sprite BG_R;
    [SerializeField]
    Sprite BG_G;
    [SerializeField]
    Sprite BG_B;
    float swap;
    void Start()
    {
        BackGround.sprite = BG_R;
        swap = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (swap == 0)
            {
                BackGround.sprite = BG_G;
                swap = 1;
            }
            else if (swap == 1)
            {
                BackGround.sprite = BG_B;
                swap = 2;
            }
            else
            {
                BackGround.sprite = BG_R;
                swap = 0;
            }
        }
    }
}
