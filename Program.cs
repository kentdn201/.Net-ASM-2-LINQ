namespace D1
{
    public static class Program {
        static List<Member> members = new List<Member>
        {
            new Member
            {
                FirstName = "Phuong",
                LastName = "Nguyen Nam",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 22),
                PhoneNumber = "",
                BirthPlace = "Phu Tho",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Nam",
                LastName = "Nguyen Thanh",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 1, 20),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Son",
                LastName = "Do Hong",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 6),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1996, 1, 26),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Hoang",
                LastName = "Phuong Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 2, 5),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 5, 30),
                PhoneNumber = "",
                BirthPlace = "Bac Giang",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 9, 18),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Member
            {
                FirstName = "Miss",
                LastName = "Nguyen Thanh",
                Gender = "Female",
                DateOfBirth = new DateTime(1996, 1, 20),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            }
        };
        static void Main(String[] args){
            // 1. Return all Male Members
            // var maleMembers = GetMaleMembers();
            // PrintData(maleMembers);

            // 2. Return oldest Members
            // var oldestMember = GetOldestMember();
            // PrintData(new List<Member> {oldestMember});

            // 3. Return full name of all members
            // var fullnames = GetFullNames();
            // for (int i = 0; i < fullnames.Count; i++)
            // {
            //     string? fullname = fullnames[i];
            //     Console.WriteLine($"{i+1} {fullname}");
            // }

            // 4. Split members by birth year
            // var results = SplitMembersByBirthYear(2000);
            // Console.WriteLine("---------------2000-----------");
            // PrintData(results.Item1);
            // Console.WriteLine("-------Greater than 2000------");
            // PrintData(results.Item2);
            // Console.WriteLine("-------Lower than 2000--------");
            // PrintData(results.Item3);

            // 5. Get First Member by birth place
            // var result = GetFirstMembersByBirthPlace("Ha noi");
            // if(result != null)
            //     PrintData(new List<Member> {result});
            // else 
            //     Console.WriteLine("No Result!!");
        }

        static void PrintData(List<Member> data)
        {
            var index = 0;
            foreach(var item in data)
            {
                ++index;
                Console.WriteLine($"{index}. {item.FirstName} {item.LastName} {item.DateOfBirth.ToString("dd/MM/yyyy")} [{item.Age}] {item.BirthPlace}.");
            }
        }

        static List<Member> GetMaleMembers()
        {
            // var results = members.Where(x => x.Gender == "Male").ToList();

            var results = (from member in members
                            where member.Gender == "Male"
                            select member).ToList();
            return results;
        }

        static Member GetOldestMember()
        {
            var maxAge = members.Max(m => m.TotalDays);
            return members.First(m => m.TotalDays == maxAge);
        }

        static List<string> GetFullNames()
        {
            return members.Select(m => m.FullName).ToList();
        }

        static Tuple<List<Member>, List<Member>, List<Member>> SplitMembersByBirthYear(int year)
        {
            var list1 = members.Where(m => m.DateOfBirth.Year == year).ToList();
            var list2 = members.Where(m => m.DateOfBirth.Year > year).ToList();
            var list3 = (from member in members
                        where member.DateOfBirth.Year < year
                        select member).ToList();

            return Tuple.Create(list1, list2, list3);
        }

        static Member? GetFirstMembersByBirthPlace(string place)
        {
            // var result = new List<Member>();
            // foreach(var member in members)
            // {
            //     if(member.BirthPlace.Equals(place, StringComparison.CurrentCultureIgnoreCase))
            //     {
            //         result.Add(member);
            //     }
            // }
            // return result;

            return members.FirstOrDefault(m => m.BirthPlace.Equals(place, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
