namespace DataStructuresAndAlgorithms.DS.LinkedList
{
    /// <summary>
    /// Singly Linked List: A singly linked list is a list which has a value(data) 
    /// and a reference to next node. In this, last node's next reference will be null.
    /// </summary>
    public class LinkedList
    {
        private Node Head;
        private Node Current;
        public int Count;

        public LinkedList()
        {
            Head = new Node();
            Current = Head;
        }
    }
}
