using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public static QuizManager instance;

    [SerializeField]
    public QuestionData question;  

    [SerializeField] 
    private WordData[] answerWordArray;
    [SerializeField]
    private WordData[] optionsWordArray;

    private char[] charArray = new char[12];

    private int currentAnswerIndex = 0;

    private bool correctAnswer = true;

    private List<int> selectedWordIndex;

    public BonePlacement bonePlacement;


    private void Awake()
    {
        if(instance == null){
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
        selectedWordIndex = new List<int>();
    }
    
    private void Start() {
        SetQuestion();
    }

    public void SetQuestion(){

        currentAnswerIndex = 0;
        selectedWordIndex.Clear();

        ResetQuestion();

        for (int i = 0; i < question.answer.Length; i++)
        {
            charArray[i] = char.ToUpper(question.answer[i]);
        }

        for(int i = question.answer.Length;i<optionsWordArray.Length;i++){
            charArray[i] = (char)UnityEngine.Random.Range(65,91);
        }

        List<char> charList = new List<char>(charArray);
        charArray = ShuffleList.ShuffleListItems<char>(charList).ToArray();

        for (int i = 0; i < optionsWordArray.Length; i++)
        {
            optionsWordArray[i].SetChar(charArray[i]);
        }
    }

    public void SelectedOption(WordData wordData){

        if(currentAnswerIndex>= answerWordArray.Length){
            return;
        }

        selectedWordIndex.Add(wordData.transform.GetSiblingIndex());

        answerWordArray[currentAnswerIndex].SetChar(wordData.charValue);
        wordData.gameObject.SetActive(false);
        currentAnswerIndex++;

        if(currentAnswerIndex >= question.answer.Length){
            correctAnswer = true;
            int counter=0;

            for(int i = 0;i<question.answer.Length;i++){

                if(char.ToUpper(question.answer[i]) != char.ToUpper(answerWordArray[i].charValue)){
                    correctAnswer = false;
                    break;

                }
                counter++;
            }

            if(correctAnswer){
                Debug.Log("Correct Answer");
                bonePlacement.correctAnswer();
            }
            else {
                Debug.Log("Wrong Answer");
                bonePlacement.wrongAnswer((counter>=question.answer.Length/2));
            }
        }
    }

    private void ResetQuestion(){
        for (int i = 0; i < answerWordArray.Length; i++)
        {
            answerWordArray[i].gameObject.SetActive(true);
            answerWordArray[i].SetChar('_');
        }
        for(int i = question.answer.Length ; i<answerWordArray.Length;i++){
            answerWordArray[i].gameObject.SetActive(false);
        }
        for(int i = 0; i < optionsWordArray.Length; i++){
            optionsWordArray[i].gameObject.SetActive(true);
        }
    }

    public void ResetLastWord(){

        if(selectedWordIndex.Count>0){
            int index = selectedWordIndex[selectedWordIndex.Count-1];
            optionsWordArray[index].gameObject.SetActive(true);
            selectedWordIndex.RemoveAt(selectedWordIndex.Count-1);
            currentAnswerIndex--;
            answerWordArray[currentAnswerIndex].SetChar('_');
        }
    }
}

[System.Serializable] 
public class QuestionData{
    public Sprite questionImage;
    public string answer;
}
