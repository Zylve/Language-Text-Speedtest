import {readFileSync, promises as fsPromises, unlinkSync, writeFileSync} from 'fs';

var start = performance.now();

class WordObject {
    constructor(word, count) {
        this.Word = word;
        this.Count = count
    }
}

var Words = { };

const text = readFileSync("words.txt", 'utf-8');
const lines = text.split("\n");

lines.forEach(element => {
    if(element in Words) {
        Words[element]++;
    } else {
        Words[element] = 1
    }
});

var w = Object.keys(Words);
var c = Object.values(Words);

var array = [];

for(let i = 0; i < w.length; i++) {
    array[i] = new WordObject(w[i], c[i]);
}

var pEnd = performance.now()

console.log("[Javascript] Parsed file in " + (pEnd - start) + " milliseconds");

array.sort(function(a, b) { return parseInt(b.Count) - parseInt(a.Count); });

console.log("[Javascript] Sorted list in " + (performance.now() - pEnd) + " milliseconds");

var final = [ ]

for(var part in array) {
    final.push(part.Word + ": " + part.Count);
}

writeFileSync("Javascript_Out.txt", final.join("\r\n"), (err) => {
    if(err) throw err;
});

console.log("[Javascript] Finished in " + (performance.now() - start) + " milliseconds");