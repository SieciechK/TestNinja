using System;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Fundamentals;


namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCanceledBy_Admin_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();
            //Act
            var result = reservation.CanBeCancelledBy(new User {IsAdmin = true});
            //Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCanceledBy_Creator_ReturnsTrue()
        {
            var creator = new User();
            var reservation = new Reservation {MadeBy = creator};

            var result = reservation.CanBeCancelledBy(creator);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCanceledBy_DifferentUser_ReturnsFalse()
        {
            var reservation = new Reservation {MadeBy = new User()};

            var result = reservation.CanBeCancelledBy(new User());

            Assert.That(result, Is.False);
        }
    }
}
