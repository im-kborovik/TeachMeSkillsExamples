using Module32_Collections;

#region Пример IEnumerable и IEnumerator

var enumerablePrinter = new EnumerablePrinter();
enumerablePrinter.PrintWithIEnumerable();
WriteEmptyLine();

enumerablePrinter.PrintWithoutIEnumerable();
WriteEmptyLine();

#endregion Пример IEnumerable и IEnumerator

#region Пример для System.Collections

var kindsOfCollections = new KindsOfCollections();

kindsOfCollections.Hashtable();
WriteEmptyLine();

kindsOfCollections.SortedList();
WriteEmptyLine();

kindsOfCollections.ArrayList();
WriteEmptyLine();

kindsOfCollections.Queue();
WriteEmptyLine();

kindsOfCollections.Stack();

#endregion Пример для System.Collections

#region Пример с yield итератором

var yieldExampleWithoutIEnumerable = new YieldExample();
yieldExampleWithoutIEnumerable.Print();
WriteEmptyLine();

var yieldExampleWithIEnumerable = new YieldExample();
yieldExampleWithIEnumerable.Print();
WriteEmptyLine();

var yieldExampleWithBreak = new YieldExampleWithBreak();
yieldExampleWithBreak.Print();
WriteEmptyLine();

#endregion Пример с yield итератором

void WriteEmptyLine()
{
    Console.WriteLine();
}