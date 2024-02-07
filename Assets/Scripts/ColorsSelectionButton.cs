using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorsSelectonButton : MonoBehaviour{

    public SaveController _saveController;

    public Button uiBtn;
    public Image paddleReference;

    public bool isColorPlayer = false;

    public void OnButtonClick(){

        paddleReference.color = uiBtn.colors.normalColor; //colocando a cor do botão

        if(isColorPlayer){
            SaveController.Instance.colorPlayer = paddleReference.color;
        }else{
            SaveController.Instance.colorEnemy = paddleReference.color;
        }
    }
}