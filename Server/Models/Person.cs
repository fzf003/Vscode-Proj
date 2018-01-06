namespace Models
{
     public class Person
     {
         public string Name{get;set;}
         public int Age{get;set;}

         public string Address{get;set;}

         public Person()
         {
             this.Address="中国.嵩山.少林";
             this.Age=90;
             this.Name="达摩002393293";
         }
     }
}