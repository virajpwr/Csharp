using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPEXAM
{
    public enum Gender
    {
        Male,
        Female,
        Unspecified
    }

    public enum CivilState
    {
        Married,
        Single,
        Divorced,
        Widowed,
        Complicated
    }

    class Person
    {
        private Person _father;
        public Person Father { get {
                return _father;
            }
             }

        private Person _mother;
        public Person Mother { get
            {
                return _mother;
            }

        }

        private List<Person> _brothersAndSisters;
        public List<Person> BrothersAndSisters { get { return _brothersAndSisters; } }

        private List<Person> _sonsAndDaughters;
        public List<Person> SonsAndDaughters { get { return _sonsAndDaughters; } }

        private Gender _gender;
        public Gender Gender { get { return _gender; }
            set { } }

        private String _firstName;
        public String FirstName { get { return _firstName; } set { _firstName = value; } }

        private String _lastName;
        public String  LastName { get { return _lastName; } set { _lastName = value; } }

        private int _age;
        public int Age { get { return _age; } set { _age = value; } }

        private CivilState _civilState;
        public CivilState CivilState { get { return _civilState; } set { _civilState = value; } }

        public Person(String firstName, String lastName, int age, Gender gender, CivilState civilState, Person father, Person mother, List<Person> brothersAndSisters, List<Person> sonsAndDaughters) 
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _brothersAndSisters = brothersAndSisters;
            _sonsAndDaughters = sonsAndDaughters;
            _father = father;
            _mother = mother;
            _civilState = civilState;
            _gender = gender;
        }

        public Person(String firstName, String lastName, Gender gender)
        {
            _firstName = firstName;
            _lastName = lastName;
            _gender = gender;
        }

        public Person(String firstName, String lastName, int age, Gender gender, CivilState civilState, String fatherName, String motherName)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _father = new Person(fatherName.Split(' ')[0], fatherName.Split(' ')[1], Gender.Male);
            _mother = new Person(motherName.Split(' ')[0], motherName.Split(' ')[1], Gender.Female);
            _gender = gender;
            _civilState = civilState;
        }

        public Boolean Equals(Person person)
        {
            return _firstName == person._firstName && _lastName == person._lastName && _age == person._age && _father.Equals(person.Father) && _mother.Equals(person.Mother);
        }


        public String ToString()
        {
            return "First Name: "+_firstName+", Last Name: "+_lastName+", Age: "+_age+", Gender: "+_gender+", Civil State: "+_civilState;
        }
    }
}