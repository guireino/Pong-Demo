using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public BallController ballController;
    // No script do GameManager
    public Transform playerPaddle, enemyPaddle;
    public TextMeshProUGUI txtPointsPlayer, txtPointsEnemy, txtEndGame;

    public GameObject screenEndGame;

    public int winPoints, playerScore = 0, enemyScore = 0;

    // Start is called before the first frame update
    void Start(){
        ResetGame();
    }

    public void ResetGame(){

        //Define as posições iniciais das raquetes.
        playerPaddle.position = new Vector3(-7f,0f,0f);
        enemyPaddle.position = new Vector3(7f,0f,0f);

        //Inserir dentro do ResetGame
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        txtPointsPlayer.text = playerScore.ToString();
        txtPointsEnemy.text = enemyScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer(){
        playerScore++;
        txtPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy(){
        enemyScore++;
        txtPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin(){

        //decidindo quem ganhou o jogo.
        if(enemyScore >= winPoints || playerScore >= winPoints){
            //ResetGame();
            EndGame();
        }
    }

    public void EndGame(){

        screenEndGame.SetActive(true);

        string winner = SaveController.Instance.GetName(playerScore > enemyScore);

        //dentro do método EndGame
        txtEndGame.text = "Vitoria " + SaveController.Instance.GetName(playerScore > enemyScore);
        SaveController.Instance.SaveWinner(winner);

        Invoke("LoadMenu", 2f);
    }

    private void LoadMenu(){
        SceneManager.LoadScene("Menu");
    }

}