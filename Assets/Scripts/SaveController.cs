using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveController : MonoBehaviour{

    private static SaveController _instance;
    private string _SavedWinnerKey = "SavedWinner";
    
    public Color colorPlayer = Color.white, colorEnemy = Color.white;

    public string namePlayer, nameEnemy;

    // Propriedade estática para acessar a instancia
    public static SaveController Instance{

        get{

            if(_instance == null){
                
                // Procure a instancia na cena
                _instance = FindObjectOfType<SaveController>();

                // Se nao encontrar, crie uma nova instancia
                if(_instance == null){
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                }
            }

            return _instance;
        }
    }

    private void Awake(){

        // Garanta que apenas uma instancia do Singleton existe
        if(_instance != null && _instance != this){
            Destroy(this.gameObject);
            return;
        }

        // Mantenha o Singleton vivo entre as cenas
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer){
        // se for player se nao enemy
        return isPlayer ? namePlayer : nameEnemy;
    }

    public void Reset(){
        nameEnemy = "";
        namePlayer = "";
        colorEnemy = Color.white;
        colorPlayer = Color.white;
    }

    public void SaveWinner(string winner){
        PlayerPrefs.SetString(_SavedWinnerKey, winner);
    }

    public string GetLastWinner(){
        return PlayerPrefs.GetString(_SavedWinnerKey);
    }

    public void ClearSave(){
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // recarregar cena
    }

}