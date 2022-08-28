#!/bin/bash

FILEOUT=*_Out.txt
if test -f "$FILEOUT"; then
    echo "Deleting old outputs"
    rm -r *_Out.txt
else
    echo "No outputs from previous tests"
fi

FILE=words.txt
if test -f "$FILE"; then
    echo "words.txt has already been downloaded"
else
    echo "Downloading words.txt"
    wget https://download1519.mediafire.com/uj1ycuum8vbg/4f3obhuay55cb2g/words.txt
fi

echo
echo "Testing C#"
echo
time ./bin/wikicounter_cs

echo
echo "Testing C++"
echo
time ./bin/wikicounter_cpp

echo
echo "Testing Java"
echo
time taskset -c 0 java -jar ./bin/wikicounter.jar

echo
echo "Testing Javascript"
echo
time node ./bin/wikicounter.js

echo
echo "Testing Kotlin"
echo
time taskset -c 0 java -jar ./bin/wikicounter_kotlin.jar

echo
echo "Testing Python"
echo
time python3 ./bin/wikicounter.py

echo
echo "Testing Rust"
echo
time ./bin/wikicounter_rust