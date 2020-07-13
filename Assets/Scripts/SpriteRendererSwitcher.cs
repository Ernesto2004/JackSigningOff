using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererSwitcher : MonoBehaviour
{
    public SpriteRenderer toSwitch;
    public bool gameObjectactive;

    public void Switch(){
        gameObjectactive = !gameObjectactive;
        toSwitch.enabled = gameObjectactive;
    }
}
