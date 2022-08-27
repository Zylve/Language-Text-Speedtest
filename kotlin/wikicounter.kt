import java.io.File
import java.nio.file.Files
import java.nio.file.Paths
import java.nio.file.StandardOpenOption

fun main() {
    val start = System.nanoTime();
    var Words: HashMap<String, Int> = HashMap<String, Int>()
    val path = Paths.get("words.txt")
    Files.readAllLines(path).forEach {
        if (Words.containsKey(it)) {
            Words[it] = Words!!.get(it)!!.plus(1)
        } else {
            Words.put(it, 1)
        }
    }

    val s = Words.keys.toTypedArray()
    val c = Words.values.toIntArray()

    var array = ArrayList<WordObject>()

    for (i in 0..Words.size - 1) {
        array.add(WordObject(s[i], c[i]))
    }


    println("[Kotlin] Parsed file in " + (System.nanoTime() - start) / 1000000 + " Milliseconds")

    val sortStart = System.nanoTime();

    array.sortByDescending { it.Count }

    println("[Kotlin] Sorted list in " + (System.nanoTime() - sortStart) / 1000000 + " Milliseconds")

    val file = File("Kotlin_Out.txt")
    for (i in 0..array.size - 1) {
        val string = array[i].Word + ": " + array[i].Count + "\n";
        file.appendText(string);
    }

    println("[Kotlin] Finished in " + (System.nanoTime() - start) / 1000000 + " Milliseconds")
}

class WordObject(val Word: String, var Count: Int) {}
