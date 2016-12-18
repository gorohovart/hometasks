using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using God.Atributes;
using God.Creatures;
using God.Enumerators;
using God.Enums;

namespace God.Helpers
{
    public static class DatingHelper
    {
        public static bool IsTestMode = false;
        public static IHasName Couple(Human human1, Human human2)
        {
            if (human1 == null || human2 == null)
            {
                throw new ArgumentNullException();
            }

            CheckSameGender(human1, human2);

            if (IsFitAndLike(human1, human2) && IsFitAndLike(human2, human1))
            {
                var childName = GetChildName(human2);
                var childType = GetChildTypeByName(GetChildTypeName(human1, human2));
                if (childType == null)
                {
                    throw new Exception("Child type wasnt found!");
                }

                var constructor = childType.GetConstructors().FirstOrDefault();
                if (constructor == null)
                {
                    throw new NotImplementedException("No constructor for child type!");
                }

                const int numberOfParamsForBook = 1;
                const int numberOfParamsForGirls = 2;
                switch (constructor.GetParameters().Length)
                {
                    case numberOfParamsForBook:
                        return (IHasName)Activator.CreateInstance(childType, childName);
                    case numberOfParamsForGirls:
                        return (IHasName)Activator.CreateInstance(childType, childName, 
                            new CreationHelper().GetPatronymicByParentsAndGender(human1, human2, Gender.Female));
                    default:
                        throw new Exception("Thmth gone wrong!");
                }
            }

            Console.WriteLine(Resource.DontLike);
            return null;
        }

        private static Type GetChildTypeByName(string childTypeName)
      => Type.GetType($"God.Creatures.{childTypeName}, God");

        private static string GetChildName(Human human)
        {
            var methodsOfHuman = human.GetType().GetMethods();
            var getRandomNameMethod = methodsOfHuman.FirstOrDefault(x => x.ReturnType == typeof(string) && x.Name == Human.NameOfMethod);
            if (getRandomNameMethod == null)
            {
                throw new NotImplementedException();
            }

            var childName = "defaultChildName";
            try
            {
                childName = (string) getRandomNameMethod.Invoke(human, null);
            }
            catch
            {
                // ignored
            }

            return childName;
        }

        private static void CheckSameGender(Human human1, Human human2)
        {
            if (human1.Gender == human2.Gender)
                throw new GenderException();
        }

        private static string GetChildTypeName(Human human1, Human human2)
        {
            var firstAttributes = new CoupleAttributeEnumerator(human1);
            var matchingAttribute = firstAttributes.FirstOrDefault(x => x.Pair == NameHelper.GetTypeName(human2));
            return matchingAttribute.ChildType;
        }
        private static bool IsFitAndLike(Human human1, Human human2)
        {
            var firstAttributes = new CoupleAttributeEnumerator(human1);
            var matchingAttribute = firstAttributes.FirstOrDefault(x => x.Pair == NameHelper.GetTypeName(human2));
            if (matchingAttribute == null)
            {
                throw new NotImplementedException();
            }
            return matchingAttribute.GenerateDecision(IsTestMode);
        }
    }


    public class GenderException : Exception
    {
        public GenderException() : base(Resource.SameGenderError)
        { }
    }
}
