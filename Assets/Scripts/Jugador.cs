using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Jugador : MonoBehaviour
{
    //Velocidad
    public float velocidad= 30.0f;

    //texto gane
    public Text mensajeFinal;

    //Audio Source
    AudioSource fuenteDeAudio;

    //Clips de audio
    public AudioClip win, inicio;

    bool played;

    void Start(){
        mensajeFinal.text = "";
        //Recupero el componente audio source;
        fuenteDeAudio = GetComponent<AudioSource>();
        fuenteDeAudio.clip = inicio;
        fuenteDeAudio.Play();
        played = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Capto el valor del eje vertical de la raqueta
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        //Modifico la velocidad de la raqueta
        GetComponent<Rigidbody2D>().velocity = new Vector2(h*velocidad , v * velocidad);
        
        if (!fuenteDeAudio.isPlaying && played==true)
        {
            //Reproduzco el sonido de la raqueta
            this.gameObject.SetActive (false);
            print("Ya termino");
        }

    }

    //Se ejecuta al colisionar
    void OnCollisionEnter2D(Collision2D micolision){
        
        if (micolision.gameObject.name == "Meta")
        {
            
            mensajeFinal.text = "HAS LLEGADO A LA META!\nHaz clic o pulsa P para jugar otra vez.";
            //fuenteDeAudio.Play();
            fuenteDeAudio.clip = win;
            fuenteDeAudio.enabled = true;
            fuenteDeAudio.Play();
            played = true;
        }

    }
}
