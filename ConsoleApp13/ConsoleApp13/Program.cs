using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    interface IPeople
    {
        int Id { get; }
        string FirstName { get; }
        string LastName { get; }
        int Age { get; }
    }

    class InfoPeople : IPeople
    {
        public static int Number = 0;
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public int Age { get; }

        public InfoPeople(string firstName, string lastName,int age)
        {
            Number++;
            Id = Number;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public void PrintPeople()
        {
            Console.Write(Id+" "+FirstName+" "+LastName+" "+Age+" ");
        }
    }
    
    interface ISport
    {
        string NameSport { get; }
        int YearsDoing { get; }
    }

    class Sport : ISport
    {
        public string NameSport{ get;}
        public int YearsDoing { get; }
        
        public Sport(string nameSport,int yersDoing)
        {
            NameSport = nameSport;
            YearsDoing = yersDoing;
        }

        public void PrintSpotr()
        {
            Console.Write(NameSport + " " + YearsDoing + " ");
        }
    }

    interface ISpecialist
    {
        string SelectedSports { get; }
        string Discharge { get; }
    }

    class Specialist : ISpecialist
    {
        public string SelectedSports {get;}
        public string Discharge { get; }

        public Specialist (string selectedSports, string discharge)
        {
            SelectedSports = selectedSports;
            Discharge = discharge;
        }

        public void PrintSpecialist()
        {
            Console.Write(SelectedSports + " " + Discharge + " ");
        }
    }

    class People: IComparable<People>
    {
        public InfoPeople infoPeople { get; set; }
        public Sport sport { get; set; }
        public Specialist specialist { get; set; }

        public void Print()
        {
            infoPeople.PrintPeople();
            sport.PrintSpotr();
            specialist.PrintSpecialist();
        }

        public int CompareTo(People people)
        {
            return this.infoPeople.Age.CompareTo(people.infoPeople.Age);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            People[] peoples = new People[3];

            peoples[0] = new People();
            peoples[1] = new People();
            peoples[2] = new People();

            peoples[0].infoPeople = new InfoPeople("Ермаков","Артем",20);
            peoples[0].sport = new Sport("Дзюдо", 4);
            peoples[0].specialist = new Specialist("Борьба", "Желтый пояс");
            
            peoples[1].infoPeople = new InfoPeople("Мяделец", "Валентин", 21);
            peoples[1].sport = new Sport("Метание молота", 9);
            peoples[1].specialist = new Specialist("Легкая отлетика", "КМС");

            peoples[2].infoPeople = new InfoPeople("Тиханов", "Михаил", 19);
            peoples[2].sport = new Sport("Волейбол", 2);
            peoples[2].specialist = new Specialist("Игровые", "Любитель");

            foreach (People i in peoples)
            {
                i.Print();
                Console.WriteLine();
            }

            Console.WriteLine(peoples[0].CompareTo(peoples[1]));
            Console.WriteLine(peoples[1].CompareTo(peoples[2]));
            Console.ReadKey();
        }
    }
}
