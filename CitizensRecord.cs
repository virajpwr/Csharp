using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHARPEXAM
{
    class CitizensRecord<T> where T : Person
    {
        private T[] _elements;
        public T[] Elements { get;}

        private int currentIndex;

        public CitizensRecord(int size)
        {
            _elements = new T[size];
            currentIndex = 0;
        }

        public void AddElement(T element)
        {
            _elements[currentIndex] = element;
            currentIndex++;
        }

        public void RemoveLast()
        {
            currentIndex--;
        }

        public Boolean RemoveElement(T element)
        {
            var toRemove =
                from tmp in _elements
                where tmp.Equals(element)
                select tmp;

            if(toRemove.ToList().Count>0)
            {
                for(int i=0; i<currentIndex; i++)
                {
                    if(_elements[i].Equals(element))
                    {
                        for(int j=i; j< currentIndex - 1; j++)
                        {
                            _elements[j] = _elements[j + 1];
                        }
                    }
                }
                currentIndex--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<T> FindByName(String name)
        {
            var result =
                from tmp in _elements
                where tmp.FirstName == name || tmp.LastName == name
                select tmp;
            return result.ToList();
        }

        public List<T> FindByAge(int minAge, int maxAge)
        {
            var result =
                from tmp in _elements
                where tmp.Age >= minAge && tmp.Age<=maxAge 
                select tmp;
            return result.ToList();
        }

        public List<T> FindByGender(Gender gender)
        {
            var result =
                from tmp in _elements
                where tmp.Gender == gender
                select tmp;
            return result.ToList();
        }

        public List<T> FindByCivilState(CivilState civilState)
        {
            var result =
                from tmp in _elements
                where tmp.CivilState == civilState
                select tmp;
            return result.ToList();
        }

        public int Length()
        {
            return currentIndex;
        }
    }
}