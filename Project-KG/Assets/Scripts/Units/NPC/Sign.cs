using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public float resetDialogue ;
    private float timer;
    public GameObject KeyToTalk;
    public GameObject dialogBox;
    public Text dialogText;
    public Text dialogName;
    public string Dname;
    public bool characterInRange;
    public int countDialogs;
    public string[] dialog;
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!characterInRange)
        {
            timer += Time.deltaTime;

            if (timer >= resetDialogue)
            {
                i = 0;
            }
            
        }

        if (/*Input.GetKeyDown(KeyCode.E) && */characterInRange)
        {
            if(timer<resetDialogue)
            {
                timer = 0;
            }
            if (dialogBox.activeInHierarchy && Input.GetKeyDown(KeyCode.Q))
            {
                dialogBox.SetActive(false);
                if (i < countDialogs)
                    i = 0;
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                dialogBox.SetActive(true);
                dialogName.text = Dname;
                dialogText.text = dialog[i];
                if(i < countDialogs-1)
                {
                    i++;
                }
             
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            characterInRange = true;

            KeyToTalk.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Character"))
        {
            characterInRange = false;
            dialogBox.SetActive(false);
            KeyToTalk.SetActive(false);
        }
    }

}
