using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueDisplayObject : InteractableBase
{
    //Referencia a UI do dialogo
    [SerializeField] private TextMeshProUGUI textComponent;

    //aramazena as frases do dialogo
    [TextArea(5,10)] [SerializeField] private string sentence;

    //define a velocidade em que o texto é digitado na tela
    [SerializeField] private float textSpeed;

    //variavel para navegar
    private int index;

    private InputManager inputManager;

    //armazena o objeto de dialogo
    [SerializeField] private GameObject dialogBox;

    //armazena o objeto de dialogo
    [SerializeField] private float dialogueTime;

    private bool activeDialogue = false;

    protected override void Interact()
    {
        if (!activeDialogue)
        {
            
            StartDialogue();
        }    
    }

    
    public void StartDialogue()
    {
        activeDialogue = true;
       
        textComponent.text = string.Empty;
        dialogBox.SetActive(true);
        StartCoroutine(TypeLine());
       
        Invoke("endDialogue",dialogueTime);
        
        
    }

    public void endDialogue()
    {
        dialogBox.SetActive(false);
        activeDialogue = false;
    }


    IEnumerator TypeLine(){
        //digita cada caractere 1 por 1
        foreach (char c in sentence.ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        
    }



    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.Instance;
    }




}
