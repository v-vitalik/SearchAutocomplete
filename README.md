# SearchAutocomplete

## Overview

The SearchAutocomplete App is a console application that implements a Trie-based autocomplete system. It processes a list of input strings to create a Trie structure for efficient searching and ranking, then provides top suggestions based on a given prefix. Also contains unit tests written using NUnit.


### Input File Format
The application reads its input from a file named input.txt:

- The first line contains the number of base strings (n).
- The second line contains the number of input strings (m).
- The next n lines contain the base strings for building the Trie.
- The following m lines contain the input strings for which autocomplete suggestions are needed.

Example `input.txt`
```
3
2
apple
banana
apricot
app
ban
```

