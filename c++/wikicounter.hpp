class WordObject {
public:
    std::string Word;
    int Count;

    WordObject(std::string word, int count) {
        this->Word = word;
        this->Count = count;
    }

    WordObject() { }
};