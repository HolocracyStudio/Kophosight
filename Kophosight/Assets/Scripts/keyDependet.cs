using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Linq;

public class keyDependet : MonoBehaviour
{
    private string _key = "00";
    public static string key = "00";
    private string previousKey = "00";
    private List<GameObject> hands;
    public Dictionary<string, GameObject> table;
    public delegate void OnVariableChangeDelegate(string newKey);
    public event OnVariableChangeDelegate OnVariableChange;
    public static Stopwatch timer = new Stopwatch();

    // Use this for initialization
    void Start () {
        hands = new List<GameObject>();
        table = new Dictionary<string, GameObject>();
        AddAllHands();
        //hands.Sort();
        DisableAllHands();
        populateTable();
        OnVariableChange += VariableChangeHandler;
    }

    void populateTable()
    {
        table.Add("11", hands[0]);table.Add("12", hands[1]);table.Add("13", hands[2]);table.Add("14", hands[3]);table.Add("15", hands[4]);table.Add("16", hands[5]);table.Add("17", hands[6]);table.Add("18", hands[7]);
        table.Add("21", hands[8]);table.Add("22", hands[9]);table.Add("23", hands[10]);table.Add("24", hands[11]);table.Add("25", hands[12]);table.Add("26", hands[13]);table.Add("27", hands[14]);table.Add("28", hands[15]);
        table.Add("31", hands[16]);table.Add("32", hands[17]);table.Add("33", hands[18]);table.Add("34", hands[19]);table.Add("35", hands[20]);table.Add("36", hands[21]);table.Add("37", hands[22]);table.Add("38", hands[23]);
        table.Add("41", hands[24]);table.Add("42", hands[25]);table.Add("43", hands[26]);table.Add("44", hands[27]);table.Add("45", hands[28]);table.Add("46", hands[29]);table.Add("47", hands[30]);table.Add("48", hands[31]);
        table.Add("51", hands[32]);table.Add("52", hands[33]);table.Add("53", hands[34]);table.Add("54", hands[35]);table.Add("55", hands[36]);table.Add("56", hands[37]);table.Add("57", hands[38]);table.Add("58", hands[39]);
    }

    void DisableAllHands()
    {
        foreach (GameObject hand in hands)
        {
            hand.SetActive(false);
        }
    }

    void AddAllHands()
    {
        GameObject[] taggedHands = GameObject.FindGameObjectsWithTag("hand");
        foreach (GameObject hand in taggedHands)
            hands.Add(hand);
    }

    // Update is called once per frame
    void Update () {
        if (key != _key && OnVariableChange != null)
        {
            //timer.Restart();
            System.Diagnostics.Debug.WriteLine("Key display timer restarted");
            previousKey = _key;
            _key = key;
            OnVariableChange(_key);
        }
    }

    private void VariableChangeHandler(string newKey)
    {
        DisplayHand(newKey);
    }

    void DisplayHand(string newKey)
    {
        if (previousKey != "00")
        {
            table[previousKey].SetActive(false);
        }
        table[newKey].SetActive(true);
        System.Diagnostics.Debug.WriteLine("Key display speed = " + timer.ElapsedMilliseconds + " ms");
    }
}
