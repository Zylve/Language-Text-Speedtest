#include <algorithm>
#include <chrono>
#include <fstream>
#include <functional>
#include <iostream>
#include <string>
#include <sstream>
#include <unordered_map>
#include <vector>

#include "wikicounter.hpp"

std::unordered_map<std::string, int> Words;

bool sortByCount(const WordObject &l, const WordObject &r) { return l.Count > r.Count; }

void ReadFile() {
    std::chrono::time_point rStart = std::chrono::high_resolution_clock::now();

    std::ifstream file("../words.txt");
    std::stringstream ss;
    std::string word;

    ss << file.rdbuf();

    while(ss >> word) {
        Words[word]++;
    }

    int size = Words.size();

    std::vector<WordObject> array(size);

    int i = 0;
    for(auto itr = Words.begin(); itr != Words.end(); ++itr) {
        array[i].Word = itr->first;
        array[i].Count = itr->second;
        i++;
    }

    std::chrono::time_point rEnd = std::chrono::high_resolution_clock::now();
    double rTime = std::chrono::duration_cast<std::chrono::nanoseconds>(rEnd - rStart).count();
    rTime *= 1e-9;
    std::cout << "Read file in " << rTime << "s\n";


    std::chrono::time_point sStart = std::chrono::high_resolution_clock::now();

    std::sort(array.begin(), array.end(), sortByCount);

    std::chrono::time_point sEnd = std::chrono::high_resolution_clock::now();
    double sTime = std::chrono::duration_cast<std::chrono::nanoseconds>(sEnd - sStart).count();
    sTime *= 1e-9;
    std::cout << "Sorted list in " << sTime << "s\n";


    std::ofstream ofile;

    file.open("../C++_Out.txt");
}

int main(void) {
    std::chrono::time_point wStart = std::chrono::high_resolution_clock::now();
    ReadFile();

    std::chrono::time_point wEnd = std::chrono::high_resolution_clock::now();
    double wTime = std::chrono::duration_cast<std::chrono::nanoseconds>(wEnd - wStart).count();
    wTime *= 1e-9;
    std::cout << "Finished list in " << wTime << "s\n";

    return 0;
}