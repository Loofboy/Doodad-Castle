using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResolutionControl : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Dropdown resDropdown;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private double currentRefreshRate;
    private int currentResolutionIndex = 0;
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRateRatio.value;

        for(int i = 0; i < resolutions.Length; i++){
            if(resolutions[i].refreshRateRatio.value == currentRefreshRate){
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i = 0; i < filteredResolutions.Count; i++){
        string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRateRatio.value + " Hz";
        options.Add(resolutionOption);
        if(filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height){
            currentResolutionIndex = i;
            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();
    }
    public void SetRes(int resolutionindex){
        Resolution resolution = filteredResolutions[resolutionindex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
