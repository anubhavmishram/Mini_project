using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 Base_pos;
    private Vector3 Mid_pos;
    private Vector3 Panel_1_pos;
    private Vector3 Panel_2_pos;
    private Vector3 Top_pos;

    AudioSource source;
    public AudioClip base_clip;
    public AudioClip mid_clip;
    public AudioClip panel_1_clip;
    public AudioClip panel_2_clip;
    public AudioClip top_clip;


    void Start()
    {
        Base_pos = new Vector3(-22.0f,-4.0f,22.0f);
        Mid_pos = new Vector3(-28.0f,2.5f,22.0f);
        Panel_1_pos = new Vector3(-23.0f,-4.0f,28.0f);
        Panel_2_pos = new Vector3(-33.0f,4.0f,16.0f);
        Top_pos = new Vector3(-28.0f,8.0f,22.0f);


        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name == "Base" && source.isPlaying == false){
            collider.gameObject.transform.position = Base_pos;
            source.PlayOneShot(base_clip);
        }
        if(collider.gameObject.name == "Top" && source.isPlaying == false){
            collider.gameObject.transform.position = Top_pos;
            source.PlayOneShot(top_clip);

        }
        if(collider.gameObject.name == "Mid_part" && source.isPlaying == false){
            collider.gameObject.transform.position = Mid_pos;
            source.PlayOneShot(mid_clip);
        }
        if(collider.gameObject.name == "Solar_panel_1" && source.isPlaying == false){
            collider.gameObject.transform.position = Panel_1_pos;
            source.PlayOneShot(panel_1_clip);
        }
        if(collider.gameObject.name == "Solar_panel_2" && source.isPlaying == false){
            collider.gameObject.transform.position = Panel_2_pos;
            source.PlayOneShot(panel_2_clip);
            
        }

    }

    private void OnTriggerExit(Collider collider){
        
    }

}
