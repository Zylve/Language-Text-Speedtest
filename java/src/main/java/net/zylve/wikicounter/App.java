package net.zylve.wikicounter;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.HashMap;

public class App {
    public static HashMap<String, Integer> Words = new HashMap<String, Integer>();

    public static void main(String[] args) throws IOException {

        long Start = System.nanoTime();

        BufferedReader bf = new BufferedReader(new FileReader("words.txt"));

        String line = bf.readLine();

        while (line != null) {
            if (Words.containsKey(line)) {
                Words.replace(line, Words.get(line) + 1);
            } else {
                Words.put(line, 1);
            }
            line = bf.readLine();
        }

        bf.close();

        WordObject[] array = new WordObject[Words.size()];

        Object[] wArray = Words.keySet().toArray();
        Object[] cArray = Words.values().toArray();

        for(int i = 0; i < array.length; i++) {
            array[i] = new WordObject(wArray[i].toString(), Integer.parseInt(cArray[i].toString()));
        }

        long rTotal = System.nanoTime() - Start;

        System.out.println("[Java] Read file in " + rTotal / 1000000 + " Milliseconds");

        long sStart = System.nanoTime();

        MergeSort(array);

        long sSort = System.nanoTime() - sStart;
        System.out.println("[Java] Sorted list in " + sSort / 1000000 + " Milliseconds");

        FileWriter fWriter = new FileWriter("Java_Out.txt");
        for (WordObject w : array) {
            fWriter.write(w.Word + ": " + w.Count + "\n");
        }

        fWriter.close();

        long total = System.nanoTime() - Start;
        System.out.println("[Java] Finished in " + total / 1000000 + " Milliseconds");
    }

    private static void MergeSort(WordObject[] array) {
        int length = array.length;
        if(length <= 1) { return; }

        int middle = length / 2;
        WordObject[] lArray = new WordObject[middle];
        WordObject[] rArray = new WordObject[length - middle];

        int i = 0;
        int j = 0;

        for(; i < length; i++) {
            if(i < middle) {
                lArray[i] = array[i];
            } else {
                rArray[j] = array[i];
                j++;
            }
        }

        MergeSort(lArray);
        MergeSort(rArray);
        Merge(lArray, rArray, array);
    }

    public static void Merge(WordObject[] lArray, WordObject[] rArray, WordObject[] array) {
        int leftLength = array.length / 2;
        int rightLength = array.length - leftLength;
        
        int i = 0;
        int l = 0;
        int r = 0;

        while(l < leftLength && r < rightLength) {
            if(lArray[l].Count > rArray[r].Count) {
                array[i] = lArray[l];
                i++;
                l++;
            } else {
                array[i] = rArray[r];
                i++;
                r++;
            }
        }

        while(l < leftLength) {
            array[i] = lArray[l];
            i++;
            l++;
        }

        while(r < rightLength) {
            array[i] = rArray[r];
            i++;
            r++;
        }
    }
}