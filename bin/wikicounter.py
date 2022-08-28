import time

class WordObject:
    def __init__(self, word, count):
        self.Word = word
        self.Count = count

def sortFunc(a):
    return(a.Count)

Words = { }

f = open("words.txt")
for line in f.readlines():
    line = line[:-1]
    if(line in Words):
        Words[line] = Words[line] + 1
    else:
        Words[line] = 1
f.close()

x = list(Words.items())

array = [ ]

for i in range(Words.__len__()):
    array.append(WordObject(x[i][0], x[i][1]))

pTime = time.process_time_ns()

print("[Python] Parsed file in " + str(pTime / 1000000) + " milliseconds")

array.sort(reverse=True, key=sortFunc)

print("[Python] Sorted list in " + str((time.process_time_ns() - pTime) / 1000000) + " milliseconds")

f = open("Python_Out.txt", "w")
for i in range(array.__len__()):
    f.write(array[i].Word + ": " + str(array[i].Count) + "\n")

print("[Python] Finished in " + str((time.process_time_ns()) / 1000000) + " milliseconds")