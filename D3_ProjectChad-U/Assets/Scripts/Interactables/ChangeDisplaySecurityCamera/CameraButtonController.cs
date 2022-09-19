using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButtonController : InteractableBase
{
    //Armazena o objeto responsável por mostrar a camera 
    [SerializeField] GameObject securityCamScreen;

    //Aramzena a lista de texturas que mostram a visão da camera
    [SerializeField] List<Texture> camTextureList = new List<Texture>();
    
    

    //renderiza a textura passada pela lista
    private Renderer cameraRenderer;
    //Contador para passar as diversas texturas de camera
    private int index;

    private bool isBeingPressed = false;



    protected override void Interact()
    {
        changeCamera();

        //Talvez adicionar animação depois  
        if (!isBeingPressed)
        {
            isBeingPressed = !isBeingPressed;
        } else
        {
        }

        
    }

    private void changeCamera(){
        index++;
        if(index >= camTextureList.Count){
           index = 0;
        }

        //Troca a imagem que está sendo renderizada pela próxima da lista
        cameraRenderer.material.mainTexture = camTextureList[index];
    }
    
    private void Awake()
    {
        //Aramazena o Renderer do objeto para ser trocado
        cameraRenderer = securityCamScreen.GetComponent<Renderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // inicia a tela de cameras com a primeira camera 
        cameraRenderer.material.mainTexture = camTextureList[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
