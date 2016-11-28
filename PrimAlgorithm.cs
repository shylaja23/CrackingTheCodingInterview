/*
Prim's Algorithm
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Vertex
    {
        public int name = 0;
        public Vertex(int _name)
        {
            this.name = _name;
        }
        
    }
    public class Edge
    {
        public Vertex v1;
        public Vertex v2;
        public int wt = 0;
        public Edge(Vertex _v1,Vertex _v2,int _wt)
        {
            this.v1 = _v1;
            this.v2 = _v2;
            this.wt = _wt;
        }
    }
    public class Graph
    {
        public List<Vertex> vertices = new List<Vertex>();
        public List<Edge> edges = new List<Edge>();
        
        
        public void AddVertex(int i)
        {
            Vertex v = new Vertex(i);
            vertices.Add(v);
        }
        public void AddEdge(int v1, int v2, int i)
        {
            Edge e = new Edge(vertices[v1-1],vertices[v2-1],i);
            edges.Add(e);
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            Program p = new Program();
            
            p.PrimsAlgorithm(p.CreateGraph());
        }
        
        public Graph CreateGraph(){
            Graph g = new Graph();
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);
            g.AddVertex(4);
            g.AddVertex(5);
            g.AddEdge(1,5,3);
            g.AddEdge(1,3,2);
            g.AddEdge(1,4,7);
            g.AddEdge(5,3,1);
            g.AddEdge(5,2,5);
            g.AddEdge(3,2,4);
            g.AddEdge(2,4,9);
            return g;
        }
        
        public bool doesNotExistMST(Vertex v, List<Vertex> lst)
        {
            foreach(Vertex tmp in lst)
            {
                if(tmp.name == v.name)
                    return false;
            }
            return true;
        }
        
        public void PrimsAlgorithm(Graph g){
            List<Vertex> mst = new List<Vertex>();
            List<Edge> mste = new List<Edge>();
            
            List<Vertex> parent = new List<Vertex>();
            parent.Add(g.vertices[0]);
            mst.Add(g.vertices[0]);
            int len = parent.Count();
            while(true)
            {
                Edge min = null;
                Vertex vmst = null;
                for(int i = 0 ; i < len; i++)
                {
                    Vertex v = parent[i];
                    foreach(Edge e in g.edges){
                        if((e.v1.name == v.name && doesNotExistMST(e.v2,mst)) || (e.v2.name == v.name && doesNotExistMST(e.v1,mst))) 
                        {
                            if(min == null || e.wt < min.wt){
                                min = e;
                                Console.WriteLine("New Min = "+min.wt);
                                if(e.v1.name == v.name)
                                    vmst = e.v2;
                            
                                if(e.v2.name == v.name)
                                    vmst = e.v1; 
                            }
                        }
                    }
                    if(min == null && vmst == null)
                        parent.RemoveAt(i);
                }
                if(min != null && vmst != null){
                    mst.Add(vmst);
                    mste.Add(min);
                    parent.Add(vmst);
                    len = parent.Count();
                    Console.WriteLine("Added Vertex "+vmst.name+ " Edge " + min.wt);
                } 
                if(mst.Count == g.vertices.Count)
                    break;    
                //printVertices(mst);
            }
            //printEdges(mste);
            
        }
        public void printEdges(List<Edge> e)
        {
            
            foreach(Edge tmp in e)
                Console.WriteLine(tmp.v1.name+"--"+tmp.v2.name+": "+tmp.wt);
            Console.WriteLine();
            
        }
        public void printVertices(List<Vertex> v)
        {
            foreach(Vertex tmp in v)
                Console.Write(tmp.name+" ");
            Console.WriteLine();
        }
        
    }
    
}
