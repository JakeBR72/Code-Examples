JFLAGS = -g
JC = javac
.SUFFIXES: .java .class
.java.class:
	$(JC) $(JFLAGS) $*.java

CLASSES = \
	Core.java \
	Tokenizer.java \
	Parser.java \
	Interpreter.java \

default: classes

classes: $(CLASSES:.java=.class)
	$(info ***  usage: java Core <input file> <output file> ***)

clean:
	$(RM) *.class
	$(RM) ./Types/*.class
