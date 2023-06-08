using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarchingSqauresSoundController : MonoBehaviour
{
    float level;
    public float treshold = 1f;
    public LoopbackAudio listener;
    public MarchingSquares marchingSquares;

    // Update is called once per frame
    void Update()
    {
        level = 0;
        
        for (int i = 0; i < listener.SpectrumData.Length; i++)
        {
                level += listener.SpectrumData[i] * listener.SpectrumData[i] * listener.SpectrumData[i] * 2f;
            
        }
        level += listener.SpectrumData[0] * listener.SpectrumData[0] * listener.SpectrumData[0];
        marchingSquares.speed = level / 200000 * listener.SpectrumData[0];
        Debug.Log(level);
    }
}
