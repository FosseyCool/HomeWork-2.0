using System;

namespace HomeWork_Двусвязный_список
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

        public class LinkedList : ILinkedList
        {
            private Node _head;
            private Node _tail;
            private int _count;

            public void AddNode(int value)
            {
                Node newNode = new Node { Value = value };
                if (_head==null)
                {
                    _head = newNode;
                }
                else
                {
                    _tail.NextNode = newNode;
                    newNode.PrevNode = _tail;
                }
                _tail = newNode;
                _count++;
            }

            public void AddNodeAfter(Node node, int value)// добавляет новый элемент списка после определённого элемента
            {
                Node newNode = new Node { Value = value, PrevNode = node, NextNode = node.NextNode };
                node.NextNode = newNode;
                _count++;
            }

            public Node FindNode(int searchValue)//ищет элемент по его значению
            {
                Node current = _head;
                while (current!=null)
                {
                    if (current.Value.Equals(searchValue))
                         current = current.NextNode;
                }
                return current;
            }

            public int GetCount()
            {
                return _count;
            }

            public void RemoveNode(int index)// удаляет элемент по порядковому номеру
            {
                Node current = _head;
                for (int i = 0; i < index; i++)
                {
                    current = current.NextNode; 
                }

                if (current==null)
                {
                    return;
                }
                if (current.NextNode!=null)
                {
                    current.NextNode.PrevNode = current.PrevNode;
                }
                else
                {
                    _tail = current.PrevNode;
                }
                if (current.PrevNode!=null)
                {
                    current.PrevNode.NextNode = current.NextNode;
                }
                else
                {
                    _head = current.NextNode;
                }
                _count--;
            }

            public void RemoveNode(Node node)// удаляет указанный элемент
            {
                Node current = _head;
                while (current!=null)
                {
                    if (current.Value.Equals(node))
                    {
                        break;
                    }
                    current = current.NextNode;
                }
                if (current != null)
                {
                    if (current.NextNode!=null)
                    {
                        current.NextNode.PrevNode = current.PrevNode;
                    }
                    else
                    {
                        _tail = current.PrevNode;
                    }

                    if (current.PrevNode!=null)
                    {
                        current.PrevNode.NextNode = current.NextNode;
                    }
                    else
                    {
                        _head = current.NextNode;
                    }
                    _count--;
                }
                
            }
        }

    }
}
