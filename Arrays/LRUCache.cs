using System;
using System.Collections.Generic;

class DLL{
        internal int val {get; set;}
        internal DLL next {get; set;}
        internal DLL prev {get; set;}

        internal DLL _head;
        internal DLL _tail;

        public DLL(){
            _head = null;
            _tail = null;
        }

        internal void ReinsertEntry(DLL entry)
        {
            this.Delete(entry);
            this.Insert(entry.val);
        }

        internal void Insert(int entry){
            if(_head == null){
                _head = new DLL();
                _head.val = entry;
                _head.next = null;
                _head.prev = null;
                _tail = _head;
            } else {
                // Head is not null, but insertion happens at the head
                var temp = new DLL();
                temp.val = entry;
                temp.next = _head;
                temp.prev = null;
                _head = temp;
            }
        }

        internal void Delete(DLL node){            
            var temp = node.prev;

            temp.next = node.next;
            node.next.prev = temp;

            node = null;
        }
    }

class LRUCache
{
    

    DLL _dl;
    Dictionary<int, DLL> _dict;
    int _capacity;

    public LRUCache(int cap){
        _dl = new DLL();
        _dict = new Dictionary<int, DLL>();
        _capacity = cap;

    }

    int Get(int key){
        if(!_dict.ContainsKey(key))
            return -1;

        var entry = _dict[key];

        _dl.ReinsertEntry(entry);
        return entry.val;
    }

    void Put(int key, int val){
        // When the cache is not at full capacity
        if(_dict.Keys.Count < _capacity){

        } else {
            // If the cache is full, we need to evict LRU and then put the incoming 
            Evict();
            Put(key, val);
        }
    }

    void Evict(){

    }.    
}