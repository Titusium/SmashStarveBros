using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeManager : MonoBehaviour {

    private Slider slider;
 
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = AudioListener.volume;
    }

    void Update()
    {
        AudioListener.volume = slider.value;
    }

}
