# Automaton Facilities

### Introduction

This project was made for the Formal Language Theory class lectured by the Dr. Vinicius Durelli in 2019/1 period of the Computing Science at the Federal University of São João del-Rei.

The main goal of the project was to build an application that should be able to, given an entry, tell if an (also given) automaton will accept or not the entry.

The (currently) supported automaton types are:

* Deterministic Finite Automaton
* Nondeterministic Finite Automaton
* Deterministic Pushdown Automaton

The entire application was developed in C# programming language using the Microsoft .NET Framework with the Microsoft Visual Studio Community Edition.

### External Dependencies

In order to provide a better visualization of the given automaton as a directed graph, it was used the `dot` executable from [Graphviz](https://www.graphviz.org/) by AT&T labs, which is currently under the Common Public License Version 1.0.

To generate the `dot` file, QuickGraph library was used.

Two icons from [iconfinder](https://www.iconfinder.com/) were used:

* Bender (Glorious Golden) by [PixelPirate](https://www.deviantart.com/pixelpirate)
* Setting by [Artua](https://www.artua.com/)

### Entry File Syntax

The description of the automaton is made through a text file, which have an specific syntax that should be strictly followed so the application can recognize exactly what you are trying to represent.

The entry file syntax is described as the following:

```
AUT_TPYE [LIST_OF_VALID_CHARS] STATE_NAME<STATE_ATTRIBUTE> 
STATE_SRC STATE_DST [LIST_OF_CHARS]
```

Where:


Label | Meaning  
------------ | -------------
AUT_TYPE | The type of the automaton you are describing, it can be AFD (Deterministic Finite Automaton), AFN (Nondeterministic Finite Automaton) or AFDP (Deterministic Pushdown Automaton).
LIST_OF_VALID_CHARS | List of valid chars separated by commas used in the transitions from a state to another.
STATE_NAME | Names of the states. In this section all the states of your automaton should be named.
STATE_ATTRIBUTE | This is an optional label. It should be used when a state is the initial one or a final one. An initial state is marked with a `+` char and must be only one. A final state is marked with a `*` char.
STATE_SRC | The source state of a transition. The state name written in this section must have been previously declared in STATE_NAME section. 
STATE_DST | The destiny state of a transition. The state name written in this section must have been previously declared in STATE_NAME section.
LIST_OF_CHARS | List of chars that makes a transition from STATE_SRC to STATE_DST. The chars described here must have been previously declared in LIST_OF_VALID_CHARS.

If the automaton is a pushdown automaton type, the following labels have their meaning changed:

Label | Meaning
------------ | -------------
LIST_OF_VALID_CHARS | A `?` char can be included, representing the consulting transition. 
LIST_OF_CHARS | Each "char" will become an 3-tuple (with elements separated by semi-colons) where the first element is the char that will cause transition, the second one is what should be popped from the stack in the moment of that transition, and the third and last one is what should be pushed onto the stack in the moment of that transition.

Example of a valid DFA entry file:

```
AFD [a,b,c] q0+* q1* q2 q3 q4 qf
q0 q2 [a,b,c]
q2 q1 [a,b]
q1 q1 [c]
q1 q1 [b]
```

Example of a valid DPA entry file:

```
AFDP [a,b,?] q0+ q1 q2 qf*
q0 q0 [(a;$;A)]
q0 q1 [(b;$;A)]
q1 q1 [(b;$;A)]
q1 q2 [(a;A;$)]
q2 q2 [(a;A;$)]
q0 qf [(?;?;$)]
q2 qf [(?;?;$)]
```

### Compiling & Running
To compile this project, Microsoft Visual Studio and Microsoft .NET Framework will be needed.

To run the application, you can run the executable file generated in the Debug folder after the compiling, or compile it as a release.

### Todo List
This project is currently not finished, and a lot of optimizations and new implementations will be made in the future.

- [x] Entry file validation
- [x] DFA implementation
- [x] NFA implementation
- [x] DPA implementation
- [ ] NPA implementation
- [x] Automaton visualization as a directed graph
- [ ] Entry file validation with regular expressions
- [ ] Re-implementation of the core automaton architecture
- [ ] Multilanguage application
- [ ] Implementation of a built-in dot file engine for better supplying of the `dot` Graphviz engine.

### Screenshots

![Automaton Facilities Main Form](https://github.com/theskytalos/automaton-facilities/blob/master/automaton-facilities-prtsc.JPG)

![Automaton Facilities Settings Form](https://github.com/theskytalos/automaton-facilities/blob/master/automaton-facilities-settings-prtsc.jpg)
