using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPEXAM
{
    class DataManagement
    {
        private SqlCommand sqlCommand;
        private SqlConnection sqlConnection;


        public DataManagement()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = @"Data Source=DESKTOP-IHRPHCI\SQLEXPRESS;Initial Catalog=LocalPersonalDB;Integrated Security=True";

            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
        }

        public Boolean AddPerson(Person person)
        {
            String query = "insert into citizens values('"+person.FirstName+"', '"+person.LastName+"', "+person.Age+", '"+person.CivilState+"', '"+person.Gender+"', '"+(String.IsNullOrEmpty(person.Father.FirstName)? "": person.Father.FirstName) + " "+ (String.IsNullOrEmpty(person.Father.LastName)? "": person.Father.LastName) +"', '"+(String.IsNullOrEmpty(person.Mother.FirstName)?"": person.Mother.FirstName) +" "+(String.IsNullOrEmpty(person.Mother.LastName)?"": person.Mother.LastName) +"')";
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = query;
            sqlCommand.Connection.Open();
            Boolean x = sqlCommand.ExecuteNonQuery()!=0;
            sqlCommand.Connection.Close();
            return x;
        }

        public String fillDataBase()
        {            
            for(int i=0; i < 1000; i++)
            {
                Person p = new Person(randomFirstName(), randomLastName(), randomAge(), randomGender(), randomCivilState(), randomFirstName()+" "+randomLastName(), randomFirstName() + " " + randomLastName());
                AddPerson(p);
            }
            return "tneket!!!";
        }

        private String randomFirstName()
        {
            List<String> firstNames = new List<String> {"Mahdi", "Amine", "Iheb", "Sami", "Chaima", "Amal"};
            Random r = new Random();
            int i = r.Next(0, firstNames.Count - 1);
            return firstNames[i];
        }

        private String randomLastName()
        {
            List<String> lastNames = new List<String> {"Khardani", "Safi", "Besbes", "Fakhfakh", "Nakti", "Ouerfelli"};
            Random r = new Random();
            int i = r.Next(0, lastNames.Count - 1);
            return lastNames[i];
        }

        private int randomAge()
        {
            Random r = new Random();
            return r.Next(18, 113);
        }

        private Gender randomGender()
        {
            List<Gender> genders = new List<Gender> { Gender.Female, Gender.Male };
            Random r = new Random();
            int i = r.Next(0, genders.Count - 1);
            return genders[i];
        }

        private CivilState randomCivilState()
        {
            List<CivilState> civilStates = new List<CivilState> {CivilState.Complicated, CivilState.Divorced, CivilState.Married, CivilState.Single, CivilState.Widowed };
            Random r = new Random();
            int i = r.Next(0, civilStates.Count - 1);
            return civilStates[i];
        }

        public List<Person> getAllCitizens()
        {
            List<Person> output = new List<Person>();
            String query = "select * from Citizens order by civil_state";
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = query;
            sqlCommand.Connection.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Enum.TryParse(reader.GetString(4), out Gender g);
                Enum.TryParse(reader.GetString(3), out CivilState cs);
                Person p = new Person(reader.GetString(0), reader.GetString(1), int.Parse(reader.GetString(2).Trim()), g, cs, reader.GetString(5), reader.GetString(6));
                output.Add(p);
            }
            
            sqlCommand.Connection.Close();

            return output;
        }

    }
}