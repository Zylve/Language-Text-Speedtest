using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;

public static class MainClass {
    public static Dictionary<string, int> Words = new Dictionary<string, int>();
    public static void Main(string[] args) {
        Stopwatch total = new Stopwatch();
        Stopwatch createList = new Stopwatch();
        Stopwatch sortList = new Stopwatch();

        total.Start();
        createList.Start();

        foreach(string word in File.ReadLines("words.txt")) {
            if(Words.ContainsKey(word)) {
                Words[word]++;
            } else {
                Words.Add(word, 1);
            }
        }

        WordObject[] array = new WordObject[Words.Count];

        string[] wordArray = Words.Keys.ToArray();
        int[] countArray = Words.Values.ToArray();

        for(int i = 0; i < array.Length; i++) {
            array[i] = new WordObject(wordArray[i], countArray[i]);
        }

        createList.Stop();

        TimeSpan cts = createList.Elapsed;

        string cTime = String.Format("[C#] {0:00}:{1:00}:{2:00}.{3:000}", cts.Hours, cts.Minutes, cts.Seconds, cts.Milliseconds);

        Console.WriteLine($"Read file in {cTime}");

        sortList.Start();

        MergeClass.MergeSort(array);

        sortList.Stop();

        TimeSpan sts = sortList.Elapsed;

        string sTime = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", sts.Hours, sts.Minutes, sts.Seconds, sts.Milliseconds);

        Console.WriteLine($"[C#] Sorted words in {sTime}");

        using(FileStream fs = File.Create("C#_Out.txt")) {
            foreach(WordObject w in array) {
                byte[] info = new UTF8Encoding(true).GetBytes($"{w.Word}: {w.Count}\n");
                fs.Write(info);
            }
        }

        total.Stop();

        TimeSpan ts = total.Elapsed;

        string time = String.Format("{0:00}:{1:00}:{2:00}.{3:000}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);

        Console.WriteLine($"[C#] Finished in {time}");
    }
}

public static class MergeClass {
    public static void MergeSort(WordObject[] array) {
        int length = array.Length;
        if(length <= 1) { return; }

        int middle = length / 2;
        WordObject[] leftArray = new WordObject[middle];
        WordObject[] rightArray = new WordObject[length - middle];

        int i = 0;
        int j = 0;

        for(; i < length; i++) {
            if(i < middle) {
                leftArray[i] = array[i];
            } else {
                rightArray[j] = array[i];
                j++;
            }
        }

        MergeSort(leftArray);
        MergeSort(rightArray);
        Merge(leftArray, rightArray, array);
    }

    public static void Merge(WordObject[] leftArray, WordObject[] rightArray, WordObject[] array) {
        int leftLength = array.Length / 2;
        int rightLength = array.Length - leftLength;

        int i = 0;
        int l = 0;
        int r = 0;

        while(l < leftLength && r < rightLength) {
            if(leftArray[l].Count > rightArray[r].Count) {
                array[i] = leftArray[l];
                i++;
                l++;
            } else {
                array[i] = rightArray[r];
                i++;
                r++;
            }
        }

        while(l < leftLength) {
            array[i] = leftArray[l];
            i++;
            l++;
        }

        while(r < rightLength) {
            array[i] = rightArray[r];
            i++;
            r++;
        }
    }
}

public class WordObject {
    public string Word;
    public int Count { get; set; }

    public WordObject(string word, int count) {
        this.Word = word;
        this.Count = count;
    }
}