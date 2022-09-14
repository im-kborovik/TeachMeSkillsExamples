namespace Module32_Collections;

public class KindsOfGenericCollections
{
    public KindsOfGenericCollections()
    {
        var list = new List<int>();
        var dictionary = new Dictionary<int, int>();
        var hashSet = new HashSet<int>();
        var queue = new Queue<int>();
        var stack = new Stack<int>();
        var linkedList = new LinkedList<int>();
    }

    public void LinkedList()
    {
        var linkedList = new LinkedList<int>(new[] { 2, 3, 1 });

        var currentNode = linkedList.First;
        var next = currentNode.Next;

        Console.WriteLine(nameof(LinkedList));
        
        foreach (var i in linkedList)
        {
            Console.WriteLine(linkedList.Find(i).Value);
        }
        // var prev = currentNode.Previous;
        // Console.WriteLine(prev.Value);
    }
}