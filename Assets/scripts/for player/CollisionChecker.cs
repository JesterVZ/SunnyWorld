using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionChecker : MonoBehaviour
{
    movement m;
    checker check;
    DialogueSystem dialogue;
    public Text fireballCount, manaCount;

    void Start()
    {
        m = FindObjectOfType<movement>();
        check = FindObjectOfType<checker>();
        dialogue = FindObjectOfType<DialogueSystem>();
    }

    void Update()
    {
        fireballCount.text = m.fireball_count.ToString();
    }
    const string c = "(Clone)";
    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name)
        {
            case "cherry" + c:
                Destroy(col.gameObject);
                break;
            case "dimond" + c:
                Destroy(col.gameObject);
                break;
            case "mushroom" + c:
                Destroy(col.gameObject);
                break;
            case "skull" + c:
                Destroy(col.gameObject);
                break;
            case "fireball_item" + c:
                Destroy(col.gameObject);
                m.fireball_count += Random.Range(1, 8);
               // fireballCount.text = m.fireball_count.ToString();
                break;
          
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        check = FindObjectOfType<checker>();
        switch (col.gameObject.name)
        {
            case "Eagle Active": // объект, походу, удаляется. пока хз че делать
                check.active = true;
                break;
            case "mana" + c:
                m.mana_count++;
                Destroy(col.gameObject);
                break;
            case "message_1":
                dialogue.Typing(0);
                Destroy(col.gameObject);
                break;
            case "message_2":
                dialogue.Typing(1);
                Destroy(col.gameObject);
                break;
            case "message_3":
                dialogue.Typing(2);
                Destroy(col.gameObject);
                break;
            case "message_4":
                dialogue.Typing(3);
                Destroy(col.gameObject);
                break;
            case "message_5":

                Destroy(col.gameObject);
                break;
        }
    }
}