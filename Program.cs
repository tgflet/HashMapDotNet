using System;

namespace HashKey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hashing!");
            HashMap Store = new HashMap();
            /*
            easy collision test:
            Cat, f$, j"
             */
            
            string result = "";
                System.Console.WriteLine("What is your perogative?");
            while(result != "q" && result !="Q" ){
                System.Console.WriteLine("E - Enter Data | R - Retrieve Data | Q - Quit");
                result = Console.ReadLine();
                if(result == "E" || result == "e"){
                    System.Console.WriteLine("Enter Key:");
                    string key = Console.ReadLine();
                    System.Console.WriteLine("String:");
                    string content = Console.ReadLine();
                    Data newData = new Data(key, content);
                    System.Console.WriteLine(Store.store(newData));
                }else if(result == "r" || result == "R"){
                    System.Console.WriteLine("Enter Key:");
                    string key = Console.ReadLine();
                    System.Console.WriteLine(Store.retrieve(key));
                }
                else if(result == "q" || result== "Q"){
                    System.Console.WriteLine("Quitting Now");
                }
                else{
                    System.Console.WriteLine("Invalid Command");

                }
            }

            
        }
        
    }
}
