
namespace _02.NamingIdentifiers
{
	class Hauptklasse
	{

		enum Gender { Male, Female };

		class Human
		{
		public Gender Gender { get; set; }
		public string PersonName { get; set; }
		public int Age { get; set; }
		}

		// i cant understand what is магическия_НомерНаЕДИНЧОВЕК a.k.a. HumanNumber 
		public void MakeHuman(int HumanNumber)
		{
			Human newHuman = new Human();
			newHuman.Age = HumanNumber;

			if (HumanNumber % 2 == 0)
			{
				newHuman.PersonName = "Батката";
				newHuman.Gender = Gender.Male;
			}
			else
			{
				newHuman.PersonName = "Мацето";
				newHuman.Gender = Gender.Female;
			}
		}
	}
}
