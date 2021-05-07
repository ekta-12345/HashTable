﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    public class MyMapNode<K, V>//built key value pair hashtable
    {
        //define a member elements of this class
        private readonly int size;//size of hashtable
        private readonly LinkedList<keyValue<K, V>>[] items;

        /// <summary>
        /// Defining a constructor
        /// </summary>
        /// <param name="size">size of hashtable is passed in it</param>
        public MyMapNode(int size)
        {
            this.size = size;
            //array of linkedlist size is defined
            this.items = new LinkedList<keyValue<K, V>>[size];
        }


        protected int GetArrayPosition(K key) //GetArrayPosition is method and passing key as parameter
        {
            int position = key.GetHashCode() % size;//GetHashCode is predifine method,to identify the hashcode of this particular key
            return Math.Abs(position);//Math.abs function To identify integer value and At what index this purticular keyvalue is present.
        }



        public V Get(K key)//generic method
        {

            int position = GetArrayPosition(key);//call method

            //linkedlist is accessed after getting the position from the array
            //getlinkedlist method is called with position of linkedlist in array

            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);//identifying the position calling the getLinkedlist()
           
            
            foreach (keyValue<K, V> item in linkedList)//foreach loop is used to access the key and values from linkedlist
            {
                
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        protected LinkedList<keyValue<K, V>> GetLinkedList(int position)//method and GetLinkedList having return type is Linkedlist keyvalue pair which is define line no13
        {
            
            LinkedList<keyValue<K, V>> linkedList = items[position];

            if (linkedList == null)
            {
                linkedList = new LinkedList<keyValue<K, V>>();
                //adding a linkedlist in the given array position
                items[position] = linkedList;
            }
            //returning linked list.
            return linkedList;
        }



        public void Add(K key, V value)//used add method and passes 2 parameter pushing the data into hashtable using linkedlist opraton
        {

            int position = GetArrayPosition(key);

            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            //for adding value in linkedlist. Struct object is defined, like a class and key and value obtained as a parameter
            //to this method are passed as parameter to object
            //keyValue struct is instatiated and stores the key and value, which is passed as one object to linkedlist.
            keyValue<K, V> item = new keyValue<K, V>() { Key = key, Value = value };
            //keyvalue is added in the linkedlist.
            linkedList.AddLast(item);
        }



        public void Remove(K key)//rempving particular entery  from hashtable
        {
            //getting the  position of linkedlist in which key value pair is stored and is to be removed
            int position = GetArrayPosition(key);
            //calling the dictionary from which element is to be removed.
            LinkedList<keyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;
            //if key of item matches from iteration done in particular linked list, key value pairs are assigned to foundItem variable.
            keyValue<K, V> foundItem = default(keyValue<K, V>);
            //iterating loop in linkedlist to find out the key
            foreach (keyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            //if item is found, it is removed
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        public void Display()
        {

            foreach (var linkedList in items)
            {

                if (linkedList != null)
                    foreach (keyValue<K, V> keyvalue in linkedList)
                    {

                        Console.WriteLine(keyvalue.Key + "\t" + keyvalue.Value);
                    }
            }
        }

    }

    /// <summary>
    /// Defining a struct data type to store key and value
    /// struct is similar to class and used to hold values
    /// </summary>

    public struct keyValue<k, v>
    {

        public k Key { get; set; }
        public v Value { get; set; }

    }
}