using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTeethGenerator : MonoBehaviour
{
    GameObject[] TeethArray = new GameObject[32];
    ChangeMaterial ChangeMatScript;
    public GameObject UpperTeeth;
    public GameObject LowerTeeth;
    public Material initialToothMaterial;
    public Material firstScriptMaterial;
    public Material secondScroptMaterial;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < 17; ++i)
        {
           string n = "teeth_" + i;
           TeethArray[i-1] = UpperTeeth.transform.Find(n).gameObject;
        }
        for (int i = 17; i < 33; ++i)
        {
            string n = "teeth_" + i;
            TeethArray[i-1] = LowerTeeth.transform.Find(n).gameObject;
        }
        var BadTeeth = GenerateNumbers();
        foreach(var tooth in BadTeeth)
        {
            TeethArray[tooth].GetComponent<Renderer>().material = initialToothMaterial;
            TeethArray[tooth].GetComponent<ChangeMaterial>().firstMaterial = firstScriptMaterial;
            TeethArray[tooth].GetComponent<ChangeMaterial>().secondMaterial = secondScroptMaterial;
        }
        foreach (var tooth in BadTeeth)
            Debug.Log(tooth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    List<int> GenerateNumbers()
    {
        List<int> listNumbers = new List<int>();
        int number = 0;
        for (int i = 0; i< 5; i++)
        {
            do
            {
                number = Random.Range(0, 31);
            }
            while (listNumbers.Contains(number));
            listNumbers.Add(number);
        }
        return listNumbers;
    }
}
