using System;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Collections;
using System.Linq;





namespace QA_Automation_Assessment
{
    [Binding]
    public class PrintDocument /*:IComparable<PrintDocument>*/
    {
        public int Priority { get; set; }
        public string Name { get; set; }
        [Given(@"I solve the coding challenge")]
        public void GivenISolveTheCodingChallenge()
        {

            PrintDocument document1 = new PrintDocument();
            {
                Priority = 2;
                Name = "docA";

            }
            PrintDocument document2 = new PrintDocument();
            {
                Priority = 1;
                Name = "docB";
            }
            PrintDocument document3 = new PrintDocument();
            {
                Priority = 3;
                Name = "docC";
            }
            PrintDocument documnet4 = new PrintDocument();
            {
                Priority = 5;
                Name = "docE";
            }

            PrintDocument document5 = new PrintDocument();
            {
                Priority = 5;
                Name = "docF";
            }

           

            List<PrintDocument> d1 = new List<PrintDocument>();
            List<PrintDocument> d2 = new List<PrintDocument>();

            
            d1.Add(document2);
            d1.Add(documnet4);
            d1.Add(document3);
            d2.Add(document1);
            d2.Add(document5);
            
          

            Console.Write(Merge(d1, d2));
        }

        




         List<PrintDocument> Merge(List<PrintDocument> d1, List<PrintDocument> d2)
        {
            if (d1.Count == 0)
            {
                return d2;
            }
            if (d2.Count == 0)
            {
                return d1;
            }
            List<PrintDocument> SortedList = d1.Concat(d2).ToList();
            

            foreach(var item in SortedList)
            {
                return (List<PrintDocument>)SortedList.OrderBy(s => s.Name).ThenBy(s => s.Priority).ToList();
            }
            return SortedList;




        }
        //List<PrintDocument> ParseList(List<PrintDocument> d1)
        //{
        //    foreach (var doc in d1)
        //    {
        //        StringSplitOptions
        //    }
        //}

    }
}

    




    


  
