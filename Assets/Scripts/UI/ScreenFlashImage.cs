using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFlashImage : MonoBehaviour
{
    [SerializeField] FlashImage _flashImage = null;
    [SerializeField] Color _newColor = Color.red;

    public void ScreenFlash()
    {
        _flashImage.StartFlash(.25f, .5f, _newColor);
    }
}
