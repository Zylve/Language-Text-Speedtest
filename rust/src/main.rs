#![allow(non_snake_case)]

use std::collections::HashMap;
use std::fmt::write;
use std::{cmp::*};
use std::fs::File;
use std::io::{BufRead, BufReader, Write};
use std::time::SystemTime;

fn compareCount(a: &WordStruct, b: &WordStruct) -> Ordering {
    // Sort by length from short to long first.
    let count = b.Count.cmp(&a.Count);
    return count;
}

fn main() {
    let start = SystemTime::now();

    let mut Words: HashMap<_, i32> = HashMap::new();
    let file = File::open("words.txt").unwrap(); 
    let br = BufReader::new(file);
    for (_index, line) in br.lines().enumerate() {
        let line = line.unwrap();
        let words = line.split_whitespace();
        for word in words {
            *Words.entry(word.to_owned()).or_insert(0) += 1;
        }
    }
    let wVec: Vec<String> = Words.keys().cloned().collect::<Vec<String>>();
    let cVec: Vec<i32> = Words.values().cloned().collect::<Vec<i32>>();
    let mut wArray: Vec<WordStruct> = Vec::new();

    for i in 0..wVec.len() {
        wArray.push(WordStruct { Word: (wVec[i].clone()), Count: (cVec[i].clone()) })
    }
    
    match start.elapsed() {
        Ok(elapsed) => println!("Read file in {} milliseconds", elapsed.as_millis()),
        Err(e) => print!("Error: {e:?}"),
    }

    let sort = SystemTime::now();

    wArray.sort_unstable_by(compareCount);

    match sort.elapsed() {
        Ok(elapsed) => println!("Sorted file in {} milliseconds", elapsed.as_millis()),
        Err(e) => print!("Error: {e:?}"),
    }

    let mut out = File::create("Rust_Out.txt").unwrap();

    for i in 0..wArray.len() {
        write!(out, "{}", wArray[i].Word.clone());
        write!(out, ": ");
        write!(out, "{}\n", wArray[i].Count.to_string().clone());
    }

    match start.elapsed() {
        Ok(elapsed) => println!("Finished in {} milliseconds", elapsed.as_millis()),
        Err(e) => print!("Error: {e:?}"),
    }
    
}

struct WordStruct {
    Word: String,
    Count: i32,
}