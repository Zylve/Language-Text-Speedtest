# Language Text Speedtest
This is a test to see which language can read a file, count word occurences, and write the output to a file in the shortest amount of time.

[My Results](My_Results.txt)

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
    - Dotnet CLI or mono
    - Your favourite C/C++ compiler
    - JDK 17
    - KotlinC
    - Cargo

#### Compiling C#
```
$ cd c#
$ dotnet build wikicounter_cs.csproj /property:GenerateFullPaths=true
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