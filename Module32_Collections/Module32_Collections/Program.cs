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

var yieldExample = new YieldExample();
yieldExample.PrintGetEnumerator();
WriteEmptyLine();
yieldExample.PrintGetEnumerable();
WriteEmptyLine();

#endregion Пример с yield итератором

var kindsOfGenericCollections = new KindsOfGenericCollections();
kindsOfGenericCollections.LinkedList();

void WriteEmptyLine()
{
    Console.WriteLine();
}