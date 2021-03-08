using NUnit.Framework;
using Oblig1;

namespace PersonTest
{
    public class PersonTest
    {


        [Test]
        public void TestAllFields()
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) F�dt: 2000 D�d: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestNoFields()
        {
            var p = new Person
            {
                Id = 1,
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }

        [Test]
        public void TestForSomeFields()
        {
            var p = new Person
            {
                Id = 2,
                FirstName = "Erik",
                //LastName = "Isaksen",
                BirthYear = 1993,
                //DeathYear = 2075,
                Father = new Person() { Id = 20, FirstName = "Bj�rn" },
                //Mother = new Person() { Id = 21, FirstName = "Trine" },
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Erik (Id=2) F�dt: 1993 Far: Bj�rn (Id=20)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}