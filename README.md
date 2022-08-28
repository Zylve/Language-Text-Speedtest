# Language Text Speedtest
This is a test to see which language can read a file, count word occurences, and write the output to a file in the shortest amount of time.

[My Results](My_Results.txt)

[Running The Test](https://github.com/Zylve/Language-Text-Speedtest#running-the-test-for-individual-languages)

[Compiling](https://github.com/Zylve/Language-Text-Speedtest#compiling)

## Running The test

### Dependencies

Dependencies needed to run the tests:
- JRE 17
- Node.js (Preferably the latest version)
- Python (Preferably the latest version)

### Running the test for all languages
```
$ git clone https://github.com/Zylve/Language-Text-Speedtest
$ cd Language-Text-Speedtest
$ chmod +x ./test.sh
$ test.sh
```
#### OR
```
$ curl https://raw.githubusercontent.com/Zylve/Language-Text-Speedtest/main/test.sh | sh
```
The script will download the words.txt I used for these tests from mediafire
You can also make your own using this [Wikipedia downloader](https://github.com/Zylve/Language-Text-Speedtest#generating-your-own-wordstxt) I made.

The words.txt file has the following format with a new word on each line:
```
sample
text
text
foo
bar
bar
```

### Running the test for individual languages
#### C#
```
$ time ./bin/wikicounter_cs
```
#### C++
```
$ time ./bin/wikicounter_cpp
```
#### Java
```
$ time taskset -c 0 java -jar ./bin/wikicounter.jar # Force Java to run on one cpu for a fair comparison
```
#### Javascript
```
$ time node ./bin/wikicounter.js
```
#### Kotlin
```
$ time taskset -c 0 java -jar ./bin/wikicounter_kotlin.jar # Force Kotlin to run on one cpu for a fair comparison
```
#### Python
```
$ time python3 ./bin/wikicounter.py
```
#### Rust
```
$ time ./bin/wikicounter_rust
```

## Compiling

### Dependencies
Dependencies needed for compiling:
- Dotnet CLI
- Your favourite C/C++ compiler
- JDK 17
- KotlinC
- Cargo

#### Compiling C#
```
$ cd c#
$ dotnet build wikicounter_cs.csproj --configuration Release
```
#### Compiling C++
```
$ cd c++
$ g++ -g -O2 -std=c++20 wikicounter.cpp -o wikicounter_cpp
```
#### Compiling Java
idk man open it up in vscode with the java extensions and build it with maven
#### Compiling Kotlin
```
$ cd kotlin
$ kotlinc wikicounter.kt -include-runtime -d wikicounter_kotlin.jar
```
#### Compiling Rust
```
$ cd rust
$ cargo build -release
```

## Generating Your Own words.txt
You can generate your own words.txt using [this](downloader/downloader.cs) script I made that pulls random articles from Wikipedia and outputs a text file with all words found in the articles.
### Usage:
```
$ cd downloader
$ dotnet build
$ ./bin/release/net6.0/downloader <x>
```
Where x is the number of articles you wish to download
