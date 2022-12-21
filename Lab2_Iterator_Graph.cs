using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class HelloWorld {
  static void Main() {
        var myTree = new Tree<char>
        {
            Data = 'F',
            LChild = new Tree<char>
            {
                Data = 'D',
                LChild = new Tree<char> { Data = 'B' },
                RChild = new Tree<char> { Data = 'E' }
            },
            RChild = new Tree<char> { 
                Data = 'J',
                LChild = new Tree<char> { Data = 'K' },
                RChild = new Tree<char> { Data = 'E' }
            }
        };
        
        
        Console.WriteLine("Breadth-first iterator");
        BreadthItearator<char> breadthItearator = new BreadthItearator<char>(myTree);
        while (breadthItearator.HasNext())
            {
                breadthItearator.MoveNext();
                Console.WriteLine(((Tree<char>)breadthItearator.Current).Data);
            }
        Console.WriteLine("Depth-first iterator");
        
        DepthItearator<char> depthItearator = new DepthItearator<char>(myTree);
        while (depthItearator.HasNext())
            {
                depthItearator.MoveNext();
                Console.WriteLine(((Tree<char>)depthItearator.Current).Data);
            }
        
  }
}
public class Tree<T>
{
    public T Data { get; set; }
    public Tree<T> LChild { get; set; }
    public Tree<T> RChild { get; set; }
    
    
}
public abstract class TreeEnumerator<T> : IEnumerator<Tree<T>>
    {
        protected Tree<T> _Tree = null;

        protected Tree<T> _Current = null;

        public TreeEnumerator(Tree<T> tree)
        {
            _Tree = tree;
        }

        public Tree<T> Current { 
            get 
            { 
                return _Current; 
                
            } 
        }

        object System.Collections.IEnumerator.Current
        {
            get { return _Current; }
        }

        public abstract bool MoveNext();
        public abstract bool HasNext();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            _Current = null;
        }

        public virtual TreeEnumerator<T> GetEnumerator()
        {
            return this;
        }
    }

public class BreadthItearator<T> : TreeEnumerator<T>
    {
        Queue<Tree<T>> q = new Queue<Tree<T>>();


        public BreadthItearator(Tree<T> tree) : base(tree) {
            q.Enqueue(tree);
        }

        public override bool MoveNext()
        {
            if (q.Count > 0)
            {
                _Current = q.Dequeue();

                if (_Current.LChild != null) q.Enqueue(_Current.LChild);
                if (_Current.RChild != null) q.Enqueue(_Current.RChild);
                
                return true;
            }
            return false;
        }
        
        public override bool HasNext()
        {
            if (q.Count > 0) return true;
            else return false;
        }
    }
public class DepthItearator<T> : TreeEnumerator<T>
    {
        
        Stack<Tree<T>> s = new Stack<Tree<T>>();

        public DepthItearator(Tree<T> tree) : base(tree) {
            s.Push(tree);
        }

        public override bool MoveNext()
        {
            if (s.Count > 0)
            {
                _Current = s.Pop();
                if (_Current.RChild != null) s.Push(_Current.RChild);
                if (_Current.LChild != null) s.Push(_Current.LChild);
                
                
                return true;
            }
            return false;
        }
        
        public override bool HasNext()
        {
            if (s.Count > 0) return true;
            else return false;
        }
    }